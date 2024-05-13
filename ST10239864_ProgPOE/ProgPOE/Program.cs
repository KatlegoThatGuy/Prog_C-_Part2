using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApplication
{
    class Recipe
    {
        // Properties
        public List<Ingredient> Ingredients { get; private set; }
        public List<Step> Steps { get; private set; }
        public string Name { get; set; }
        private List<double> OriginalIngredientQuantities { get; set; }
        private Dictionary<double, List<Ingredient>> ScaledIngredients { get; set; }
        private bool IsScaled { get; set; } // Flag to track whether the recipe has been scaled

        // Constructor
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
            OriginalIngredientQuantities = new List<double>();
            ScaledIngredients = new Dictionary<double, List<Ingredient>>();
            IsScaled = false; // Initialize as not scaled
        }

        // Method to display the entire recipe
        public void DisplayRecipe()
        {
            DisplayRecipe(1);
            int totalCalories = CalculateTotalCalories();
            Console.WriteLine($"Total Calories: {totalCalories}");

            if (totalCalories > 300)
            {
                Console.WriteLine("Warning: Total calories exceed 300!");
            }
        }

        // Method to display the recipe with a given scale factor
        public void DisplayRecipe(double scaleFactor)
        {
            Console.WriteLine($"\nRecipe: {Name}");
            Console.WriteLine("Ingredients:");

            if (scaleFactor == 1 || !ScaledIngredients.ContainsKey(scaleFactor))
            {
                for (int i = 0; i < Ingredients.Count; i++)
                {
                    Ingredients[i].Quantity = OriginalIngredientQuantities[i] * scaleFactor;
                    Console.WriteLine($"- {Ingredients[i].Quantity} {Ingredients[i].Unit} {Ingredients[i].Name}");
                }
            }
            else
            {
                var scaledIngredients = ScaledIngredients[scaleFactor];
                foreach (var ingredient in scaledIngredients)
                {
                    Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} {ingredient.Name}");
                }
            }

            Console.WriteLine("Steps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i].Description}");
            }
        }

        // Method to add ingredients
        public void AddIngredient(string name, double quantity, string unit)
        {
            Console.Write("Enter the number of calories: ");
            int calories = int.Parse(Console.ReadLine());
            Console.Write("Enter the food group: ");
            string foodGroup = Console.ReadLine();

            Ingredients.Add(new Ingredient { Name = name, Quantity = quantity, Unit = unit, Calories = calories, FoodGroup = foodGroup });
            OriginalIngredientQuantities.Add(quantity);
        }

        // Method to add steps
        public void AddStep(string description)
        {
            Steps.Add(new Step { Description = description });
        }

        // Method to reset quantities to original values and set scale factor to 1
        public void ResetQuantity()
        {
            for (int i = 0; i < Ingredients.Count; i++)
            {
                Ingredients[i].Quantity = OriginalIngredientQuantities[i];
            }
            ScaledIngredients.Clear();
            IsScaled = false; // Reset scaled flag
        }

        // Method to scale the recipe by a given factor
        public void ScaleRecipe(double factor)
        {
            var scaledIngredients = new List<Ingredient>();
            foreach (var ingredient in Ingredients)
            {
                scaledIngredients.Add(new Ingredient { Name = ingredient.Name, Quantity = ingredient.Quantity * factor, Unit = ingredient.Unit });
            }
            ScaledIngredients[factor] = scaledIngredients;
            IsScaled = true; // Set scaled flag
        }

        // Method to display the scaled recipe
        public void DisplayScaledRecipe()
        {
            if (IsScaled)
            {
                Console.WriteLine("Scaled Recipes:");
                foreach (var entry in ScaledIngredients)
                {
                    Console.WriteLine($"- Scale Factor: {entry.Key}");
                    DisplayRecipe(entry.Key);
                }

                Console.Write("Enter the scale factor to display the recipe: ");
                if (double.TryParse(Console.ReadLine(), out double scaleFactor))
                {
                    if (ScaledIngredients.ContainsKey(scaleFactor))
                    {
                        Console.WriteLine($"Scaled Recipe for Scale Factor {scaleFactor}:");
                        DisplayRecipe(scaleFactor);
                    }
                    else
                    {
                        Console.WriteLine("Scaled recipe not found for the specified scale factor.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid scale factor.");
                }
            }
            else
            {
                Console.WriteLine("Recipe has not been scaled yet.");
            }
        }

        // Method to calculate total calories
        public int CalculateTotalCalories()
        {
            int totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }
    }

    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; } // New property for calories
        public string FoodGroup { get; set; } // New property for food group
    }

    class Step
    {
        public string Description { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Recipe Application!");
            List<Recipe> recipes = new List<Recipe>();
            bool isRecipeScaled = false; // Flag to track whether a recipe has been scaled

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("1. Enter Recipe");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("2. Display Recipes");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("3. Scale Recipe");

                if (isRecipeScaled) // Only show this option if a recipe has been scaled
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("4. Display Scaled Recipe");
                }

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("5. Reset Quantity");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("6. Clear All Data");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("7. Exit");
                Console.ResetColor();
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                int num;
                if (int.TryParse(choice, out num))
                {
                    switch (num)
                    {
                        case 1:
                            Recipe recipe = new Recipe();
                            Console.Write("Enter recipe name: ");
                            recipe.Name = Console.ReadLine();

                            Console.Write("Enter the number of ingredients: ");
                            if (int.TryParse(Console.ReadLine(), out int numIngredients))
                            {
                                for (int i = 0; i < numIngredients; i++)
                                {
                                    Console.WriteLine($"Enter ingredient {i + 1}:");
                                    Console.Write("Name: ");
                                    string name = Console.ReadLine();
                                    Console.Write("Quantity: ");
                                    double quantity = double.Parse(Console.ReadLine());
                                    Console.Write("Unit: ");
                                    string unit = Console.ReadLine();

                                    recipe.AddIngredient(name, quantity, unit);
                                }

                                bool validNumSteps = false;
                                int numSteps = 0;
                                while (!validNumSteps)
                                {
                                    Console.Write("Enter the number of steps: ");
                                    if (int.TryParse(Console.ReadLine(), out numSteps))
                                    {
                                        validNumSteps = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input. Please enter a valid number of steps.");
                                    }
                                }

                                for (int i = 0; i < numSteps; i++)
                                {
                                    Console.WriteLine($"Enter step {i + 1}:");
                                    recipe.AddStep(Console.ReadLine());
                                }
                                recipes.Add(recipe);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number of ingredients.");
                            }
                            break;


                        case 2:
                            if (recipes.Any())
                            {
                                var sortedRecipes = recipes.OrderBy(r => r.Name);
                                foreach (var r in sortedRecipes)
                                {
                                    r.DisplayRecipe();
                                }
                            }
                            else
                            {
                                Console.WriteLine("No recipes to display.");
                            }
                            break;

                        case 3:
                            if (recipes.Any())
                            {
                                Console.Write("Enter recipe name to scale: ");
                                string recipeName = Console.ReadLine();
                                var recipeToScale = recipes.FirstOrDefault(r => r.Name == recipeName);
                                if (recipeToScale != null)
                                {
                                    Console.Write("Enter scale factor (0.5, 2, or 3): ");
                                    if (double.TryParse(Console.ReadLine(), out double scaleFactor))
                                    {
                                        recipeToScale.ScaleRecipe(scaleFactor);
                                        isRecipeScaled = true; // Update scaled flag
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input. Please enter a valid scale factor.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Recipe not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No recipes available to scale.");
                            }
                            break;

                        case 4:
                            if (recipes.Any() && isRecipeScaled)
                            {
                                Console.Write("Enter recipe name to display scaled recipe: ");
                                string recipeName = Console.ReadLine();
                                var recipeToDisplayScaled = recipes.FirstOrDefault(r => r.Name == recipeName);
                                if (recipeToDisplayScaled != null)
                                {
                                    recipeToDisplayScaled.DisplayScaledRecipe();
                                }
                                else
                                {
                                    Console.WriteLine("Recipe not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No recipes available to display.");
                            }
                            break;

                        case 5:
                            if (recipes.Any())
                            {
                                Console.Write("Enter recipe name to reset quantity: ");
                                string recipeName = Console.ReadLine();
                                var recipeToReset = recipes.FirstOrDefault(r => r.Name == recipeName);
                                if (recipeToReset != null)
                                {
                                    recipeToReset.ResetQuantity();
                                    isRecipeScaled = false; // Reset scaled flag
                                }
                                else
                                {
                                    Console.WriteLine("Recipe not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No recipes available to reset quantity.");
                            }
                            break;

                        case 6:
                            recipes.Clear();
                            Console.WriteLine("All data cleared.");
                            break;

                        case 7:
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                }
            }
        }
    }
}
