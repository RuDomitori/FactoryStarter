using System;
using System.Collections.Generic;
using FactoryStarter.Core.Constructions;

namespace FactoryStarter.Core
{
    public class Level
    {
        private uint _id = 0;
        
        private uint _width = 0;
        private uint _height = 0;
        private Cell[,] _cells = null;
        
        private List<Construction> _constructions = new List<Construction>();
        
        internal Dictionary<uint, ConstructionType> _availableConstructionTypes = new Dictionary<uint, ConstructionType>();

        public delegate void ChangingSize(uint width, uint height);

        internal event ChangingSize OnChangingSize;
        internal void ChangeSize(uint width, uint height)
        {
            if (width == 0 || height == 0) throw new ArgumentException("Size args must be positive");
            
            _width = width;
            _height = height;
            
            GenerateEmptyCells();

            OnChangingSize?.Invoke(width, height);
        }
        
        private void GenerateEmptyCells()
        {
            _cells = new Cell[_width, _height];
        }
    }
}