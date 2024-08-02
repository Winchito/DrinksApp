using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DrinksApp.Models;
using System.Text.Json;

namespace DrinksApp
{
    internal class DrinkService
    {
        private static readonly HttpClient client = new HttpClient();
        private const string BASEURL = "http://www.thecocktaildb.com/api/json/v1/1/";

        internal static async Task GetCategories()
        {
            string endPoint = "list.php?c=list";

            string requestUrl = $"{BASEURL}{endPoint}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Success");
                    //Console.WriteLine(responseData);

                    Drinks drinkCategories = JsonSerializer.Deserialize<Drinks>(responseData);

                    foreach (var drink in drinkCategories.drinks)
                    {
                        Console.WriteLine($"Category: {drink.Category}");
                    }
                }
                else
                {
                    Console.WriteLine("Error!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
