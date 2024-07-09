using System.Text.Json.Serialization;

namespace ChooseYourDrink.BLL.BusinessObjects
{
    public class DrinkItemBO
    {
        [JsonPropertyName("idDrink")]
        public string DrinkId { get; set; } = string.Empty;

        [JsonPropertyName("strDrink")]
        public string DrinkName { get; set; } = string.Empty;

        [JsonPropertyName("strDrinkThumb")]
        public string ThumbUrl { get; set; } = string.Empty;

        [JsonPropertyName("strDrinkAlternate")]
        public string Alternate { get; set; } = string.Empty;

        [JsonPropertyName("strTags")]
        public string Tags { get; set; } = string.Empty;

        [JsonPropertyName("strVideo")]
        public string Video { get; set; } = string.Empty;

        [JsonPropertyName("strCategory")]
        public string Category { get; set; } = string.Empty;

        [JsonPropertyName("strIBA")]
        public string IBA { get; set; } = string.Empty;

        [JsonPropertyName("strAlcoholic")]
        public string Alcoholic { get; set; } = string.Empty;

        [JsonPropertyName("strGlass")]
        public string Glass { get; set; } = string.Empty;

        [JsonPropertyName("strInstructions")]
        public string Instructions { get; set; } = string.Empty;

        [JsonPropertyName("strInstructionsES")]
        public string InstructionsES { get; set; } = string.Empty;

        [JsonPropertyName("strInstructionsDE")]
        public string InstructionsDE { get; set; } = string.Empty;

        [JsonPropertyName("strInstructionsFR")]
        public string InstructionsFR { get; set; } = string.Empty;

        [JsonPropertyName("strInstructionsIT")]
        public string InstructionsIT { get; set; } = string.Empty;

        [JsonPropertyName("strInstructionsZH-HANS")]
        public string InstructionsZHHANS { get; set; } = string.Empty;

        [JsonPropertyName("strInstructionsZH-HANT")]
        public string InstructionsZHHANT { get; set; } = string.Empty;

        [JsonPropertyName("strImageSource")]
        public string ImageSource { get; set; } = string.Empty;

        [JsonPropertyName("strImageAttribution")]
        public string ImageAttribution { get; set; } = string.Empty;

        [JsonPropertyName("strCreativeCommonsConfirmed")]
        public string CreativeCommonsConfirmed { get; set; } = string.Empty;

        [JsonPropertyName("dateModified")]
        public string dateModified { get; set; } = string.Empty;


        #region Ingredients 

        [JsonPropertyName("strIngredient1")]
        public string Ingredient1 { get; set; } = string.Empty;

        [JsonPropertyName("strIngredient2")]
        public string Ingredient2 { get; set; } = string.Empty;

        [JsonPropertyName("strIngredient3")]
        public string Ingredient3 { get; set; } = string.Empty;

        [JsonPropertyName("strIngredient4")]
        public string Ingredient4 { get; set; } = string.Empty;

        [JsonPropertyName("strIngredient5")]
        public string Ingredient5 { get; set; } = string.Empty;

        [JsonPropertyName("strIngredient6")]
        public string Ingredient6 { get; set; } = string.Empty;

        [JsonPropertyName("strIngredient7")]
        public string Ingredient7 { get; set; } = string.Empty;

        [JsonPropertyName("strIngredient8")]
        public string Ingredient8 { get; set; } = string.Empty;

        [JsonPropertyName("strIngredient9")]
        public string Ingredient9 { get; set; } = string.Empty;

        [JsonPropertyName("strIngredient10")]
        public string Ingredient10 { get; set; } = string.Empty;

        [JsonPropertyName("strIngredient11")]
        public string Ingredient11 { get; set; } = string.Empty;

        [JsonPropertyName("strIngredient12")]
        public string Ingredient12 { get; set; } = string.Empty;

        [JsonPropertyName("strIngredient13")]
        public string Ingredient13 { get; set; } = string.Empty;

        [JsonPropertyName("strIngredient14")]
        public string Ingredient14 { get; set; } = string.Empty;

        [JsonPropertyName("strIngredient15")]
        public string Ingredient15 { get; set; } = string.Empty;
        #endregion


        #region Measures

        [JsonPropertyName("strMeasure1")]
        public string Measure1 { get; set; } = string.Empty;

        [JsonPropertyName("strMeasure2")]
        public string Measure2 { get; set; } = string.Empty;

        [JsonPropertyName("strMeasure3")]
        public string Measure3 { get; set; } = string.Empty;

        [JsonPropertyName("strMeasure4")]
        public string Measure4 { get; set; } = string.Empty;

        [JsonPropertyName("strMeasure5")]
        public string Measure5 { get; set; } = string.Empty;

        [JsonPropertyName("strMeasure6")]
        public string Measure6 { get; set; } = string.Empty;

        [JsonPropertyName("strMeasure7")]
        public string Measure7 { get; set; } = string.Empty;

        [JsonPropertyName("strMeasure8")]
        public string Measure8 { get; set; } = string.Empty;

        [JsonPropertyName("strMeasure9")]
        public string Measure9 { get; set; } = string.Empty;

        [JsonPropertyName("strMeasure10")]
        public string Measure10 { get; set; } = string.Empty;

        [JsonPropertyName("strMeasure11")]
        public string Measure11 { get; set; } = string.Empty;

        [JsonPropertyName("strMeasure12")]
        public string Measure12 { get; set; } = string.Empty;

        [JsonPropertyName("strMeasure13")]
        public string Measure13 { get; set; } = string.Empty;

        [JsonPropertyName("strMeasure14")]
        public string Measure14 { get; set; } = string.Empty;

        [JsonPropertyName("strMeasure15")]
        public string Measure15 { get; set; } = string.Empty;

        #endregion

        public IEnumerable<string> Ingredients
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Ingredient1)) yield return $"{Measure1} {Ingredient1}";
                if (!string.IsNullOrWhiteSpace(Ingredient2)) yield return $"{Measure2} {Ingredient2}";
                if (!string.IsNullOrWhiteSpace(Ingredient3)) yield return $"{Measure3} {Ingredient3}";
                if (!string.IsNullOrWhiteSpace(Ingredient4)) yield return $"{Measure4} {Ingredient4}";
                if (!string.IsNullOrWhiteSpace(Ingredient5)) yield return $"{Measure5} {Ingredient5}";
                if (!string.IsNullOrWhiteSpace(Ingredient6)) yield return $"{Measure6} {Ingredient6}";
                if (!string.IsNullOrWhiteSpace(Ingredient7)) yield return $"{Measure7} {Ingredient7}";
                if (!string.IsNullOrWhiteSpace(Ingredient8)) yield return $"{Measure8} {Ingredient8}";
                if (!string.IsNullOrWhiteSpace(Ingredient9)) yield return $"{Measure9} {Ingredient9}";
                if (!string.IsNullOrWhiteSpace(Ingredient10)) yield return $"{Measure10} {Ingredient10}";
                if (!string.IsNullOrWhiteSpace(Ingredient11)) yield return $"{Measure11} {Ingredient11}";
                if (!string.IsNullOrWhiteSpace(Ingredient12)) yield return $"{Measure12} {Ingredient12}";
                if (!string.IsNullOrWhiteSpace(Ingredient13)) yield return $"{Measure13} {Ingredient13}";
                if (!string.IsNullOrWhiteSpace(Ingredient14)) yield return $"{Measure14} {Ingredient14}";
                if (!string.IsNullOrWhiteSpace(Ingredient15)) yield return $"{Measure15} {Ingredient15}";
            }
        }
    }

}
