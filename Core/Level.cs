using System.Collections.Generic;
using Core.Construction;

namespace Core
{
    public class Level
    {
        private uint _width;
        private uint _height;
        private Cell[,] _cells;
        
        private List<Factory> _factories;
        private List<Logic> _logics;
        private List<Transport> _transports;
    }
}