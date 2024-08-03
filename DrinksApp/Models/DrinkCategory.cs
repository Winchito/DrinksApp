using System.Text.Json.Serialization;


namespace DrinksApp.Models
{
    internal class DrinkCategory
    {
        [JsonPropertyName("idDrink")]
        public string Id { get; set; }
        [JsonPropertyName("strDrink")]
        public string Drink { get; set; }
    }
}
