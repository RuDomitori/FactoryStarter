using System;
using System.Collections.Generic;
using FactoryStarter.Core.Constructions;
using System.Linq;

namespace FactoryStarter.Core.Levels
{
    [Serializable]
    public class LevelDto
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<int> AvailableConstructionTypes { get; set; }
        public List<ConstructionDto> Constructions { get; set; }

        public LevelDto() {}

        internal LevelDto(Level level)
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
                .Select(c => new ConstructionDto(c))
                .ToList();
        }
    }
}