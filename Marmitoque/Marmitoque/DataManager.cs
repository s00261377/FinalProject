using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Windows.Shapes;
using System.Windows.Input;
using System.Diagnostics;
namespace Marmitoque
{
    public class DataManager
    {
        public static void SaveAll(List<Recipe> LoadedRecipes)
        {
            string allRecipes = "";
            foreach(var recipe in LoadedRecipes)
            {
                string json = JsonConvert.SerializeObject(recipe);
                allRecipes += json + "\n";
            }
            File.WriteAllText("Recipes/save.json", allRecipes);
        }

        

        public static void LoadAll(List<Recipe> LoadedRecipes)
        {
            var lines = File.ReadLines("Recipes/save.json");
            foreach (var line in lines)
            {
                Recipe temp = JsonConvert.DeserializeObject<Recipe>(line);
                LoadedRecipes.Add(temp);
            }
        }

    }
}
