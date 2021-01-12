using System.IO;
using System.Text.Json;
using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Items;

namespace FactoryStarter.Console
{
    public class SaveLoader
    {
        private JsonSerializerOptions _jsonSerializerOptions;
        public string ConstructionTypesFolder = "./Constructions";
        public string ItemTypesFolder = "./Items"; 
        public SaveLoader()
        {
            _jsonSerializerOptions = new JsonSerializerOptions();
            _jsonSerializerOptions.Converters.Add(new DictionaryUintConverter<uint>());
            _jsonSerializerOptions.WriteIndented = true;
        }

        public void SaveConstructionTypeInfo(ConstructionTypeInfo info)
        {
            using (FileStream fs = new FileStream($"{ConstructionTypesFolder}/{info.Name}.json", FileMode.Create))
                JsonSerializer.SerializeAsync(fs, info, _jsonSerializerOptions)
                    .Wait();
        }
        
        public ConstructionTypeInfo LoadConstructionTypeInfo(string name)
        {
            using (FileStream fs = new FileStream($"{ConstructionTypesFolder}/{name}.json", FileMode.Open))
                return JsonSerializer.DeserializeAsync<ConstructionTypeInfo>(fs, _jsonSerializerOptions)
                    .GetAwaiter()
                    .GetResult();
        }

        public void SaveItemTypeInfo(ItemTypeInfo info)
        {
            using (FileStream fs = new FileStream($"{ItemTypesFolder}/{info.Name}.json", FileMode.Create))
                JsonSerializer.SerializeAsync(fs, info, _jsonSerializerOptions)
                    .Wait();
        }
        
        public ItemTypeInfo LoadItemTypeInfo(string name)
        {
            using (FileStream fs = File.OpenRead($"{ItemTypesFolder}/{name}.json"))
                return JsonSerializer.DeserializeAsync<ItemTypeInfo>(fs, _jsonSerializerOptions)
                    .GetAwaiter()
                    .GetResult();
        }
    }
}