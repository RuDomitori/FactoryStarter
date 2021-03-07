using System;

namespace FactoryStarter.Core.Positions {
    
    [Serializable]
    public struct Position3 {
        public int X;
        public int Y;
        public Layer Layer;
    }

    public enum Layer {
        Transport,
        Logic,
        Factory,
    }
}