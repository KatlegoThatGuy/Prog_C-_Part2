# Prog_C-_Part2

Recipe Application

Introduction
Welcome to the Recipe Application! This is a simple console-based recipe management application written in C#. It allows users to create, manage, and manipulate recipes, including adding ingredients and steps, scaling recipes, and resetting quantities.

Features
Add ingredients and steps to a recipe.
Display the recipe with original quantities or scaled quantities.
Scale the recipe by a given factor.
Reset quantities to original values.
Clear all data.

Example
Here is an example of how to use the application:

Enter Ingredients:

Enter the number of ingredients.
For each ingredient, enter its name, quantity, and unit.
Display Recipe:

View the current recipe with ingredients and steps.
Scale Recipe:

Enter a scale factor to adjust ingredient quantities.
Reset Quantity:

Reset ingredient quantities to their original values.
Clear All Data:

Clear all recipes and start fresh.
Exit:

Exit the application.


Sure, here's an enhanced version of your README file:

Recipe Application
Recipe Application

Introduction
Welcome to the Recipe Application! This is a simple console-based recipe management application written in C#. It allows users to create, manage, and manipulate recipes, including adding ingredients and steps, scaling recipes, and resetting quantities.

Features
Add ingredients and steps to a recipe.
Display the recipe with original quantities or scaled quantities.
Scale the recipe by a given factor.
Reset quantities to original values.
Clear all data.
Usage
Clone the Repository:

bash
Copy code
git clone https://github.com/KatlegoThatGuy/ST10239864.git
Navigate to the project directory:

bash
Copy code
cd ST10239864
Compile and Run:

arduino
Copy code
dotnet run
Follow the on-screen prompts to interact with the application.

Example
Here is an example of how to use the application:

Enter Ingredients:

Enter the number of ingredients.
For each ingredient, enter its name, quantity, and unit.
Display Recipe:

View the current recipe with ingredients and steps.
Scale Recipe:

Enter a scale factor to adjust ingredient quantities.
Reset Quantity:

Reset ingredient quantities to their original values.
Clear All Data:

Clear all recipes and start fresh.
Exit:

Exit the application.
Classes
Recipe
Represents a recipe with ingredients and steps. 
Provides methods to add ingredients and steps, display the recipe, 
scale the recipe, reset quantities, and clear all data.

Ingredient
Represents an ingredient with a name, quantity, unit, calories, 
and food group.

Step
Represents a step in the recipe with a description.

Changes Made
Based on feedback from the lecturer, the following changes were made:

Refactored code to use generic collections instead of 
arrays for storing recipes, ingredients, and steps.

Added functionality for users to enter calories and 
food groups for ingredients.
Implemented calculation and display of total calories for recipes.

Added a warning when the total calories of a recipe exceed 300.

Updated the README file to include instructions, 
link to the GitHub repository, and a brief description of changes.

License
This project is licensed under the MIT License. 
See the LICENSE file for details.

Contact
For questions or feedback, please reach out to Katlego-Sebona/ST10239864
