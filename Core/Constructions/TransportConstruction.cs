using System;
using System.Collections.Generic;
using FactoryStarter.Core.Items;

namespace FactoryStarter.Core.Constructions
{
    internal class Transport: Construction
    {
        public TransportType TransportType => (TransportType) Type;
    }

    internal class TransportType : ConstructionType
    {
        internal TransportType(TransportTypeInfo info, Dictionary<uint, ItemType> itemTypes) : base(info, itemTypes) {}
    }

    [Serializable]
    public class TransportTypeInfo : ConstructionTypeInfo
    {
        public TransportTypeInfo() {}
        
        internal TransportTypeInfo(TransportType type) : base(type) {}
    }
}