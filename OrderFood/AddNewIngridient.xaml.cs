using OrderFood.Classes;
using OrderFood.Entities;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OrderFood
{
    /// <summary>
    /// Логика взаимодействия для AddNewIngridient.xaml
    /// </summary>
    public partial class AddNewIngridient : Window
    {
        Entities.FoodOrderEntities2 db = new Entities.FoodOrderEntities2();
        public AddNewIngridient()
        {
            InitializeComponent();
            DataGridAllProduct.ItemsSource = db.Products.ToArray();
        }

        private void AddNewProduct(object sender, RoutedEventArgs e)
        {
            NewProductWindow g = new NewProductWindow();
            g.ShowDialog();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridAllProduct.SelectedItem != null)
            {
                Product currentrow = DataGridAllProduct.SelectedItem as Product;
                new EditProductWindow(currentrow).ShowDialog();
            }
            else
                new CustomMessageBox("Внимание!", "Выберите ингридиент для редактирования", "Ок", "Закрыть", 3, true).ShowDialog();

        }

        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            if (DataGridAllProduct.SelectedItem != null)
            {
                new CustomMessageBox("Вы уверены?", "Вы точно хотите удалить данное блюдо?",
                    "Да", "Нет", 2, true).ShowDialog();
                if (ListEvents.incidentResult is true)
                {
                    Product currentrow = DataGridAllProduct.SelectedItem as Product;
                    try
                    {
                        db.Products.Remove(currentrow);
                        db.SaveChanges();
                        new CustomMessageBox("Успех!", "Блюдо удалено", "Ок", "Закрыть", 1, true).ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        new CustomMessageBox("Ошибка!", ex.Message.ToString(), "Ок", "Закрыть", 4, true).ShowDialog();
                    }
                    DataGridAllProduct.ItemsSource = db.Products.ToList();
                    return;
                }
            }
            else
                new CustomMessageBox("Внимание!", "Выберите ингридиент для удаления", "Ок", "Закрыть", 3, true).ShowDialog();
        }

        Product[] product;
        private void SortTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            product = db.Products.ToArray();
            product = FindDishes(product); ;
            if (product.Length != 0)
            {
                DataGridAllProduct.ItemsSource = product.ToList();
            }
        }
        public Entities.Product[] FindDishes(Product[] array)
        {
            if (SortTextBox.Text != null)
            {
                array = product.Where(s => s.Name.ToLower()
                .Contains(SortTextBox.Text.ToLower())).ToArray();
            }
            return array;
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FillDataGrid(object sender, RoutedEventArgs e)
        {
            DataGridAllProduct.ItemsSource = db.Products.ToList();
        }
    }
}
