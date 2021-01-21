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
        internal Dictionary<ItemType, uint> RequiredItems = new Dictionary<ItemType, uint>();

        internal ConstructionType(ConstructionTypeDto dto, TypesContainer types)
        {
            Name = dto.Name;
            Id = dto.Id;
            Offsets = dto.Offsets;
            
            foreach (var item in dto.RequiredItems)
                RequiredItems.Add(types.GetItemType(item.Key), item.Value);
        }
        
    }
}