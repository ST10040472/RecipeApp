using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            while (true)
            {
                Console.WriteLine("\nMENU");
                Console.WriteLine("1. Enter recipe");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset recipe");
                Console.WriteLine("5. Clear recipe");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        recipe.EnterRecipe();
                        break;

                    case 2:
                        recipe.DisplayRecipe();
                        break;

                    case 3:
                        Console.Write("Enter the scale factor: ");
                        double factor = double.Parse(Console.ReadLine());
                        recipe.ScaleRecipe(factor);
                        break;

                    case 4:
                        recipe.ResetRecipe();
                        break;

                    case 5:
                        recipe.ClearRecipe();
                        break;

                    case 6:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}
