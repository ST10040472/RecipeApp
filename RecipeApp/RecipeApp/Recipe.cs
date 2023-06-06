using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    internal class Recipe
    {
        public string Name { get; set; }
        public List<Ingredients> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredients>();
            Steps = new List<string>();
        }

        public void DisplayRecipe()
        {
            Console.WriteLine($"Recipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"- {ingredient.Name} ({ingredient.Quantity} {ingredient.Unit}), {ingredient.Calories} calories, {ingredient.FoodGroup}");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
        }

        public double CalculateTotalCalories()
        {
            return Ingredients.Sum(ingredient => ingredient.Calories);
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetRecipe()
        {
            // Re-enter the quantities for each ingredient
            foreach (var ingredient in Ingredients)
            {
                Console.Write($"Enter the quantity of {ingredient.Name}: ");
                double quantity;
                if (!double.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                {
                    Console.WriteLine("Invalid quantity! Please enter a valid number.");
                    return;
                }
                ingredient.Quantity = quantity;
            }
        }
    }
}
