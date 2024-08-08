using System;
using System.Net.Http;
using System.Threading.Tasks;
using DrinksApp.Models;
using System.Text.Json;
using System.Reflection;
using System.Linq;

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
                return;
            }
        }

        internal static async Task<bool> FilterByCategory(string userInput)
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

                        Drink drinkCategories = JsonSerializer.Deserialize<Drink>(responseData);

                        foreach (var drink in drinkCategories.Drinks)
                        {
                            Console.WriteLine($"Id: {drink.Id} | Drink: {drink.Drink}");
                        }

                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
           }
        }

        internal static async Task<bool> GetDrinkDetails(string userInput)
        {
            string endPoint = "search.php?s=";

            string requestUrl = $"{BASEURL}{endPoint}{userInput}";

                using (HttpResponseMessage response = await client.GetAsync(requestUrl))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();

                        DrinkDetails drinksDetail = JsonSerializer.Deserialize<DrinkDetails>(responseData);

                        PrintDrinkDetails(drinksDetail);

                        return true;                     
                        }  
                    return false;
                }
        }

        private static void PrintDrinkDetails(DrinkDetails drinkDetails)
        {
            var properties = typeof(DrinkDetailsCategory).GetProperties();

            foreach (var drink in drinkDetails.drinkDetails)
            {
                Console.WriteLine($"Id: {drink.Id} | Drink Name: {drink.DrinkName} | Category: {drink.Category} | Alcoholic: {drink.IsAlcoholic} | Served in: {drink.IsServedIn} \nInstructions: {drink.Instructions}\nIngredients:");


                for (int i = 1; i <= 15; i++)
                {
                    string ingredientPropName = $"Ingredient{i}";
                    string measurePropName = $"Measure{i}";

                    //Get the ingredient and measure property using reflection
                    var ingredientProp = properties.FirstOrDefault(p => p.Name == ingredientPropName);
                    var measureProp = properties.FirstOrDefault(p => p.Name == measurePropName);


                    if (ingredientProp != null && measureProp != null)
                    {
                        //Get ingredient and measure values
                        string ingredient = ingredientProp.GetValue(drink) as string;
                        string measure = measureProp.GetValue(drink) as string;

                        if (!string.IsNullOrEmpty(ingredient) && !string.IsNullOrEmpty(measure))
                        {
                                Console.WriteLine($"{ingredient} - Measure:  {measure}");
                        }
                    }
                }
            }
        }

    }
}
