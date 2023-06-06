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
            RecipeManager recipeManager = new RecipeManager();

            while (true)
            {
                Console.WriteLine("\nMENU");
                Console.WriteLine("1. Enter recipe");
                Console.WriteLine("2. Display recipes");
                Console.WriteLine("3. Select recipe");
                Console.WriteLine("4. Calculate total calories");
                Console.WriteLine("5. Scale recipe");
                Console.WriteLine("6. Reset recipe");
                Console.WriteLine("7. Clear recipe");
                Console.WriteLine("8. Exit");

                Console.Write("Enter your choice: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice! Please enter a valid menu option.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        recipeManager.EnterRecipe();
                        break;

                    case 2:
                        recipeManager.DisplayRecipes();
                        break;

                    case 3:
                        Console.Write("Enter the recipe number: ");
                        int recipeNumber;
                        if (!int.TryParse(Console.ReadLine(), out recipeNumber))
                        {
                            Console.WriteLine("Invalid recipe number! Please enter a valid recipe number.");
                            continue;
                        }
                        recipeManager.SelectRecipe(recipeNumber);
                        break;

                    case 4:
                        recipeManager.CalculateTotalCalories();
                        break;

                    case 5:
                        Console.Write("Enter the scale factor: ");
                        double scale;
                        if (!double.TryParse(Console.ReadLine(), out scale) || scale <= 0)
                        {
                            Console.WriteLine("Invalid scale factor! Please enter a valid number greater than 0.");
                            continue;
                        }
                        recipeManager.ScaleRecipe(scale);
                        break;

                    case 6:
                        recipeManager.ResetRecipe();
                        break;

                    case 7:
                        recipeManager.ClearRecipe();
                        break;

                    case 8:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please enter a valid menu option.");
                        break;
                }
            }
        }
    }
}
