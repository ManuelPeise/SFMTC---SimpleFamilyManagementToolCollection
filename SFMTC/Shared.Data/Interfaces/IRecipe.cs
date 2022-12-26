using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Shared.Data.Interfaces
{
    public interface IRecipe
    {
        public Guid RecipeId { get; set; }
        [MaxLength(50)]
        public string RecipeName { get; set; }
        [MaxLength(100)]
        public string ShortDescription { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string Category { get; set; }
    }

}
