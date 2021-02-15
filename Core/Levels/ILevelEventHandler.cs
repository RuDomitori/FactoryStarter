using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core.Levels
{
    public interface ILevelEventHandler
    {
        public void OnSizeChanged(int width, int height);
        public void OnConstructionBuilt(int typeId, int id, Position2 center);
    }
}