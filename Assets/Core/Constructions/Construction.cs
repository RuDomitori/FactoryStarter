using System;
using System.Collections.Generic;
using FactoryStarter.Core.Items;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core.Constructions
{
    internal class Construction
    {
        internal readonly ConstructionType Type;
        internal readonly int Id;
        internal Position2 Center;
        internal readonly Dictionary<ItemType, ItemBunch> Items = new Dictionary<ItemType, ItemBunch>();
        private int _usedCapacity = 0;
        internal IConstructionEventHandler EventHandler;
        internal int State = 0;

        internal Construction(ConstructionType type, Position2 center, int id) {
            Id = id;
            Type = type;
            Center = center;
        }

        internal Construction(ConstructionDto dto, TypeRepository types) 
        {
            Id = dto.Id;
            Type = types.GetConstructionType(dto.TypeId);
            Center = dto.Center;
            foreach (var itemBunchDto in dto.Items) 
                AddItemBunch(new ItemBunch(itemBunchDto, types));
        }

        internal void AddItemBunch(ItemBunch itemBunch) {
            if (Items.ContainsKey(itemBunch.Type)) {
                var existedBunch = Items[itemBunch.Type];
                var requiredCapacity = (itemBunch + existedBunch).RequiredCapacity - existedBunch.RequiredCapacity;
                if (requiredCapacity + _usedCapacity > Type.StorageCapacity) 
                    throw new Exception("Storage is full");

                _usedCapacity += requiredCapacity;
                existedBunch.Count = itemBunch.Count;
            }
            else {
                if(_usedCapacity + itemBunch.RequiredCapacity > Type.StorageCapacity)
                    throw new Exception("Storage is full");

                _usedCapacity += itemBunch.RequiredCapacity;
                Items.Add(itemBunch.Type, itemBunch);
            }
            EventHandler.OnItemBunchAdded(new ItemBunchDto(itemBunch));
        }

        internal void RemoveItemBunch(ItemBunch itemBunch) {
            if (itemBunch.Count > 0) {
                if (!Contains(itemBunch)) 
                    throw new Exception("Construction doesn't contain item bunch");

                var capacityForBunch = Items[itemBunch.Type].RequiredCapacity;
                Items[itemBunch.Type] -= itemBunch;
                _usedCapacity += Items[itemBunch.Type].RequiredCapacity - capacityForBunch;
            
                EventHandler.OnItemBunchRemoved(new ItemBunchDto(itemBunch));
            }
        }
        
        internal bool Contains(ItemBunch itemBunch) {
            return Items.ContainsKey(itemBunch.Type) && Items[itemBunch.Type].Count >= itemBunch.Count;
        }

        internal bool TryCraft(ItemBunch target, List<ItemBunch> requiredItems) {
            var releasedCapacity = 0;
            foreach (var requiredItemBunch in requiredItems) {
                if (!Contains(requiredItemBunch)) return false;

                var itemType = requiredItemBunch.Type;
                var existedBunch = Items[itemType];

                if(target.Type == itemType) {
                    target.Count -= requiredItemBunch.Count;
                    requiredItemBunch.Count = 0;
                }
                else {
                    releasedCapacity += existedBunch.RequiredCapacity
                                        - (existedBunch - requiredItemBunch).RequiredCapacity;
                }
            }

            var capacityDiff = Items.ContainsKey(target.Type)
                ? (target + Items[target.Type]).RequiredCapacity - Items[target.Type].RequiredCapacity
                : target.RequiredCapacity;

            if (_usedCapacity - releasedCapacity + capacityDiff > Type.StorageCapacity)
                return false;

            foreach (var requiredItemBunch in requiredItems) 
                RemoveItemBunch(requiredItemBunch);
            AddItemBunch(target);
            
            return true;
        }
    }
}