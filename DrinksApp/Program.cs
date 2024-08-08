using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            bool exit = false;
            string userOptionForFilter = "";
            string userOptionForDetails;

            while (!exit)
            {
                await DrinkService.GetCategories();

                userOptionForFilter = UserInput.GetUserInput();

                exit = await DrinkService.FilterByCategory(userOptionForFilter);
            }

            exit = false;

            while (!exit)
            {
                userOptionForDetails = UserInput.GetUserInput();

                try
                {
                    exit = await DrinkService.GetDrinkDetails(userOptionForDetails);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await DrinkService.FilterByCategory(userOptionForFilter);
                }

            }

        }
    }
}
