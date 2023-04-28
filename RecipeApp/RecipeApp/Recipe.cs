using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    internal class Recipe
    {
        private string[] ingredients;
        private string[] steps;

        public void EnterRecipe()
        {
            Console.Write("Enter the number of ingredients in recipe: ");
            int ingredientCount = int.Parse(Console.ReadLine());

            ingredients = new string[ingredientCount];
            for (int i = 0; i < ingredientCount; i++)
            {
                Console.Write($"Enter the name of ingredient {i + 1}: ");
                string name = Console.ReadLine();

                Console.Write($"Enter the quantity of {name}: ");
                string quantity = Console.ReadLine();

                Console.Write($"Enter the unit of measurement of {name}: ");
                string unit = Console.ReadLine();

                ingredients[i] = $"{quantity} {unit} of {name}";
            }

            Console.Write("Enter the number of steps: ");
            int stepCount = int.Parse(Console.ReadLine());

            steps = new string[stepCount];
            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                steps[i] = Console.ReadLine();
            }
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("Ingredients:");
            foreach (string ingredient in ingredients)
            {
                Console.WriteLine($"- {ingredient}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        public void ScaleRecipe(double factor)
        {
            Console.WriteLine($"Scaling recipe by a factor of {factor}");
            for (int i = 0; i < ingredients.Length; i++)
            {
                string[] parts = ingredients[i].Split(' ');
                double quantity = double.Parse(parts[0]) * factor;
                string unit = parts[1];
                string name = string.Join(" ", parts, 2, parts.Length - 2);
                ingredients[i] = $"{quantity} {unit} of {name}";
            }
        }

        public void ResetRecipe()
        {
            Console.WriteLine("Resetting recipe to original quantities");
            EnterRecipe();
        }

        public void ClearRecipe()
        {
            ingredients = null;
            steps = null;
        }
    }
}
