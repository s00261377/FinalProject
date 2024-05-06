using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Marmitoque
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Queue<int> menus = new Queue<int>();
        int currentMenu = 0;
        //0 : main menu
        //1 : recipe menu
        
        List<string> countries = new List<string>()
        {
            "France",
            "India",
            "China",
            "Italy",
            "Germany"
        };
        List<string> breakfast = new List<string>()
        {
            "Salty",
            "Sweet",
            "Drinks",
            "Viennoiseries",
            "Fruits"
        };
        List<string> entree = new List<string>()
        {
            "Appetizers",
            "Soup",
            "Salads",
            "Main course",
            "Side dish"
        };
        List<string> lunchIdeas = new List<string>()
        {
            "Sandwiches",
            "Wraps",
            "Burgers",
            "Salads",
            "Sushi rolls"
        };
        List<string> dinerIdeas = new List<string>()
        {
            "Beef",
            "Chicken",
            "Fish",
            "Vegetarian",
            "Pork"
        };
        List<string> pasta = new List<string>()
        {
            "Spaghetti",
            "Fettuccine Alfredo",
            "Penne Arrabiata",
            "Lasagna",
            "Ravioli"
        };

        List<Recipe> LoadedRecipes = new List<Recipe>();
        List<Recipe> CurrentDisplayedRecipes = new List<Recipe>();
        public MainWindow()
        {
            InitializeComponent();
        }

        void LoadMainMenu()
        {
            LstBRecipes.Visibility = Visibility.Visible;
            LstBFoodType.Visibility = Visibility.Visible;

            CmboServes.Visibility = Visibility.Visible;
            CmboSort.Visibility = Visibility.Visible;
            
            TxBxSearch.Visibility = Visibility.Visible;
            TxtCmboServes.Visibility = Visibility.Visible; 
            TxtCmboSort.Visibility = Visibility.Visible;
            TxtSearch.Visibility = Visibility.Visible;

            LstBAdvanceSelection.Visibility = Visibility.Collapsed;
            LstBDetailRecipe.Visibility = Visibility.Collapsed;
            BtnBack.Visibility = Visibility.Collapsed;
        }

        void LoadRecipeMenu()
        {
            LstBRecipes.Visibility = Visibility.Collapsed;
            LstBFoodType.Visibility = Visibility.Collapsed;

            CmboServes.Visibility = Visibility.Collapsed;
            CmboSort.Visibility = Visibility.Collapsed;

            TxBxSearch.Visibility = Visibility.Collapsed;
            TxtCmboServes.Visibility = Visibility.Collapsed;
            TxtCmboSort.Visibility = Visibility.Collapsed;
            TxtSearch.Visibility = Visibility.Collapsed;

            LstBAdvanceSelection.Visibility = Visibility.Visible;
            LstBDetailRecipe.Visibility = Visibility.Visible;
            BtnBack.Visibility = Visibility.Visible;
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LstBFoodType.ItemsSource = new List<string>() { "Countries", "Breakfast", "Entree", "Lunch ideas", "Dinner ideas", "Pasta" };
            CmboSort.ItemsSource = new List<string>() { "alphabetical", "price", "calories"};
            CmboServes.ItemsSource = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            CmboServes.SelectedIndex = 3;
            //DataManager.SaveAll();
            DataManager.LoadAll(LoadedRecipes);
            CurrentDisplayedRecipes = LoadedRecipes;
            LstBRecipes.ItemsSource = Tools.Randomize(LoadedRecipes);
            LoadMainMenu();   
            
        }

        private void LstBFoodType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LstBFoodType.SelectedIndex == -1)
                return;
            string selected = LstBFoodType.SelectedItem.ToString();

            switch (selected)
            {
                case "Countries":
                    LstBAdvanceSelection.ItemsSource = countries;
                    LstBAdvanceSelection.Visibility = Visibility.Visible;
                    break;
                case "Breakfast":
                    LstBAdvanceSelection.ItemsSource = breakfast;
                    LstBAdvanceSelection.Visibility = Visibility.Visible;
                    break;
                case "Entree":
                    LstBAdvanceSelection.ItemsSource = entree;
                    LstBAdvanceSelection.Visibility = Visibility.Visible;
                    break;
                case "Lunch ideas":
                    LstBAdvanceSelection.ItemsSource = lunchIdeas;
                    LstBAdvanceSelection.Visibility = Visibility.Visible;
                    break;
                case "Dinner ideas":
                    LstBAdvanceSelection.ItemsSource = dinerIdeas;
                    LstBAdvanceSelection.Visibility = Visibility.Visible;
                    break;
                case "Pasta":
                    LstBAdvanceSelection.ItemsSource = pasta;
                    LstBAdvanceSelection.Visibility = Visibility.Visible;
                    break;
                default:
                    LstBAdvanceSelection.ItemsSource = null;
                    LstBAdvanceSelection.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LstBAdvanceSelection.ItemsSource = null;
            LstBAdvanceSelection.Visibility = Visibility.Collapsed;
            LstBFoodType.SelectedIndex = -1;
            LstBAdvanceSelection.SelectedIndex = -1;
            LstBRecipes.SelectedIndex = -1;

        }

        private void LstBAdvanceSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(LstBAdvanceSelection.SelectedItem == null || LstBAdvanceSelection.SelectedIndex == -1) { return; }
            string selected = LstBAdvanceSelection.SelectedItem.ToString();
            switch (selected)
            {
                case "France":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("France")).ToList());
                    break;
                case "India":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("India")).ToList());
                    break;
                case "China":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("China")).ToList());
                    break;
                case "Italy":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Italy")).ToList());
                    break;
                case "Germany":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Germany")).ToList());
                    break;
                case "Salty":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Salty")).ToList());
                    break;
                case "Sweet":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Sweet")).ToList());
                    break;
                case "Drinks":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Drinks")).ToList());
                    break;
                case "Viennoiseries":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Viennoiseries")).ToList());
                    break;
                case "Fruits":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Fruits")).ToList());
                    break;
                case "Appetizers":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Appetizers")).ToList());
                    break;
                case "Soup":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Soup")).ToList())    ;
                    break;
                case "Salads":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Salad")).ToList());
                    break;
                case "Main course":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Main course")).ToList());
                    break;
                case "Side dish":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Side dish")).ToList());
                    break;
                case "Sandwiches":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Sandwiches")).ToList());
                    break;
                case "Wraps":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Wraps")).ToList());
                    break;
                case "Burgers":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Burgers")).ToList());
                    break;
                case "Sushi rolls":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Sushi rolls")).ToList());
                    break;
                case "Beef":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Beef")).ToList());
                    break;
                case "Chicken":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Chicken")).ToList());
                    break;
                case "Fish":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Fish")).ToList());
                    break;
                case "Vegetarian":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Vegetarian")).ToList());
                    break;
                case "Pork":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Pork")).ToList());
                    break;
                case "Spaghetti":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Spaghetti")).ToList());
                    break;
                case "Fettuccine Alfredo":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Fettuccine Alfredo")).ToList());
                    break;
                case "Penne Arrabiata":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Penne Arrabiata")).ToList());
                    break;
                case "Lasagna":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Lasagna")).ToList());
                    break;
                case "Ravioli":
                    CurrentDisplayedRecipes = Tools.Randomize(LoadedRecipes.Where(x => x.Tags.Contains("Ravioli")).ToList()  );
                    break;
                default:
                    break;
            }
            LstBRecipes.ItemsSource = CurrentDisplayedRecipes;
            LstBAdvanceSelection.Visibility = Visibility.Collapsed;
            LstBFoodType.SelectedIndex = -1;
            LstBAdvanceSelection.SelectedIndex = -1;

        }

        private void LstBRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LstBRecipes.SelectedIndex == -1)
                return;
            Recipe selected = (Recipe)LstBRecipes.SelectedItem;
            List<Recipe> toDisplay = new List<Recipe>() { selected };
            LstBDetailRecipe.ItemsSource = toDisplay;
            LoadRecipeMenu();
            menus.Enqueue(currentMenu);
            currentMenu = 1;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            int goTo = menus.Dequeue();
            if (currentMenu == 1)
                LoadRecipeMenu();
            if (goTo == 0)
            {
                LoadMainMenu();
                LstBRecipes.ItemsSource = Tools.Randomize(LoadedRecipes);
                LstBFoodType.SelectedIndex = -1;
                LstBRecipes.SelectedIndex = -1;
            }
            currentMenu = goTo;

        }

        private void CmboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmboSort.SelectedIndex == -1)
                return;
            string selected = CmboSort.SelectedItem.ToString();
            if(selected == "alphabetical")
            {
                CurrentDisplayedRecipes = Tools.AlphabeticSort(LoadedRecipes);
                
            }
            else if (selected == "price")
            {
                CurrentDisplayedRecipes = Tools.PriceSort(LoadedRecipes);
                
            }
            else if (selected == "calories")
            {
                CurrentDisplayedRecipes = Tools.CalorieSort(LoadedRecipes);
            }
            LstBRecipes.ItemsSource = CurrentDisplayedRecipes;
            CmboSort.SelectedIndex = -1;
        }

        private void CmboServes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = CmboServes.SelectedItem.ToString();
            float Serves = float.Parse(selected);
            foreach(var elem in LoadedRecipes)
            {
                elem.Recalculate((int)Serves);
            }
            LstBRecipes.ItemsSource = Tools.PriceSort(CurrentDisplayedRecipes);

        }

        private void TxBxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string selected = TxBxSearch.Text;
            if (selected == "")
            {
                CurrentDisplayedRecipes = LoadedRecipes;
                LstBRecipes.ItemsSource = CurrentDisplayedRecipes;
                return;
            }
            CurrentDisplayedRecipes = CurrentDisplayedRecipes.Where(x => x.Name.ToLower().Contains(selected.ToLower())).ToList();
            LstBRecipes.ItemsSource = CurrentDisplayedRecipes;
        }
    }
}
