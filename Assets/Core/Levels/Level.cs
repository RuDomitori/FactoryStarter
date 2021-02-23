using System;
using System.Collections.Generic;
using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Constructions.Rpn;
using FactoryStarter.Core.Items;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core.Levels {
    internal class Level {
        internal int Id;
        internal string Name = "New level";
        private int _lastId;
        private int NextId => ++_lastId;
        internal int Width = 1;
        internal int Height = 1;
        internal Cell[,] Cells = new Cell[1, 1];
        private Interpreter _interpreter;

        internal ILevelEventHandler EventHandler;
        private readonly TypeRepository _types;

        internal readonly List<Construction> Constructions = new List<Construction>();

        internal readonly Dictionary<int, ConstructionType> AvailableConstructionTypes =
            new Dictionary<int, ConstructionType>();

        internal Level(TypeRepository types) {
            _types = types;
            _interpreter = new Interpreter(this, types);
        }

        internal void Restore(LevelDto dto) {
            Name = dto.Name;
            Id = dto.Id;
            ChangeSize(dto.Width, dto.Height);
            _lastId = 0;

            AvailableConstructionTypes.Clear();

            foreach (var id in dto.AvailableConstructionTypes)
                AvailableConstructionTypes[id] = _types.GetConstructionType(id);

            Constructions.Clear();

            foreach (var constructionDto in dto.Constructions) {
                var id = constructionDto.Id;
                var type = _types.GetConstructionType(constructionDto.TypeId);
                var center = constructionDto.Center;

                var construction = Build(type, center, id);
                foreach (var bunchDto in constructionDto.Items)
                    construction.AddItemBunch(new ItemBunch(bunchDto, _types));

                if (_lastId < id) _lastId = id;
            }
        }

        internal void ChangeSize(int width, int height) {
            if (width == 0 || height == 0) throw new ArgumentException("Size args must be positive");

            Width = width;
            Height = height;

            Cells = new Cell[Width, Height];

            EventHandler.OnSizeChanged(width, height);
        }

        internal bool CheckPlace(ConstructionType type, Position2 center) {
            foreach (var offset in type.Offsets)
                if (Width < center.X + offset.X
                    || Height < center.Y + offset.Y
                    || center.X < -offset.X
                    || center.Y < -offset.Y
                    || Cells[center.X + offset.X, center.Y + offset.Y][offset.Layer] != null)
                    return false;

            return true;
        }

        internal void Build(ConstructionType type, Position2 center) => Build(type, center, NextId);

        private Construction Build(ConstructionType type, Position2 center, int id) {
            if (!CheckPlace(type, center)) throw new Exception($"Failed to build {type.Name}");

            var construction = new Construction(type, center, id);
            Constructions.Add(construction);
            foreach (var offset in type.Offsets) {
                Cells[center.X + offset.X, center.Y + offset.Y][offset.Layer] = construction;
            }

            EventHandler.OnConstructionBuilt(type.Id, construction.Id, center);
            
            return construction;
        }

        internal void Tact() {
            foreach (var construction in Constructions)
                _interpreter.Interpret(construction);
        }

        internal Construction GetConstruction(int id) {
            var construction = Constructions.Find(x => x.Id == id);

            if (construction == null)
                throw new Exception($"Construction with id {id} is not found");

            return construction;
        }
    }
}