using System;
using FactoryStarter.Core.Constructions;

namespace FactoryStarter.Core {
    internal struct Cell {
        private Construction _factory;
        private Construction _logic;
        private Construction _transport;

        internal Construction this[uint layer] {
            get {
                switch (layer) {
                    case 0:
                        return _transport;
                    case 1:
                        return _logic;
                    case 2:
                        return _factory;
                    default:
                        throw new ArgumentException($"Layer {layer} is not exist");
                }
            }
            set {
                switch (layer) {
                    case 0:
                        _transport = value;
                        break;
                    case 1:
                        _logic = value;
                        break;
                    case 2:
                        _factory = value;
                        break;
                    default:
                        throw new ArgumentException($"Layer {layer} is not exist");
                }
            }
        }
    }
}