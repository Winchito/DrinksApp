using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DrinksApp.Models
{
    internal class DrinkCategory
    {
        [JsonPropertyName("strCategory")]
        public string Category  { get; set; }
    }
}
