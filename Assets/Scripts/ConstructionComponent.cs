using System;
using System.Collections.Generic;
using System.Linq;
using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Items;
using FactoryStarter.Core.Positions;
using UnityEngine;

public class ConstructionComponent : MonoBehaviour, IConstructionEventHandler {
    public ConstructionTypeDto TypeDto => new ConstructionTypeDto {
        Id = Id,
        Name = Name,
        Offsets = Offsets,
        RequiredItems = RequiredItems.Select(x=> new ItemBunchDto {
            TypeId = x.ItemPrefab.GetComponent<ItemComponent>().Id,
            Count = x.Count
        }).ToList(),
        StorageCapacity = transform.Find("Slots").childCount
    };

    public int Id;
    public string Name;
    public List<Position3> Offsets;

    public List<RequiredItem> RequiredItems;

    private GameComponent _prefabContainer => GameObject.Find("Game").GetComponent<GameComponent>();

    [Serializable]
    public struct RequiredItem {
        public GameObject ItemPrefab;
        public int Count;
    }
    
    private List<Transform> slots = new List<Transform>();
    private Dictionary<int, Stack<GameObject>> items = new Dictionary<int, Stack<GameObject>>();
    private int UsedCapacity;

    public void OnItemBunchAdded(ItemBunchDto itemBunch) {
        var itemPrefab = _prefabContainer.GetItemPrefab(itemBunch.TypeId);

        Stack<GameObject> stack;
        if (items.ContainsKey(itemBunch.TypeId)) {
            stack = items[itemBunch.TypeId];
            var itemComponent = stack.Peek().GetComponent<ItemComponent>();

            var count = Math.Min(itemComponent.CountPerSlot - itemComponent.Count, itemBunch.Count);
            itemComponent.Count += count;
            itemBunch.Count -= count;
        }
        else {
            stack = new Stack<GameObject>();
            items.Add(itemBunch.TypeId, stack);
        }
        
        while (itemBunch.Count > 0) {
            var freeSlot = slots.First(x => x.childCount == 0);
            var itemObject = Instantiate(itemPrefab, freeSlot.transform);
            var itemComponent = itemObject.GetComponent<ItemComponent>();
            
            var count = Math.Min(itemComponent.CountPerSlot - itemComponent.Count, itemBunch.Count);
            itemComponent.Count += count;
            itemBunch.Count -= count;
            
            stack.Push(itemObject);
        }
    }

    public void OnItemBunchRemoved(ItemBunchDto itemBunch) {
        var stack = items[itemBunch.TypeId];

        while (itemBunch.Count > 0) {
            var itemObject = stack.Peek();
            var itemComponent = itemObject.GetComponent<ItemComponent>();

            var count = Math.Min(itemComponent.Count, itemBunch.Count);
            itemComponent.Count -= count;
            itemBunch.Count -= count;

            if (itemComponent.Count == 0) {
                stack.Pop();
                Destroy(itemObject);
            }
        }
    }

    public void Awake() {
        Debug.Log("Awake");
        foreach (var slot in transform.Find("Slots")) 
            slots.Add(slot as Transform);
    }
}
