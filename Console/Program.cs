using FactoryStarter.Core;
using FactoryStarter.Core.Levels;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var saveLoader = new SaveLoader();
            var game = new Game();

            var typesContainer = game.Types;
            var editor = game.Editor;

            typesContainer.Add(saveLoader.LoadAllItemTypes());
            typesContainer.Add(saveLoader.LoadAllConstructionTypes());
            
            game.SetLevelEventHandler(new LevelEventHandler());
            
            var level = saveLoader.LoadLevel("Test level");
            game.RestoreLevel(level);
            saveLoader.Save(game.LevelDto);
        }
    }
}