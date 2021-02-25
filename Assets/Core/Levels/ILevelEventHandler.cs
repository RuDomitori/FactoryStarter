using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core.Levels {
    public interface ILevelEventHandler {
        void OnSizeChanged(int width, int height);
        void OnConstructionBuilt(int typeId, int id, Position2 center);
    }
}