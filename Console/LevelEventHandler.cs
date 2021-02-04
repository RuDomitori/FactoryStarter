using FactoryStarter.Core;
using FactoryStarter.Core.Levels;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Console
{
    public class LevelEventHandler: ILevelEventHandler
    {
        private Game _game;

        public LevelEventHandler(Game game) => _game = game;

        public void OnSizeChanged(uint width, uint height)
        {
            System.Console.WriteLine($"[SizeChanged] Size: ({width}, {height})");
        }

        public void OnConstructionBuilt(uint typeId, uint id, Position2 center)
        {
            _game.SetConstructionEventHandler(id, new ConstructionEventHandler(id));
            System.Console.WriteLine($"[ConstructionBuilt] Id: {id}, center: ({center.X}, {center.Y})");
        }
    }
}