using FactoryStarter.Core;

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
            
        }
    }
}