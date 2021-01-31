using System.Collections.Generic;
using System.Linq;
using FactoryStarter.Core.Items;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core.Constructions
{
    internal class Construction
    {
        internal ConstructionType Type;
        internal uint Id;
        internal Position2 Center;
        internal List<Item> Items = new List<Item>();

        internal Construction(ConstructionType type, Position2 center, uint id)
        {
            Id = id;
            Type = type;
            Center = center;
        }

        internal Construction(ConstructionDto dto, TypesContainer types)
        {
            Type = types.GetConstructionType(dto.TypeId);
            Id = dto.Id;
            Center = dto.Center;
            Items = dto.Items
                ?.Select(dto => new Item(dto, types))
                ?.ToList() ?? new List<Item>();
        }
    }
}