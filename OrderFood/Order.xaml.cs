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
        Dish[] orderArray;
        Int32[] countArray;
        int j = 0;
        public Order(Int32[] array, Dish[] array1 )
        {
            InitializeComponent();
            orderArray = array1;
            countArray = array;
           
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
                    ListViewOrder.Items.Add(orderArray[i].Name + " " + countArray[i].ToString() + " порций");
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
                    ListViewOrder.Items.Add(orderArray[i].Name + " " + countArray[i].ToString() + " порций" + ":");
                    Entities.Product authIngridient = null;
                    Entities.Dish authDish = null;

                    using (Entities.FoodOrderEntities2 context = new Entities.FoodOrderEntities2())
                    {
                        string currentName = orderArray[i].Name.Trim();
                        authDish = context.Dishes.Where(b => b.Name == currentName).FirstOrDefault();
                        if (authDish != null)
                        {
                            DofiArray = db.DishesOfIngredients.Where(x => x.id_Dishes == authDish.id).ToArray();
                            double weigth;
                            foreach (DishesOfIngredient item in DofiArray)
                            {
                                Entities.DishesOfIngredient currentDOfI = (DishesOfIngredient)item;
                                authIngridient = context.Products.Where(b => b.id == currentDOfI.id_ingridient).FirstOrDefault();

                                weigth = (double)(item.weigth * Convert.ToDouble(countArray[i]));

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
                                if (weigth > 1000)
                                {
                                    weigth = weigth / 1000;
                                    ListViewOrder.Items.Add(authIngridient.Name.ToString() + " " + weigth.ToString()
                                    + " (" + authIngridient.Unit.Name + ") " + "Кг");
                                }
                                else
                                {
                                    ListViewOrder.Items.Add(authIngridient.Name.ToString() + " " + weigth.ToString()
                                    + " (" + authIngridient.Unit.Name + ") " + "Гр");
                                }
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
                if (Double.TryParse(SummWeigth[i, 1].ToString(), out Double value))
                {
                    if (value != 0)
                    {
                        authProduct = (Product)SummWeigth[i, 0];
                        if ((double)SummWeigth[i, 1] > 1000)
                        {
                            ListViewOrder.Items.Add(authProduct.Name + " " + ((double)SummWeigth[i, 1] / 1000).ToString() + " (" + authProduct.Unit.Name + ") " + "Кг");
                        }
                        else
                            ListViewOrder.Items.Add(authProduct.Name + " " + (SummWeigth[i, 1]).ToString() + " (" + authProduct.Unit.Name + ") " + "Гр");

                    }
                }
            }


        }

        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
