using System.Text.Json.Serialization;


namespace DrinksApp.Models
{
    internal class CocktailCategory
    {
        [JsonPropertyName("strCategory")]
        public string Category { get; set; }
    }
}
