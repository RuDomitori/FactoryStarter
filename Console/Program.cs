namespace FactoryStarter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var saveLoader = new SaveLoader();

            var infos = saveLoader.LoadAllConstructionTypeInfos();
            
            foreach (var info in infos) info.Name = "New" + info.Name;
            
            saveLoader.SaveAllConstructionTypeInfos(infos);
        }
    }
}