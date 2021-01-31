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
        public uint TypeId { get; set; }
        public uint Id { get; set; }
        public Position2 Center { get; set; }
        public List<ItemDto> Items { get; set; }
        
        public ConstructionDto() {}
        
        internal ConstructionDto(Construction construction)
        {
            TypeId = construction.Type.Id;
            Id = construction.Id;
            Center = construction.Center;
            Items = construction.Items
                .Select(item => new ItemDto(item))
                .ToList();
        }
    }
}