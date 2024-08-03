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

            await DrinkService.GetCategories();

            string userOption = UserInput.GetUserInput();

            Console.WriteLine(userOption);

            await DrinkService.FilterByCategory(userOption);

        }
    }
}
