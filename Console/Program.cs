using FactoryStarter.Core;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var saveLoader = new SaveLoader();
            var game = new Game();

            var typesContainer = game.TypesContainer;
            var binder = game.EventBinder;
            var editor = game.LevelEditor;

            typesContainer.Add(saveLoader.LoadAllItemTypeInfos());
            typesContainer.Add(saveLoader.LoadAllConstructionTypeInfos());
            
            binder.OnChangingSize += (w, h) =>
                System.Console.WriteLine($"Level size has been changed to {w}, {h}");

            binder.OnBuilding += (id, center) =>
                System.Console.WriteLine($"Construction with id {id} has been built on {center.X}, {center.Y}");

            var info = saveLoader.LoadLevelInfo("Test level");
            game.RestoreLevel(info);
            
            editor.BuildConstruction(2, new Position2(6, 6));
            saveLoader.SaveLevelInfo(game.LevelInfo);
        }
    }
}