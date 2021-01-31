using System;
using System.Collections.Generic;
using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core.Levels
{
    internal class Level
    {
        internal uint Id;
        internal string Name = "New level";
        private uint _lastId;
        private uint NextId => ++_lastId;
        internal uint Width = 1;
        internal uint Height = 1;
        internal Cell[,] Cells = new Cell[1, 1];

        internal ILevelEventHandler EventHandler;
        private readonly TypesContainer _types;
        
        internal readonly List<Construction> Constructions = new List<Construction>();
        
        internal readonly Dictionary<uint, ConstructionType> AvailableConstructionTypes = 
            new Dictionary<uint, ConstructionType>();

        internal Level(TypesContainer types) => _types = types;

        internal void Restore(LevelDto dto)
        {
            Name = dto.Name;
            Id = dto.Id;
            ChangeSize(dto.Width, dto.Height);
            _lastId = 0;
            
            AvailableConstructionTypes.Clear();
            
            foreach (var id in dto.AvailableConstructionTypes)
                AvailableConstructionTypes[id] = _types.GetConstructionType(id);
            
            Constructions.Clear();
            
            foreach (var constructionInfo in dto.Constructions)
            {
                var id = constructionInfo.Id;
                var type = _types.GetConstructionType(constructionInfo.TypeId);
                var center = constructionInfo.Center;
                
                if (!CheckPlace(type, center))
                    throw new Exception($"Failed to build construction {type.Name}");
                    
                var construction = new Construction(constructionInfo, _types);
                Constructions.Add(construction);
                
                foreach (var offset in type.Offsets)
                    Cells[center.X + offset.X, center.Y + offset.Y][offset.Layer] = construction;

                EventHandler.OnConstructionBuilt(type.Id, id, center);
                
                if (_lastId < id) _lastId = id;
            }
        }
        
        internal void ChangeSize(uint width, uint height)
        {
            if (width == 0 || height == 0) throw new ArgumentException("Size args must be positive");
            
            Width = width;
            Height = height;

            Cells = new Cell[Width, Height];

            EventHandler.OnSizeChanged(width, height);
        }

        internal bool CheckPlace(ConstructionType type, Position2 center)
        {
            foreach (var offset in type.Offsets)
                if (Width < center.X + offset.X
                    || Height < center.Y + offset.Y
                    || center.X < -offset.X
                    || center.Y < -offset.Y
                    || Cells[center.X + offset.X, center.Y + offset.Y][offset.Layer] != null)
                    return false;

            return true;
        }
        
        internal void Build(ConstructionType type, Position2 center)
        {
            if (!CheckPlace(type, center)) throw new Exception($"Failed to build {type.Name}");

            var construction = new Construction(type, center, NextId);
            Constructions.Add(construction);
            foreach (var offset in type.Offsets)
            {
                Cells[center.X + offset.X, center.Y + offset.Y][offset.Layer] = construction;
            }

            EventHandler.OnConstructionBuilt(type.Id, construction.Id, center);
        }
    }
}