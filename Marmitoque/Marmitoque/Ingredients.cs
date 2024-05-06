using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marmitoque
{
    public class Ingredient
    {
        public string Name { get; set; }
        public string ImagePath {get; set;}

        public Ingredient(string Name, string imagePath)
        {
            this.Name = Name;
            ImagePath = imagePath;
        }
    }
    public static class Ingredients
    {
        static public Ingredient Salt = new Ingredient("Salt", "Images/salt.jpg");
        static public Ingredient Pepper = new Ingredient("Pepper", "Images/pepper.jpg");
        static public Ingredient Nutmeg = new Ingredient("Nutmeg", "Images/nutmeg.jpg");
        static public Ingredient Gruyere = new Ingredient("Gruyere", "Images/gruyere.jpg");
        static public Ingredient Ham = new Ingredient("Ham", "Images/ham.jpg");
        static public Ingredient Butter = new Ingredient("Butter", "Images/butter.jpg");
        static public Ingredient SlicedOfBread = new Ingredient("Slice of bread", "Images/sliceOfBread.jpg");
        static public Ingredient Cheddar = new Ingredient("Cheddar", "Images/cheddar.jpg");
        static public Ingredient Milk = new Ingredient("Milk", "Images/milk.jpg");
        static public Ingredient Thyme = new Ingredient("Thyme", "Images/thyme.jpg");
        static public Ingredient WhiteBeans = new Ingredient("White beans", "Images/whiteBeans.jpg");
        static public Ingredient GarlicSausage = new Ingredient("Garlic sausage", "Images/garlicSausage.jpg");
        static public Ingredient ToulouseSausage = new Ingredient("Toulouse sausage", "Images/toulouseSausage.jpg");
        static public Ingredient PorkBelly = new Ingredient("Pork belly", "Images/porkBelly.jpg");
        static public Ingredient Duck = new Ingredient("Duck", "Images/duck.jpg");
        static public Ingredient TomatoPaste = new Ingredient("Tomato paste", "Images/tomatoPaste.jpg");
        static public Ingredient Breadcrumbs = new Ingredient("Breadcrumbs", "Images/breadCrumbs.jpg");
        static public Ingredient Garlic = new Ingredient("Garlic", "Images/garlic.jpg");
        static public Ingredient BayLeaf = new Ingredient("Bay leaf", "Images/bayLeaf.jpg");
        static public Ingredient Wine = new Ingredient("Wine", "Images/wine.jpg");
        static public Ingredient Carrot = new Ingredient("Carrot", "Images/carrot.jpg");
        static public Ingredient Onion = new Ingredient("Onion", "Images/onion.jpg");
        static public Ingredient Beef = new Ingredient("Beef", "Images/beef.jpg");
        static public Ingredient Parsley = new Ingredient("Parsley", "Images/parsley.jpg");
        static public Ingredient BouquetGarni = new Ingredient("Bouquet Garni", "Images/bouquetGarni.jpg");
        static public Ingredient SunflowerOil = new Ingredient("Sunflower Oil", "Images/sunflowerOil.jpg");
        static public Ingredient Ginger = new Ingredient("Ginger", "Images/ginger.jpg");
        static public Ingredient Cumin = new Ingredient("Cumin", "Images/cumin.jpg");
        static public Ingredient Turmeric = new Ingredient("Turmeric", "Images/turmeric.jpg");
        static public Ingredient CoralLentils = new Ingredient("Coral Lentils", "Images/coralLentils.jpg");
        static public Ingredient CoconutMilk = new Ingredient("Coconut Milk", "Images/coconutMilk.jpg");
        static public Ingredient Tomatoes = new Ingredient("Tomatoes", "Images/tomatoes.jpg");
    }
}

