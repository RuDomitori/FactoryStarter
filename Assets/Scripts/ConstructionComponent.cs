using System.Collections;
using System.Collections.Generic;
using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Items;
using UnityEngine;

public class ConstructionComponent : MonoBehaviour, IConstructionEventHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnItemBunchAdded(ItemBunchDto itemBunch) {
        throw new System.NotImplementedException();
    }

    public void OnItemBunchRemoved(ItemBunchDto itemBunch) {
        throw new System.NotImplementedException();
    }
}
