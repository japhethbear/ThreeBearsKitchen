using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace ThreeBearsKitchen.Models
{
    public class Recipe
    {
        // Properties

        [Key]
        public int RecipeId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
        public string RecipeName { get; set; }

        [Required(ErrorMessage = "Meal is required")]
        public string RecipeMeal { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public List<Instruction> Instructions { get; set; }

        // **** REMOVE THE EMPTY STRING EXCEPTION WHEN USERS ARE CREATED
        [Required(AllowEmptyStrings = true, ErrorMessage = "No User Associated With This Recipe.")]
        public string UserId { get; set; } // Reference to the user who created the recipe

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }

    public class Ingredient

    {
        // Properties

        [Key]
        public int IngredientID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
        public string IngredientName { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [MinLength(2, ErrorMessage = "Amount must be at least 2 characters long")]
        public string IngredientAmount { get; set; }

        public int RecipeID { get; set; }
        public Recipe? Recipe { get; set; }

    }

    public class Instruction
    {
        // Properties

        [Key]
        public int InstructionID { get; set; }

        [Required(ErrorMessage = "Description required")]
        [MinLength(2, ErrorMessage = "Description must be at least 2 characters long")]
        public string Description { get; set; }

        public int RecipeID { get; set; }
        public Recipe? Recipe { get; set; }

    }

}

