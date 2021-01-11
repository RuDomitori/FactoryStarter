using System.IO;
using System.Text.Json;
using FactoryStarter.Core.Constructions;

namespace FactoryStarter.Console
{
    public class SaveLoader
    {
        private JsonSerializerOptions _jsonSerializerOptions;
        public string ConstructionTypesFolder = "./Constructions";
        public SaveLoader()
        {
            _jsonSerializerOptions = new JsonSerializerOptions();
            _jsonSerializerOptions.Converters.Add(new DictionaryUintConverter<uint>());
            _jsonSerializerOptions.WriteIndented = true;
        }

        public void SaveConstructionTypeInfo(ConstructionTypeInfo info)
        {
            using (FileStream fs = new FileStream($"{ConstructionTypesFolder}/{info.Name}.json", FileMode.Create))
            {
                JsonSerializer.SerializeAsync(fs, info, _jsonSerializerOptions);
            }
        }
        
        public ConstructionTypeInfo LoadConstructionTypeInfo(string name)
        {
            using (FileStream fs = new FileStream($"{ConstructionTypesFolder}/{name}.json", FileMode.Open))
            {
                var task = JsonSerializer.DeserializeAsync<ConstructionTypeInfo>(fs, _jsonSerializerOptions);
                return task.Result;
            }
        }
    }
}