using System;

namespace FactoryStarter.Core.Constructions.Rpn {
    
    [Serializable]
    public struct Elem {
        public readonly ElemType Type;
        public readonly int Number;
        public readonly string Str;

        public Elem(ElemType type, int number = 0, string str = null) {
            Type = type;
            Number = number;
            Str = str;
        }

        public enum ElemType {
            Arg,
            TryCraft
        }
    }
}