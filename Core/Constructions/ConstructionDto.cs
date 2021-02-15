using System;
using System.Collections.Generic;
using System.Linq;
using FactoryStarter.Core.Items;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core.Constructions
{
    [Serializable]
    public class ConstructionDto
    {
        public int TypeId { get; set; }
        public int Id { get; set; }
        public Position2 Center { get; set; }
        public List<ItemBunchDto> Items { get; set; }
        
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