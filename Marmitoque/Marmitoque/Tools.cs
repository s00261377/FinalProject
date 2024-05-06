using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Marmitoque
{
    public static class Tools
    {
        private static Random rng = new Random();

        public static List<T> Randomize<T>(this List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }
        public static List<T> AlphabeticSort<T>(this List<T> list)
        {
            // Check if T has a property named "Name"
            var nameProperty = typeof(T).GetProperty("Name");
            
            // Sort the list alphabetically based on the "Name" property
            return list.OrderBy(item => (string)nameProperty.GetValue(item)).ToList();
        }

        public static List<Recipe> PriceSort(this List<Recipe> list)
        {
            return list.OrderBy(recipe => recipe.Price).ToList();
        }
        public static List<Recipe> CalorieSort(this List<Recipe> list)
        {
            return list.OrderBy(recipe => recipe.Calories).ToList();
        }
        public static string SplitString(string description, int maxCharacters)
        {
            StringBuilder sb = new StringBuilder();
            string[] words = description.Split(' ');

            int lineLength = 0;
            foreach (string word in words)
            {
                if (lineLength + word.Length <= maxCharacters)
                {
                    sb.Append(word + " ");
                    lineLength += word.Length + 1; // +1 for the space
                }
                else
                {
                    sb.AppendLine(); // Add a new line
                    sb.Append(word + " ");
                    lineLength = word.Length + 1; // Reset line length for the new line
                }
            }

            return sb.ToString();
        }
    }
}
