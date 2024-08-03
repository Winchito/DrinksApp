using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DrinksApp.Models
{
    internal class DrinkDetailsCategory
    {
        [JsonPropertyName("idDrink")]
        public string Id { get; set; }
        [JsonPropertyName("strDrink")]
        public string DrinkName { get; set; }
        [JsonPropertyName("strCategory")]
        public string Category { get; set; }
        [JsonPropertyName("strAlcoholic")]
        public string IsAlcoholic { get; set; }
        [JsonPropertyName("strGlass")]
        public string IsServedIn { get; set; }
        [JsonPropertyName("strIntructions")]
        public string Instructions { get; set; }
    }
}
