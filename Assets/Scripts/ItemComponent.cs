using System;
using FactoryStarter.Core.Items;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemComponent : MonoBehaviour {
    public ItemTypeDto TypeDto => new ItemTypeDto {
        Id = Id,
        Name = Name,
        CountPerSlot = CountPerSlot
    };

    public int Id;
    public string Name;
    private int _count = 0;
    public int CountPerSlot => transform.childCount;

    public int Count {
        get => _count;
        set {
            if(_count > value) {
                if (value < 0) {
                    throw new Exception($"{nameof(value)} < 0");
                }
                
                for (int i = value; i < _count; i++) {
                    transform.GetChild(i)
                        .GetComponent<MeshRenderer>()
                        .enabled = false;
                }
            }
            else {
                if (value > CountPerSlot) {
                    throw new Exception($"{nameof(value)} > {nameof(CountPerSlot)}");
                }
                
                for (int i = _count; i < value; i++) {
                    transform.GetChild(i)
                        .GetComponent<MeshRenderer>()
                        .enabled = true;
                }
            }

            _count = value;
        }
    }

    public void Awake() {
        foreach (Transform transform in transform) {
            transform.GetComponent<MeshRenderer>()
                .enabled = false;
        }
    }
}