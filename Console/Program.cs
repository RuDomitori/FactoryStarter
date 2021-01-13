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
            
            game.Add(saveLoader.LoadAllItemTypeInfos());
            game.Add(saveLoader.LoadAllConstructionTypeInfos());

            var binder = game.EventBinder;
            var editor = game.LevelEditor;

            binder.OnChangingSize += (w, h) => 
                System.Console.WriteLine($"Level size has been changed to {w}, {h}");

            binder.OnBuilding += (id, center) =>
                System.Console.WriteLine($"Construction with id {id} has been built on {center.X}, {center.Y}");
            
            editor.ChangeLevelSize(9,9);
            editor.BuildConstruction(1, new Position2(4, 4));

            saveLoader.SaveLevelInfo(game.LevelInfo);
        }
    }
}