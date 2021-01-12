using System;
using System.Collections.Generic;

namespace FactoryStarter.Core.Constructions
{
    [Serializable]
    public class ConstructionTypeInfo
    {
        public string Name { get; set; }
        public uint Id { get; set; }
        public List<Position> Offsets { get; set; }
        public Dictionary<uint, uint> RequiredItems { get; set; }

        public ConstructionTypeInfo() {}

        internal ConstructionTypeInfo(ConstructionType type)
        {
            Name = type.Name;
            Id = type.Id;
            Offsets = type.Offsets;
            RequiredItems = new Dictionary<uint, uint>();
            foreach (var pare in type.RequiredItems)
            {
                RequiredItems.Add(pare.Key.Id, pare.Value);
            }
        }
    }
}