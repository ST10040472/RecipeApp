using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Tests
{
    [TestClass()]
    public class RecipeManagerTests
    {
        [TestMethod()]
        public void CalculateTotalCaloriesTest()
        {
            // Arrange
            Recipe recipe = new Recipe();
            Ingredients ingredient1 = new Ingredients
            {
                Name = "Ingredient 1",
                Quantity = 1,
                Unit = "cups",
                Calories = 100
            };
            Ingredients ingredient2 = new Ingredients
            {
                Name = "Ingredient 2",
                Quantity = 1,
                Unit = "tablespoon",
                Calories = 50
            };
            recipe.Ingredients.Add(ingredient1);
            recipe.Ingredients.Add(ingredient2);

            // Act
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(150, totalCalories);
        }
    }
}