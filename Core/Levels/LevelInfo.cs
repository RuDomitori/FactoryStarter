using System;
using System.Collections.Generic;
using FactoryStarter.Core.Constructions;
using System.Collections.Generic;
using System.Linq;
using FactoryStarter.Core.Items;

namespace FactoryStarter.Core.Levels
{
    [Serializable]
    public class LevelInfo
    {
        public string Name { get; set; }
        public uint Id { get; set; }
        
        public uint Width { get; set; }
        
        public uint Height { get; set; }
        public List<uint> AvailableConstructionTypes { get; set; }
        
        public List<ConstructionInfo> Constructions { get; set; }

        public LevelInfo() {}

        internal LevelInfo(Level level)
        {
            Name = level.Name;
            Id = level.Id;
            Width = level.Width;
            Height = level.Height;
            AvailableConstructionTypes = level
                .AvailableConstructionTypes
                .Select(x => x.Value.Id)
                .ToList();
            Constructions = level
                .Constructions
                .Select(c => new ConstructionInfo(c))
                .ToList();
        }
    }
}