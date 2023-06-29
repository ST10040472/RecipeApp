using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace RecipeApp
{
    public class Recipe
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
                ingredient.Calories *= factor;
            }
        }

       

        public string GetRecipeDetails()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"Name: {Name}");

            builder.AppendLine("Ingredients:");
            foreach (Ingredients ingredient in Ingredients)
            {
                builder.AppendLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
                builder.AppendLine($"  Calories: {ingredient.Calories}");
                builder.AppendLine($"  Food Group: {ingredient.FoodGroup}");
            }

            builder.AppendLine("\nSteps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                builder.AppendLine($"{i + 1}. {Steps[i]}");
            }

            return builder.ToString();
        }
    }
}
