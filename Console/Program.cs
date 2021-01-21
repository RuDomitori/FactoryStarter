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
            var binder = game.Events;
            var editor = game.Editor;

            typesContainer.Add(saveLoader.LoadAllItemTypes());
            typesContainer.Add(saveLoader.LoadAllConstructionTypes());
            
            binder.SizeChanged += (args) =>
                System.Console.WriteLine($"Level size has been changed to {args.Width}, {args.Height}");

            binder.ConstructionBuilt += (args) =>
                System.Console.WriteLine(
                    $"Construction with id {args.Id} has been built on {args.Center.X}, {args.Center.Y}"
                    );

            var info = saveLoader.LoadLevel("Test level");
            game.RestoreLevel(info);
            
            editor.BuildConstruction(2, new Position2(6, 6));
            saveLoader.Save(game.LevelDto);
        }
    }
}