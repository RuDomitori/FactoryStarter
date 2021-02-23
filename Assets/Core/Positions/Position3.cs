using System;

namespace FactoryStarter.Core.Positions
{
    [Serializable]
    public struct Position3
    {
        public int X { get; set; }
        public int Y { get; set; }
        public uint Layer { get; set; }
    }
}