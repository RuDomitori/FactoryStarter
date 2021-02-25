using System;
using System.Collections.Generic;
using FactoryStarter.Core.Constructions.Rpn;
using FactoryStarter.Core.Items;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core.Constructions
{
    [Serializable]
    public class ConstructionTypeDto {
        public string Name;
        public int Id;
        public List<Position3> Offsets;
        public List<ItemBunchDto> RequiredItems;
        public int StorageCapacity;
        public List<List<Rpn.Elem>> Logic = new List<List<Elem>>();
    }
}