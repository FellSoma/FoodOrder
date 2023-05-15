using OrderFood.Entities;
using System;
using System.Linq;
using System.Windows;

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
        object[,] SummWeigth;
        object[] DofiArray;
        Product authProduct;
        FoodOrderEntities2 db = new FoodOrderEntities2();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < orderArray.Length; i++)
            {
                if (countArray[i].ToString() != "0")
                {
                    ListViewOrder.Items.Add(orderArray[i].ToString() + " " + countArray[i].ToString() + " порций");
                }
            }
            ListViewOrder.Items.Add("------------------------------------------------");
            ListViewOrder.Items.Add("");

            Product[] productArray = db.Products.ToArray();
            SummWeigth = new object[db.Products.Count(), 2];
            for (int j = 0; j < db.Products.Count(); j++)
            {
                SummWeigth[j, 0] = productArray[j];
                SummWeigth[j, 1] = 0;
            }

            for (int i = 0; i < orderArray.Length; i++)
            {
                if (countArray[i].ToString() != "0")
                {
                    ListViewOrder.Items.Add(orderArray[i].ToString() + " " + countArray[i].ToString() + " порций" + ":");
                    Entities.Product authIngridient = null;
                    Entities.Dish authDish = null;

                    using (Entities.FoodOrderEntities2 context = new Entities.FoodOrderEntities2())
                    {
                        string currentName = orderArray[i].ToString().Trim();
                        authDish = context.Dishes.Where(b => b.Name == currentName).FirstOrDefault();
                        if (authDish != null)
                        {
                            DofiArray = db.DishesOfIngredients.Where(x => x.id_Dishes == authDish.id).ToArray();
                            foreach (DishesOfIngredient item in DofiArray)
                            {
                                Entities.DishesOfIngredient currentDOfI = (DishesOfIngredient)item;
                                authIngridient = context.Products.Where(b => b.id == currentDOfI.id_ingridient).FirstOrDefault();
                                double weigth = (double)(item.weigth * Convert.ToDouble(countArray[i]));
                                for (int l = 0; l < db.Products.Count(); l++)
                                {
                                    authProduct = (Product)SummWeigth[l, 0];
                                    if (authProduct.id == authIngridient.id)
                                    {
                                        if (Double.TryParse(SummWeigth[l, 1].ToString(), out Double value))
                                        {
                                            SummWeigth[l, 1] = weigth + value;

                                        }
                                    }
                                }
                                ListViewOrder.Items.Add(authIngridient.Name.ToString() + " " + weigth.ToString() + " " + authIngridient.Unit.Name);
                            }
                        }
                    }
                    ListViewOrder.Items.Add("");
                }
            }
            ListViewOrder.Items.Add("------------------------------------------------");
            ListViewOrder.Items.Add("Общие масса ингридиентов");
            for (int i = 0; i < db.Products.Count(); i++)
            {
                if (SummWeigth[i, 1] != null)
                {
                    authProduct = (Product)SummWeigth[i, 0];
                    ListViewOrder.Items.Add(authProduct.Name + " " + SummWeigth[i, 1].ToString() + " " + authProduct.Unit.Name);
                }
            }


        }

        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
