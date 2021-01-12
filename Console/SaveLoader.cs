using System.Collections.Generic;
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

        public void SaveConstructionTypeInfo(ConstructionTypeInfo info) =>
            _SaveInfo(info, $"{ConstructionTypesFolder}/{info.Name}.json");

        public void SaveAllConstructionTypeInfos(List<ConstructionTypeInfo> infos)
        {
            foreach (var info in infos) _SaveInfo(info, $"{ConstructionTypesFolder}/{info.Name}.json");
        }
        
        public ConstructionTypeInfo LoadConstructionTypeInfo(string name) =>
            _LoadInfo<ConstructionTypeInfo>($"{ConstructionTypesFolder}/{name}.json");

        public List<ConstructionTypeInfo> LoadAllConstructionTypeInfos()
        {
            var result = new List<ConstructionTypeInfo>();
            
            foreach (var path in Directory.GetFiles(ConstructionTypesFolder))
                result.Add(_LoadInfo<ConstructionTypeInfo>(path));

            return result;
        }

        public void SaveItemTypeInfo(ItemTypeInfo info) =>
            _SaveInfo(info, $"{ItemTypesFolder}/{info.Name}.json");

        public void SaveAllItemTypeInfos(List<ItemTypeInfo> infos)
        {
            foreach (var info in infos) _SaveInfo(info, $"{ItemTypesFolder}/{info.Name}.json");
        }
        
        public ItemTypeInfo LoadItemTypeInfo(string name) =>
            _LoadInfo<ItemTypeInfo>($"{ItemTypesFolder}/{name}.json");

        public List<ItemTypeInfo> LoadAllItemTypeInfos()
        {
            var infos = new List<ItemTypeInfo>();

            foreach (var path in Directory.GetFiles(ItemTypesFolder)) infos.Add(_LoadInfo<ItemTypeInfo>(path));

            return infos;
        }
        
        private void _SaveInfo<T>(T info, string path)
        {
            using (var fs = File.Create(path))
                JsonSerializer.SerializeAsync(fs, info, _jsonSerializerOptions)
                    .Wait();
        }

        private T _LoadInfo<T>(string path)
        {
            using (var fs = File.OpenRead(path))
                return JsonSerializer.DeserializeAsync<T>(fs, _jsonSerializerOptions)
                    .GetAwaiter()
                    .GetResult();
        }
    }
}