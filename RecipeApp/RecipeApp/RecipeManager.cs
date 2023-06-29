using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.VisualBasic;
using LiveCharts;
using LiveCharts.Wpf;



namespace RecipeApp
{
    public class RecipeManager
    {
        private List<Recipe> recipes;
        private int selectedRecipeIndex;
        public SeriesCollection FoodGroupPercentages { get; set; }
        public RecipeManager()
        {
            recipes = new List<Recipe>();
            selectedRecipeIndex = -1;
        }

        public void EnterRecipe()
        {
            Recipe recipe = new Recipe();

            recipe.Name = Interaction.InputBox("Enter the name of the recipe:");

            int ingredientCount;
            while (!int.TryParse(Interaction.InputBox("Enter the number of ingredients in the recipe:"), out ingredientCount) || ingredientCount <= 0)
            {
                MessageBox.Show("Invalid ingredient count! Please enter a valid number.");
            }

            for (int i = 0; i < ingredientCount; i++)
            {
                Ingredients ingredient = new Ingredients();

                ingredient.Name = Interaction.InputBox($"Enter the name of ingredient {i + 1}:");

                double quantity;
                while (!double.TryParse(Interaction.InputBox($"Enter the quantity of {ingredient.Name}: "), out quantity) || quantity <= 0)
                {
                    MessageBox.Show("Invalid quantity! Please enter a valid number.");
                }
                ingredient.Quantity = quantity;

                ingredient.Unit = Interaction.InputBox($"Enter the unit of measurement of {ingredient.Name}:");

                double calories;
                while (!double.TryParse(Interaction.InputBox($"Enter the number of calories for {ingredient.Name}: "), out calories) || calories <= 0)
                {
                    MessageBox.Show("Invalid calories! Please enter a valid number.");
                }
                ingredient.Calories = calories;

                List<string> foodGroups = new List<string>
                {
                    "Grains",
                    "Proteins",
                    "Fruits",
                    "Vegetables",
                    "Dairy",
                    "Fats and Oils",
                    "Sweets and Snacks"
                };

                int selectedFoodGroupIndex = -1;
                while (selectedFoodGroupIndex == -1)
                {
                    string foodGroupSelection = Interaction.InputBox($"Select the food group for {ingredient.Name}:\n" +
                        $"{string.Join("\n", foodGroups.Select((group, index) => $"{index + 1}. {group}"))}");

                    if (!int.TryParse(foodGroupSelection, out selectedFoodGroupIndex) || selectedFoodGroupIndex < 1 || selectedFoodGroupIndex > foodGroups.Count)
                    {
                        MessageBox.Show("Invalid food group selection! Please enter a valid number.");
                        selectedFoodGroupIndex = -1;
                    }
                }

                ingredient.FoodGroup = foodGroups[selectedFoodGroupIndex - 1];

                recipe.Ingredients.Add(ingredient);
            }

            int stepCount;
            while (!int.TryParse(Interaction.InputBox("Enter the number of steps:"), out stepCount) || stepCount <= 0)
            {
                MessageBox.Show("Invalid step count! Please enter a valid number.");
            }

            for (int i = 0; i < stepCount; i++)
            {
                recipe.Steps.Add(Interaction.InputBox($"Enter step {i + 1}:"));
            }

            recipes.Add(recipe);
        }

        public void DisplayRecipes()
        {
            if (recipes.Count == 0)
            {
                MessageBox.Show("No recipes found");
            }
            else
            {
                List<Recipe> sortedRecipes = recipes.OrderBy(r => r.Name).ToList();

                StringBuilder recipeList = new StringBuilder("Recipes:\n");
                for (int i = 0; i < sortedRecipes.Count; i++)
                {
                    recipeList.AppendLine($"{i + 1}. {sortedRecipes[i].Name}");
                }

                MessageBox.Show(recipeList.ToString());
            }
        }

        public void SelectRecipe(int recipeNumber)
        {
            if (recipeNumber < 1 || recipeNumber > recipes.Count)
            {
                MessageBox.Show("Invalid recipe number!");
            }
            else
            {
                selectedRecipeIndex = recipeNumber - 1;
                Recipe selectedRecipe = recipes[selectedRecipeIndex];
                selectedRecipe.DisplayRecipe();

                string recipeDetails = selectedRecipe.GetRecipeDetails();
                MessageBox.Show($"Selected Recipe:\n\n{recipeDetails}");

                double totalCalories = selectedRecipe.CalculateTotalCalories();
                if (totalCalories > 300)
                {
                    MessageBox.Show("Warning: This recipe exceeds 300 calories!");
                }
            }
        }

        public void CalculateTotalCalories()
        {
            if (selectedRecipeIndex == -1)
            {
                MessageBox.Show("No recipe selected!");
            }
            else
            {
                Recipe selectedRecipe = recipes[selectedRecipeIndex];
                double totalCalories = selectedRecipe.CalculateTotalCalories();
                MessageBox.Show($"Total calories of {selectedRecipe.Name}: {totalCalories}");
            }
        }

        public void ScaleRecipe(double scale)
        {
            if (selectedRecipeIndex == -1)
            {
                MessageBox.Show("No recipe selected!");
            }
            else
            {
                Recipe selectedRecipe = recipes[selectedRecipeIndex];
                selectedRecipe.ScaleRecipe(scale);
                MessageBox.Show($"Recipe scaled by a factor of {scale}");
            }
        }

        public void ResetRecipe(Action<string> showMessage, Func<string, string> getInput)
        {
            if (selectedRecipeIndex == -1)
            {
                showMessage("No recipe selected!");
                return;
            }

            Recipe selectedRecipe = recipes[selectedRecipeIndex];

            foreach (var ingredient in selectedRecipe.Ingredients)
            {
                string quantityInput = getInput($"Enter the quantity of {ingredient.Name}: ");
                double quantity;
                if (!double.TryParse(quantityInput, out quantity) || quantity <= 0)
                {
                    showMessage("Invalid quantity! Please enter a valid number.");
                    return;
                }
                ingredient.Quantity = quantity;

                string caloriesInput = getInput($"Enter the calories for {ingredient.Name}: ");
                double calories;
                if (!double.TryParse(caloriesInput, out calories) || calories <= 0)
                {
                    showMessage("Invalid calories! Please enter a valid number.");
                    return;
                }
                ingredient.Calories = calories;
            }
        }

        public void ClearRecipe()
        {
            if (selectedRecipeIndex == -1)
            {
                MessageBox.Show("No recipe selected!");
            }
            else
            {
                recipes.RemoveAt(selectedRecipeIndex);
                selectedRecipeIndex = -1;
                MessageBox.Show("Recipe cleared");
            }
        }





    }
}
