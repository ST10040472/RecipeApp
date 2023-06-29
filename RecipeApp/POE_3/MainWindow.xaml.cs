using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RecipeApp;
using Microsoft.VisualBasic;
using LiveCharts;
using LiveCharts.Wpf;


namespace POE_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RecipeManager recipeManager;
        public SeriesCollection FoodGroupPercentages { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            recipeManager = new RecipeManager();    
        }

        private void EnterRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            recipeManager.EnterRecipe();
        }

        private void DisplayRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            recipeManager.DisplayRecipes();
        }

        private void SelectRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(recipeNumberTextBox.Text, out int recipeNumber))
            {
                recipeManager.SelectRecipe(recipeNumber);
            }
            else
            {
                MessageBox.Show("Invalid recipe number! Please enter a valid number.");
            }
        }

        private void CalculateTotalCaloriesButton_Click(object sender, RoutedEventArgs e)
        {
            recipeManager.CalculateTotalCalories();
        }

        private void ScaleRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(scaleFactorTextBox.Text, out double scale))
            {
                recipeManager.ScaleRecipe(scale);
            }
            else
            {
                MessageBox.Show("Invalid scale factor! Please enter a valid number.");
            }
        }

        private void ResetRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            recipeManager.ResetRecipe(
                message => MessageBox.Show(message),  // Custom message display method using MessageBox
                prompt => Microsoft.VisualBasic.Interaction.InputBox(prompt)  // Custom input retrieval method using InputBox
            );
            
        }

        private void ClearRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            recipeManager.ClearRecipe();
        }

        
    }
}
