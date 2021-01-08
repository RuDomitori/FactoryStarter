using System.Collections.Generic;
using FactoryStarter.Core.Constructions;

namespace FactoryStarter.Core
{
    public class Level
    {
        private uint _id = 0;

        private enum GameModeType
        {
            Common,
            Creative
        }

        private GameModeType _gameMode = GameModeType.Creative;
        private uint _width = 0;
        private uint _height = 0;
        private Cell[,] _cells = null;
        
        private List<Factory> _factories = new List<Factory>();
        private List<Logic> _logics = new List<Logic>();
        private List<Transport> _transports = new List<Transport>();

        private Dictionary<uint, ConstructionType> _availableConstructions = null;
        public Message ChangeSize(uint width, uint height)
        {
            _width = width;
            _height = height;
            return new LevelSizeChanging(width, height);
        }
        
        public class LevelSizeChanging: Message
        {
            public readonly uint NewWidth;
            public readonly uint NewHeight;
            internal LevelSizeChanging(uint newWidth, uint newHeight)
            {
                NewWidth = newWidth;
                NewHeight = newHeight;
            }
        }

        private void GenerateEmptyCells()
        {
            _cells = new Cell[_width, _height];
        }
    }
}