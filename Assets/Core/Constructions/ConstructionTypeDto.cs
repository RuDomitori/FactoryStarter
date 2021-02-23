using System;
using System.Collections.Generic;
using FactoryStarter.Core.Items;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core.Constructions
{
    [Serializable]
    public class ConstructionTypeDto
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Position3> Offsets { get; set; }
        public List<ItemBunchDto> RequiredItems { get; set; }
        public int StorageCapacity { get; set; }
        public List<List<Rpn.Elem>> Logic { get; set; }
    }
}