using System;
using System.Collections.Generic;
using FactoryStarter.Core.Constructions;
using System.Linq;

namespace FactoryStarter.Core.Levels {
    [Serializable]
    public class LevelDto {
        public string Name;
        public int Id;
        public int Width;
        public int Height;
        public List<int> AvailableConstructionTypes;
        public List<ConstructionDto> Constructions;

        public LevelDto() { }

        internal LevelDto(Level level) {
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
                .Select(c => new ConstructionDto(c))
                .ToList();
        }
    }
}