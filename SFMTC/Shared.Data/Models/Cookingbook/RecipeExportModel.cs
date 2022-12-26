﻿using Shared.Data.Interfaces;

namespace Shared.Data.Models.Cookingbook
{
    public class RecipeExportModel : IRecipe
    {
        public Guid RecipeId { get; set; }
        public string RecipeName { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[] Image { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}