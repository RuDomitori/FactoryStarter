using System.Collections.Generic;
using System.Linq;
using FactoryStarter.Core.Items;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core.Constructions
{
    internal class ConstructionType
    {
        internal readonly string Name;
        internal readonly uint Id;
        internal readonly List<Position3> Offsets;
        internal readonly Dictionary<ItemType, uint> RequiredItems = new Dictionary<ItemType, uint>();
        internal readonly uint StorageCapacity; 

        internal ConstructionType(ConstructionTypeDto dto, TypeRepository types)
        {
            Name = dto.Name;
            Id = dto.Id;
            Offsets = dto.Offsets
                .Select(x=>x)
                .ToList();
            
            StorageCapacity = dto.StorageCapacity;
            
            foreach (var (key, value) in dto.RequiredItems)
                RequiredItems.Add(types.GetItemType(key), value);
        }
        
    }
}