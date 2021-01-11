namespace FactoryStarter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var saveLoader = new SaveLoader();
            var info = saveLoader.LoadFactoryTypeInfo("Factory");
            info.Name = "Factory 2";
            saveLoader.SaveFactoryTypeInfo(info);
        }
    }
}