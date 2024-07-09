using System.Text.Json.Serialization;

namespace ChooseYourDrink.Models
{
    public class DrinkCategoryViewModel
    {
        [JsonPropertyName("strCategory")]
        public string StrCategory { get; set; } = string.Empty;
    }
}
