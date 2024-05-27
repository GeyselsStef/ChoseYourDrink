using System.Text.Json.Serialization;

namespace ChoseYourDrink.Models
{
    public class DrinkCategoryViewModel
    {
        [JsonPropertyName("strCategory")]
        public string StrCategory { get; set; } = string.Empty;
    }
}
