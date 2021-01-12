namespace FactoryStarter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var saveLoader = new SaveLoader();
            
            var info = saveLoader.LoadConstructionTypeInfo("Test factory");
            info.Name = "Test factory 2";
            info.Id = 4;
            saveLoader.SaveConstructionTypeInfo(info);
            
            var info2 = saveLoader.LoadItemTypeInfo("Test item");
            info2.Name = "Test item 2";
            info2.Id = 4;
            saveLoader.SaveItemTypeInfo(info2);
        }
    }
}