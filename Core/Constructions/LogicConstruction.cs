using System;
using System.Collections.Generic;
using FactoryStarter.Core.Items;

namespace FactoryStarter.Core.Constructions
{
    internal class Logic: Construction
    {
        public LogicType LogicType => (LogicType) Type;
    }

    internal class LogicType : ConstructionType
    {
        internal LogicType(LogicTypeInfo info, Dictionary<uint, ItemType> itemTypes) : base(info, itemTypes) {}
    }

    [Serializable]
    public class LogicTypeInfo : ConstructionTypeInfo
    {
        public LogicTypeInfo() {}
        internal LogicTypeInfo(LogicType type) : base(type) {}
    }
}