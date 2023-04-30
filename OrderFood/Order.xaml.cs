using OrderFood.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace OrderFood
{
    /// <summary>
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        object[] orderArray;
        object[] countArray;
        int j = 0;
        public Order(object[,] array)
        {
            InitializeComponent();
            orderArray = new object[array.Length / 2];
            countArray = new object[array.Length / 2];
            for (int i = 0; i < array.Length / 2; i++)
            {
                orderArray[i] = array[i, j];
                for (j = 1; j < 2; j++)
                {
                    countArray[i] = array[i, j];
                }
                j = 0;
            }
        }
        object[] DofiArray;
        FoodOrderEntities2 db = new FoodOrderEntities2();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < orderArray.Length; i++)
            {
                if (countArray[i].ToString() != "0")
                {
                   ListViewOrder.Items.Add(orderArray[i].ToString() + " " + countArray[i].ToString());
                }
            }
            ListViewOrder.Items.Add("------------------------------------------------");
            ListViewOrder.Items.Add("");
            for (int i = 0; i < orderArray.Length; i++)
            {
                if (countArray[i].ToString() != "0")
                {
                    ListViewOrder.Items.Add(orderArray[i].ToString() + " " + countArray[i].ToString()+ ":");
                    Entities.Product authIngridient = null;
                    Entities.Dish authDish = null;
                    
                    using (Entities.FoodOrderEntities2 context = new Entities.FoodOrderEntities2())
                    {
                        string currentName = orderArray[i].ToString().Trim();
                        authDish = context.Dishes.Where(b => b.Name == currentName).FirstOrDefault();
                        if (authDish != null)
                        {
                            DofiArray = App.Database.DishesOfIngredients.Where(x => x.id_Dishes == authDish.id).ToArray();
                            foreach (var item in DofiArray)
                            {
                                Entities.DishesOfIngredient currentDOfI = (DishesOfIngredient)item;
                                authIngridient = context.Products.Where(b => b.id == currentDOfI.id_ingridient).FirstOrDefault();
                                double weigth = authIngridient.Weight * Convert.ToDouble(countArray[i]);
                                ListViewOrder.Items.Add(authIngridient.Name.ToString() + " " + weigth.ToString()+ " " + authIngridient.Unit.Name);
                            }
                        } 
                    }
                    ListViewOrder.Items.Add("");
                }
            }
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
