using System.Collections.Generic;
using System.Linq;
using FactoryStarter.Core.Items;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core.Constructions
{
    internal class ConstructionType
    {
        internal readonly string Name;
        internal readonly int Id;
        internal readonly List<Position3> Offsets;
        internal readonly List<ItemBunch> RequiredItems;
        internal readonly int StorageCapacity;
        internal readonly List<List<Rpn.Elem>> Logic;
        internal ConstructionType(ConstructionTypeDto dto, TypeRepository types)
        {
            Name = dto.Name;
            Id = dto.Id;
            Offsets = dto.Offsets
                .Select(x=>x)
                .ToList();
            
            StorageCapacity = dto.StorageCapacity;
            Logic = dto.Logic
                .Select(x => x.ToList())
                .ToList();

            RequiredItems = dto.RequiredItems
                .Select(bunchDto => new ItemBunch(bunchDto, types))
                .ToList();
        }
    }
}