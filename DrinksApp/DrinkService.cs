using System;
using System.Net.Http;
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
                using(HttpResponseMessage response = await client.GetAsync(requestUrl))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Success");
                        //Console.WriteLine(responseData);

                        Cocktail cocktailCategories = JsonSerializer.Deserialize<Cocktail>(responseData);

                        foreach (var cocktail in cocktailCategories.Cocktails)
                        {
                            Console.WriteLine(cocktail.Category);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        internal static async Task FilterByCategory(string userInput)
        {
            string endPoint = "filter.php?c=";

            string requestUrl = $"{BASEURL}{endPoint}{userInput}";

            try
            {
            using (HttpResponseMessage response = await client.GetAsync(requestUrl))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Success");

                        Drink drinkCategories = JsonSerializer.Deserialize<Drink>(responseData);

                        foreach (var drink in drinkCategories.Drinks)
                        {
                            Console.WriteLine($"Id: {drink.Id} | Drink: {drink.Drink}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await GetCategories();
            }
        }
    }
}
