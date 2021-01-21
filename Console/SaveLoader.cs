using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Items;
using FactoryStarter.Core.Levels;

namespace FactoryStarter.Console
{
    public class SaveLoader
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        public string ConstructionTypesFolder = "./Constructions";
        public string ItemTypesFolder = "./Items";
        public string LevelsFolder = "./Levels";
        public SaveLoader()
        {
            _jsonSerializerOptions = new JsonSerializerOptions();
            _jsonSerializerOptions.Converters.Add(new DictionaryUintConverter<uint>());
            _jsonSerializerOptions.WriteIndented = true;
        }

        #region ConstructionTypes

        public void Save(ConstructionTypeDto dto) =>
            _Save(dto, $"{ConstructionTypesFolder}/{dto.Name}.json");

        public void Save(List<ConstructionTypeDto> infos)
        {
            foreach (var info in infos) _Save(info, $"{ConstructionTypesFolder}/{info.Name}.json");
        }
        
        public ConstructionTypeDto LoadConstructionType(string name) =>
            _Load<ConstructionTypeDto>($"{ConstructionTypesFolder}/{name}.json");

        public List<ConstructionTypeDto> LoadAllConstructionTypes()
        {
            var result = new List<ConstructionTypeDto>();
            
            foreach (var path in Directory.GetFiles(ConstructionTypesFolder))
                result.Add(_Load<ConstructionTypeDto>(path));

            return result;
        }

        #endregion

        #region ItemTypes

        public void Save(ItemTypeDto dto) =>
            _Save(dto, $"{ItemTypesFolder}/{dto.Name}.json");

        public void Save(List<ItemTypeDto> infos)
        {
            foreach (var info in infos) _Save(info, $"{ItemTypesFolder}/{info.Name}.json");
        }
        
        public ItemTypeDto LoadItemType(string name) =>
            _Load<ItemTypeDto>($"{ItemTypesFolder}/{name}.json");

        public List<ItemTypeDto> LoadAllItemTypes()
        {
            var infos = new List<ItemTypeDto>();

            foreach (var path in Directory.GetFiles(ItemTypesFolder)) infos.Add(_Load<ItemTypeDto>(path));

            return infos;
        }
        
        #endregion

        #region Level

        public void Save(LevelDto dto) => _Save(dto, $"{LevelsFolder}/{dto.Name}.json");

        public LevelDto LoadLevel(string name) => _Load<LevelDto>($"{LevelsFolder}/{name}.json");

        #endregion

        private void _Save<T>(T info, string path)
        {
            using (var fs = File.Create(path))
                JsonSerializer.SerializeAsync(fs, info, _jsonSerializerOptions)
                    .Wait();
        }

        private T _Load<T>(string path)
        {
            using (var fs = File.OpenRead(path))
                return JsonSerializer.DeserializeAsync<T>(fs, _jsonSerializerOptions)
                    .GetAwaiter()
                    .GetResult();
        }
    }
}