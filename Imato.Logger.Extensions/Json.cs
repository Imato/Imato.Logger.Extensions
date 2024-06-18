using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imato.Logger.Extensions
{
    internal static class Json
    {
        static Json()
        {
            JSON_OPTIONS.Converters.Add(new JsonStringEnumConverter());
        }

        public static JsonSerializerOptions JSON_OPTIONS = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.Never,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };

        public static T Deserialize<T>(string? json)
        {
            if (!string.IsNullOrEmpty(json))
            {
                try
                {
                    return JsonSerializer.Deserialize<T>(json, JSON_OPTIONS);
                }
                catch { }
            }

            return default;
        }

        public static string Serialize<T>(T value)
        {
            if (value == null) return "null";
            return JsonSerializer.Serialize(value, JSON_OPTIONS);
        }

        public static string Serialize(this object obj)
        {
            if (obj == null)
            {
                return "null";
            }
            if (obj.GetType().IsValueType || obj.GetType() == typeof(string))
            {
                return obj.ToString();
            }
            return Serialize(obj);
        }
    }
}