using System;
using System.Collections.Generic;
using FactoryStarter.Core.Items;

namespace FactoryStarter.Core.Constructions
{
    internal class Factory: Construction
    {
        public FactoryType FactoryType => (FactoryType) Type;
        internal object OnTact(Cell[,] field) => FactoryType.OnTact(field, this);
    }

    internal class FactoryType : ConstructionType
    {
        internal FactoryType(FactoryTypeInfo info, Dictionary<uint, ItemType> itemTypes) : base(info, itemTypes) {}
        internal object OnTact(Cell[,] field, Factory factory) => throw new NotImplementedException();
    }

    [Serializable]
    public class FactoryTypeInfo : ConstructionTypeInfo
    {
        public FactoryTypeInfo() {}
        internal FactoryTypeInfo(FactoryType type) : base(type) {}
    }
}