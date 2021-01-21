using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core.Constructions
{
    internal class Construction
    {
        internal ConstructionType Type;
        internal uint Id;
        internal Position2 Center;

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
        }
    }
}