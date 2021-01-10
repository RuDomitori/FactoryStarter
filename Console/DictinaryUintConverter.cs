using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FactoryStarter.Console
{
    public class DictionaryUintConverter<T>: JsonConverter<Dictionary<uint,T>>
    {
        public override Dictionary<uint, T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            var dictionary = new Dictionary<uint, T>();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return dictionary;
                }

                // Get the key.
                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException();
                }

                string keyAsString = reader.GetString();
                if (!uint.TryParse(keyAsString, out var key))
                {
                    throw new JsonException($"Unable to convert \"{keyAsString}\" to uint.");
                }

                // Get the value.
                T value;
                if (options.GetConverter(typeof(T)) is JsonConverter<T> valueConverter)
                {
                    reader.Read();
                    value = valueConverter.Read(ref reader, typeof(T), options);
                }
                else
                {
                    value = JsonSerializer.Deserialize<T>(ref reader, options);
                }

                // Add to dictionary.
                dictionary.Add(key, value);
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, Dictionary<uint, T> dictionary, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            foreach (var (key, value) in dictionary)
            {
                var propertyName = key.ToString();
                writer.WritePropertyName
                    (options.PropertyNamingPolicy?.ConvertName(propertyName) ?? propertyName);

                if (options.GetConverter(typeof(T)) is JsonConverter<T> valueConverter)
                {
                    valueConverter.Write(writer, value, options);
                }
                else
                {
                    JsonSerializer.Serialize(writer, value, options);
                }
            }

            writer.WriteEndObject();
        }
    }
}