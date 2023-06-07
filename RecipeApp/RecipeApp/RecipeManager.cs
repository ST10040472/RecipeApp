using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    public class RecipeManager
    {
        private List<Recipe> recipes;
        private int selectedRecipeIndex;

        public RecipeManager()
        {
            recipes = new List<Recipe>();
            selectedRecipeIndex = -1;
        }

        public void EnterRecipe()
        {
            Recipe recipe = new Recipe();

            Console.Write("Enter the name of the recipe: ");
            recipe.Name = Console.ReadLine();

            Console.Write("Enter the number of ingredients in the recipe: ");
            int ingredientCount;
            if (!int.TryParse(Console.ReadLine(), out ingredientCount) || ingredientCount <= 0)
            {
                Console.WriteLine("Invalid ingredient count! Please enter a valid number.");
                return;
            }

            for (int i = 0; i < ingredientCount; i++)
            {
                Ingredients ingredient = new Ingredients();

                Console.Write($"Enter the name of ingredient {i + 1}: ");
                ingredient.Name = Console.ReadLine();

                Console.Write($"Enter the quantity of {ingredient.Name}: ");
                double quantity;
                if (!double.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                {
                    Console.WriteLine("Invalid quantity! Please enter a valid number.");
                    return;
                }
                ingredient.Quantity = quantity;

                Console.Write($"Enter the unit of measurement of {ingredient.Name}: ");
                ingredient.Unit = Console.ReadLine();

                Console.Write($"Enter the number of calories for {ingredient.Name}: ");
                double calories;
                if (!double.TryParse(Console.ReadLine(), out calories) || calories <= 0)
                {
                    Console.WriteLine("Invalid calories! Please enter a valid number.");
                    return;
                }
                ingredient.Calories = calories;

                Console.Write($"Enter the food group for {ingredient.Name}: ");
                ingredient.FoodGroup = Console.ReadLine();

                recipe.Ingredients.Add(ingredient);
            }

            Console.Write("Enter the number of steps: ");
            int stepCount;
            if (!int.TryParse(Console.ReadLine(), out stepCount) || stepCount <= 0)
            {
                Console.WriteLine("Invalid step count! Please enter a valid number.");
                return;
            }

            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                recipe.Steps.Add(Console.ReadLine());
            }

            recipes.Add(recipe);
        }

        public void DisplayRecipes()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found");
            }
            else
            {
                List<Recipe> sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
                Console.WriteLine("Recipes:");
                for (int i = 0; i < sortedRecipes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {sortedRecipes[i].Name}");
                }
            }
        }

        public void SelectRecipe(int recipeNumber)
        {
            if (recipeNumber < 1 || recipeNumber > recipes.Count)
            {
                Console.WriteLine("Invalid recipe number!");
            }
            else
            {
                selectedRecipeIndex = recipeNumber - 1;
                Recipe selectedRecipe = recipes[selectedRecipeIndex];
                selectedRecipe.DisplayRecipe();
                double totalCalories = selectedRecipe.CalculateTotalCalories();
                if (totalCalories > 300)
                {
                    Console.WriteLine("Warning: This recipe exceeds 300 calories!");
                }
            }
        }

        public void CalculateTotalCalories()
        {
            if (selectedRecipeIndex == -1)
            {
                Console.WriteLine("No recipe selected!");
            }
            else
            {
                Recipe selectedRecipe = recipes[selectedRecipeIndex];
                double totalCalories = selectedRecipe.CalculateTotalCalories();
                Console.WriteLine($"Total calories of {selectedRecipe.Name}: {totalCalories}");
            }
        }

        public void ScaleRecipe(double scale)
        {
            if (selectedRecipeIndex == -1)
            {
                Console.WriteLine("No recipe selected!");
            }
            else
            {
                Recipe selectedRecipe = recipes[selectedRecipeIndex];
                selectedRecipe.ScaleRecipe(scale);
                Console.WriteLine($"Recipe scaled by a factor of {scale}");
            }
        }

        public void ResetRecipe()
        {
            if (selectedRecipeIndex == -1)
            {
                Console.WriteLine("No recipe selected!");
            }
            else
            {
                Recipe selectedRecipe = recipes[selectedRecipeIndex];
                selectedRecipe.ResetRecipe();
                Console.WriteLine("Recipe reset to original quantities");
            }
        }

        public void ClearRecipe()
        {
            if (selectedRecipeIndex == -1)
            {
                Console.WriteLine("No recipe selected!");
            }
            else
            {
                recipes.RemoveAt(selectedRecipeIndex);
                selectedRecipeIndex = -1;
                Console.WriteLine("Recipe cleared");
            }
        }
    }
}
