using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DrinksApp.Models
{
    internal class Drink
    {
        [JsonPropertyName("drinks")]
        public List<DrinkCategory> Drinks { get; set; }
    }
}
