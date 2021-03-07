using System;
using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core {
    internal struct Cell {
        private Construction _factory;
        private Construction _logic;
        private Construction _transport;

        internal Construction this[Layer layer] {
            get {
                switch (layer) {
                    case Layer.Transport:
                        return _transport;
                    case Layer.Logic:
                        return _logic;
                    case Layer.Factory:
                        return _factory;
                    default:
                        throw new ArgumentException($"Layer {layer} is not exist");
                }
            }
            set {
                switch (layer) {
                    case Layer.Transport:
                        _transport = value;
                        break;
                    case Layer.Logic:
                        _logic = value;
                        break;
                    case Layer.Factory:
                        _factory = value;
                        break;
                    default:
                        throw new ArgumentException($"Layer {layer} is not exist");
                }
            }
        }
    }
}