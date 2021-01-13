using System;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core.Constructions
{
    [Serializable]
    public class ConstructionInfo
    {
        public uint TypeId { get; set; }
        
        public uint Id { get; set; }
        
        public Position2 Center { get; set; }
        
        public ConstructionInfo() {}

        internal ConstructionInfo(Construction construction)
        {
            TypeId = construction.Type.Id;
            Id = construction.Id;
            Center = construction.Center;
        }
    }
}