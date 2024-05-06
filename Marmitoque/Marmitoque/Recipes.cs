using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Marmitoque
{
    public class qIngredient
    {
        public Ingredient Ingredient { get; set; }

        public float Quantity { get; set; }



        public qIngredient(Ingredient ingredient, float quantity)
        {
            Ingredient = ingredient;
            Quantity = quantity;
        }
    }
    public class Recipe
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Steps> Steps { get; set; }

        // The float represents the quantity needed for the recipe, it follows this logic :
        // 0 : Undefined quantity
        // <0 : number of items
        // >0 : quantity (in gramme)
        public List<qIngredient> Ingredients { get; set; }
        public float CookTime { get; set; }

        public float Price { get; set; }

        public float Calories { get; set; }

        public string ImagePath { get; set; }

        public List<string> Tags { get; set; }

        public float AdjustedPrice { get; set; }

        
       
        
        public Recipe(string name, string description, List<Steps> steps, List<qIngredient> ingredients, float cookTime, string imagePath, float price, float calories, List<string> tags)
        {
            Name = name;
            Description = description;
            Steps = steps;
            Ingredients = ingredients;
            CookTime = cookTime;
            ImagePath = imagePath;
            Price = price;
            Calories = calories;
            Tags = tags;    
            AdjustedPrice = price;
        }
        public void Recalculate(int New)
        {
            AdjustedPrice = (Price * New / 4);
        }
    }
}
