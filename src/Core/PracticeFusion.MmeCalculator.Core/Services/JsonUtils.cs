using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PracticeFusion.MmeCalculator.Core.Services
{
    /// <summary>
    /// A set of utilities for consistent JSON serialization and deserialization of entities.
    /// </summary>
    public static class JsonUtils
    {
        /// <summary>
        /// Serialize and return a formatted or unformatted json string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="formatted"></param>
        /// <returns></returns>
        public static string Serialize<T>(T entity, bool formatted = true)
        {
            var options = new JsonSerializerOptions { WriteIndented = formatted, IgnoreReadOnlyProperties = false, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
            options.Converters.Add(new JsonStringEnumConverter());

            return JsonSerializer.Serialize(entity, options);
        }

        /// <summary>
        /// Serialize to UTF8 bytes, used in place of BinaryFormatter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static byte[] SerializeToUtf8Bytes<T>(T entity)
        {
            return JsonSerializer.SerializeToUtf8Bytes(entity);
        }

        /// <summary>
        /// Serialize for debug purposes, formatted. Does not ignore readonly properties or null values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string Debug<T>(T entity)
        {
            var options = new JsonSerializerOptions { WriteIndented = true, IgnoreReadOnlyProperties = false, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
            options.Converters.Add(new JsonStringEnumConverter());

            return JsonSerializer.Serialize(entity, options);
        }

        /// <summary>
        /// Deserialize (allows trailing commas, ignores comments, is case insensitive to property names, and ignores null values)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string json)
        {
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                ReadCommentHandling = JsonCommentHandling.Skip,
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            options.Converters.Add(new JsonStringEnumConverter());

            return JsonSerializer.Deserialize<T>(json, options) ?? throw new InvalidOperationException();
        }

        /// <summary>
        /// Deserialize to UTF8 bytes, used in place of BinaryFormatter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonUtf8Bytes"></param>
        /// <returns></returns>
        public static T DeserializeFromUtf8Bytes<T>(ReadOnlySpan<byte> jsonUtf8Bytes)
        {
            return JsonSerializer.Deserialize<T>(jsonUtf8Bytes) ?? throw new ArgumentNullException(nameof(jsonUtf8Bytes));
        }
        
        /// <summary>
        /// Formats a json string
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string JsonFormat(string json)
        {
            using JsonDocument jsonDocument = JsonDocument.Parse(json);
            using var memoryStream = new MemoryStream();
            var writer = new Utf8JsonWriter(memoryStream, new JsonWriterOptions { Indented = true });

            JsonElement root = jsonDocument.RootElement;

            if (root.ValueKind == JsonValueKind.Object)
            {
                writer.WriteStartObject();
            }
            else
            {
                return string.Empty;
            }

            foreach (JsonProperty property in root.EnumerateObject())
            {
                property.WriteTo(writer);
            }

            writer.WriteEndObject();

            writer.Flush();

            memoryStream.Position = 0;
            using var sr = new StreamReader(memoryStream);
            return sr.ReadToEnd();
        }
    }
}
