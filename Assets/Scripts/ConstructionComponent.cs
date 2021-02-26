using System.Collections;
using System.Collections.Generic;
using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Items;
using UnityEngine;

public class ConstructionComponent : MonoBehaviour, IConstructionEventHandler {
    public ConstructionTypeDto dto;
    public void OnItemBunchAdded(ItemBunchDto itemBunch) {
        throw new System.NotImplementedException();
    }

    public void OnItemBunchRemoved(ItemBunchDto itemBunch) {
        throw new System.NotImplementedException();
    }
}
