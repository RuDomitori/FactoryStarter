using System;

namespace FactoryStarter.Core.Positions {
    
    [Serializable]
    public struct Position2 {
        public int X;
        public int Y;

        public Position2(int x, int y) {
            X = x;
            Y = y;
        }
    }
}