using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChooseYourDrink.Models
{
    public class DrinksCategoryConverter : BaseDrinksConverter<DrinkCategoryViewModel>
    {
    }

    public class DrinkItemConverter : BaseDrinksConverter<DrinkItemViewModel>
    {
    }

    public class BaseDrinksConverter<T> : JsonConverter<List<T>>

    {

        public override List<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            while (reader.TokenType != JsonTokenType.StartArray)
            {
                reader.Read();
            }

            var drinks = JsonSerializer.Deserialize<List<T>>(ref reader);
            while (reader.Read()) ;
            return drinks;
        }

        public override void Write(Utf8JsonWriter writer, List<T> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("drinks");
            JsonSerializer.Serialize(writer, value, options);
            writer.WriteEndObject();
        }
    }



}
