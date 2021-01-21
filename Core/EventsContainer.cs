using System;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core
{
    public class EventsContainer
    {
        #region SizeChanged
        public struct SizeChangedEventArgs
        {
            public uint Width, Height;
        }
        public event Action<SizeChangedEventArgs> SizeChanged;
        internal void OnSizeChanged(SizeChangedEventArgs args) => SizeChanged?.Invoke(args);
        #endregion
        
        #region ConstructionBuilt
        public struct ConstructionBuiltEventArgs
        {
            public uint Id, TypeId;
            public Position2 Center;
        }
        public event Action<ConstructionBuiltEventArgs> ConstructionBuilt;
        internal void OnConstructionBuilt(ConstructionBuiltEventArgs args) => ConstructionBuilt?.Invoke(args);
        #endregion
    }
}