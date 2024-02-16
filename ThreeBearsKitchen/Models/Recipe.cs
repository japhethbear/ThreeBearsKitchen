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

        [Required(ErrorMessage = "Recipe meal is required")]
        public string RecipeMeal { get; set; }

        [Required(ErrorMessage = "At least one ingredient is required")]
        public string Ingredients { get; set; }

        [Required(ErrorMessage = "At least one instruction is required")]
        public string Instructions { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }

}

