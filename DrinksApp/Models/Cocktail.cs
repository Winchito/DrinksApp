using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace DrinksApp.Models
{
    internal class Cocktail
    {
        [JsonPropertyName("drinks")]
        public List<CocktailCategory> Cocktails { get; set; }
    }
}
