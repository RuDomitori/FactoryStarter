using System;
using System.Collections.Generic;
using FactoryStarter.Core.Items;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core.Constructions
{
    internal class ConstructionType
    {
        internal string Name;
        internal uint Id;

        internal List<Position3> Offsets;

        internal Dictionary<ItemType, uint> RequiredItems;

        internal ConstructionType(ConstructionTypeInfo info, Dictionary<uint, ItemType> itemTypes)
        {
            Name = info.Name;
            Id = info.Id;
            Offsets = info.Offsets;
            
            RequiredItems = new Dictionary<ItemType, uint>();
            
            foreach (var item in info.RequiredItems)
            {
                if (!itemTypes.ContainsKey(item.Key)) 
                    throw new Exception($"Item type {item.Key} has not downloaded to game");
                
                RequiredItems.Add(itemTypes[item.Key], item.Value);
            }
        }
        
    }
}