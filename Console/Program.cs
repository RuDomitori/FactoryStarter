using FactoryStarter.Core;
using FactoryStarter.Core.Levels;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(new DtoRepository());

            var editor = game.Editor;
            
            game.SetLevelEventHandler(new LevelEventHandler());
            
            editor.ChangeLevelSize(9, 9);
            editor.BuildConstruction(1, new Position2(4, 4));
            editor.BuildConstruction(2, new Position2(7, 7));
            
            game.SaveLevel();
        }
    }
}