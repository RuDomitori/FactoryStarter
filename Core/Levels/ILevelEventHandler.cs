using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core.Levels
{
    public interface ILevelEventHandler
    {
        public void OnSizeChanged(uint width, uint height);
        public void OnConstructionBuilt(uint typeId, uint id, Position2 center);
    }
}