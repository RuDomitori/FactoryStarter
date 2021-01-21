using System;
using System.Collections.Generic;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core.Constructions
{
    [Serializable]
    public class ConstructionTypeDto
    {
        public string Name { get; set; }
        public uint Id { get; set; }
        public List<Position3> Offsets { get; set; }
        public Dictionary<uint, uint> RequiredItems { get; set; }

        public ConstructionTypeDto() {}

        internal ConstructionTypeDto(ConstructionType type)
        {
            Name = type.Name;
            Id = type.Id;
            Offsets = type.Offsets;
            RequiredItems = new Dictionary<uint, uint>();
            foreach (var pare in type.RequiredItems)
                RequiredItems.Add(pare.Key.Id, pare.Value);
        }
    }
}