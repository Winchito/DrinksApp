using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DrinksApp
{
    internal class UserInput
    {
        public static string GetUserInput()
        {
            Console.WriteLine("Select an Category option");
            string userInput = Console.ReadLine().ToLower().Trim().Replace(' ','_');

            return userInput;
        }
    }
}
