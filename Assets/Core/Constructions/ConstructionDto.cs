using System;
using System.Collections.Generic;
using System.Linq;
using FactoryStarter.Core.Items;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core.Constructions
{
    [Serializable]
    public class ConstructionDto {
        public int TypeId;
        public int Id;
        public Position2 Center;
        public List<ItemBunchDto> Items;
        
        public ConstructionDto() {}
        
        internal ConstructionDto(Construction construction)
        {
            TypeId = construction.Type.Id;
            Id = construction.Id;
            Center = construction.Center;
            Items = construction.Items
                .Select(pair => new ItemBunchDto(pair.Value))
                .ToList();
        }
    }
}