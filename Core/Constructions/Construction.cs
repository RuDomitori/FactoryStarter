using System.Collections.Generic;
using FactoryStarter.Core.Items;

namespace FactoryStarter.Core.Constructions
{
    public class Construction
    {
        public readonly ConstructionType Type;
        
        public readonly uint Id;

        public Position Center;
    }

    public class ConstructionType
    {
        public readonly uint Id;

        public readonly List<Position> Offsets;

        public readonly Dictionary<ItemType, uint> RequiredItems;
    }
}