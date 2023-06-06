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
                Console.WriteLine("3. Select recipe");
                Console.WriteLine("4. Scale recipe");
                Console.WriteLine("5. Reset recipe");
                Console.WriteLine("6. Clear recipe");
                Console.WriteLine("7. Display total calories of selected recipe");
                Console.WriteLine("8. Exit");

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
                        Console.Write("Enter the recipe number: ");
                        int recipeNumber;
                        if (!int.TryParse(Console.ReadLine(), out recipeNumber))
                        {
                            Console.WriteLine("Invalid recipe number! Please enter a valid recipe number.");
                            continue;
                        }
                        recipe.SelectRecipe(recipeNumber);
                        break;

                    case 4:
                        Console.Write("Enter the scale factor: ");
                        double factor = double.Parse(Console.ReadLine());
                        recipe.ScaleRecipe(factor);
                        break;

                    case 5:
                        recipe.ResetRecipe();
                        break;

                    case 6:
                        recipe.ClearRecipe();
                        break;

                    case 7:
                        recipe.DisplayTotalCalories();
                        break;

                    case 8:
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
