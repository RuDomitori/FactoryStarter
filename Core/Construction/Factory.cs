using System;

namespace Core.Construction
{
    public class Factory: Construction
    {
        public FactoryType FactoryType => (FactoryType) Type;
        public object OnTact(Cell[,] field) => FactoryType.OnTact(field, this);
    }

    public class FactoryType : ConstructionType
    {
        public object OnTact(Cell[,] field, Factory factory) => throw new NotImplementedException();
    }
}