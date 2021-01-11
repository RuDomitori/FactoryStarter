using System.IO;
using System.Text.Json;
using FactoryStarter.Core.Constructions;

namespace FactoryStarter.Console
{
    public class SaveLoader
    {
        private JsonSerializerOptions _jsonSerializerOptions;
        public string FactoryTypesFolder = "./Constructions/Factories";
        public string LogicTypesFolder = "./Construction/Logics";
        public string TransportTypesFolder = "./Construction/Transports";
        public SaveLoader()
        {
            _jsonSerializerOptions = new JsonSerializerOptions();
            _jsonSerializerOptions.Converters.Add(new DictionaryUintConverter<uint>());
            _jsonSerializerOptions.WriteIndented = true;
        }

        #region Saving types info

        public void SaveFactoryTypeInfo(FactoryTypeInfo info) => 
            _SaveConstructionTypeInfo(info, FactoryTypesFolder);
        public void SaveLogicTypeInfo(LogicTypeInfo info) => 
            _SaveConstructionTypeInfo(info, LogicTypesFolder);
        public void SaveTransportTypeInfo(TransportTypeInfo info) =>
            _SaveConstructionTypeInfo(info, TransportTypesFolder);
        
        private void _SaveConstructionTypeInfo<T>(T info, string folder)
            where T : ConstructionTypeInfo
        {
            using (FileStream fs = new FileStream($"{folder}/{info.Name}.json", FileMode.Create))
            {
                JsonSerializer.SerializeAsync<T>(fs, info, _jsonSerializerOptions);
            }
        }

        #endregion

        #region Loading types info

        public FactoryTypeInfo LoadFactoryTypeInfo(string name) =>
            _LoadConstructionTypeInfo<FactoryTypeInfo>(name, FactoryTypesFolder);

        public LogicTypeInfo LoadLogicTypeInfo(string name) =>
            _LoadConstructionTypeInfo<LogicTypeInfo>(name, LogicTypesFolder);

        public TransportTypeInfo LoadTransportTypeInfo(string name) =>
            _LoadConstructionTypeInfo<TransportTypeInfo>(name, TransportTypesFolder);

        private T _LoadConstructionTypeInfo<T>(string name, string folder)
            where T: ConstructionTypeInfo
        {
            using (FileStream fs = new FileStream($"{folder}/{name}.json", FileMode.Open))
            {
                var task = JsonSerializer.DeserializeAsync<T>(fs, _jsonSerializerOptions);
                return task.Result;
            }
        }

        #endregion
    }
}