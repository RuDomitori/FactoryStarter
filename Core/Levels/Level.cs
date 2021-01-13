using System;
using System.Collections.Generic;
using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core.Levels
{
    public class Level
    {
        internal uint Id;
        internal string Name = "New level";
        private uint _lastId;
        private uint NextId => ++_lastId;
        internal uint Width = 1;
        internal uint Height = 1;
        internal Cell[,] Cells = new Cell[1, 1];
        
        internal List<Construction> Constructions = new List<Construction>();
        
        internal Dictionary<uint, ConstructionType> AvailableConstructionTypes = new Dictionary<uint, ConstructionType>();

        public delegate void ChangingSize(uint width, uint height);

        internal event ChangingSize OnChangingSize;
        internal void ChangeSize(uint width, uint height)
        {
            if (width == 0 || height == 0) throw new ArgumentException("Size args must be positive");
            
            Width = width;
            Height = height;
            
            GenerateEmptyCells();

            OnChangingSize?.Invoke(width, height);
        }
        
        private void GenerateEmptyCells() => Cells = new Cell[Width, Height];
        
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

        public delegate void Building(uint typeId, Position2 center);

        public event Building OnBuilding;
        internal void Build(ConstructionType type, Position2 center)
        {
            if (!CheckPlace(type, center)) throw new Exception($"Failed to build {type.Name}");

            var construction = new Construction(type, center, NextId);
            Constructions.Add(construction);
            foreach (var offset in type.Offsets)
            {
                Cells[center.X + offset.X, center.Y + offset.Y][offset.Layer] = construction;
            }

            OnBuilding?.Invoke(type.Id, center);
        }
    }
}