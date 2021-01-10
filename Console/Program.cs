using System;
using System.Collections.Generic;
using System.Text.Json;
using FactoryStarter.Core;
using FactoryStarter.Core.Constructions;

namespace FactoryStarter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var info = new FactoryTypeInfo();
            info.Id = 1;
            info.Offsets = new List<Position>()
            {
                new Position() {X = 0, Y = 0},
                new Position() {X = 1, Y = 0},
                new Position() {X = 0, Y = 1},
                new Position() {X = 1, Y = 1}
            };
            info.RequiredItems = new Dictionary<uint, uint>()
            {
                {1, 10},
                {2, 5},
                {3, 1}
            };
            var options = new JsonSerializerOptions();
            options.Converters.Add(new DictionaryUintConverter<uint>());
            options.WriteIndented = true;
            var json = JsonSerializer.Serialize(info, options);
            System.Console.WriteLine(json);
        }
    }
}