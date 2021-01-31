using FactoryStarter.Core.Levels;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Console
{
    public class LevelEventHandler: ILevelEventHandler
    {
        public void OnSizeChanged(uint width, uint height)
        {
            System.Console.WriteLine($"Level size has been changed to {width}, {height}");
        }

        public void OnConstructionBuilt(uint typeId, uint id, Position2 center)
        {
            System.Console.WriteLine($"Construction with id {id} has been built on {center.X}, {center.Y}");
        }
    }
}