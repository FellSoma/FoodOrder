using OrderFood.Entities;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;

namespace OrderFood
{
    /// <summary>
    /// Логика взаимодействия для EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        Entities.FoodOrderEntities2 db = new Entities.FoodOrderEntities2();

        public EditProductWindow(Product currentProduct)
        {
            InitializeComponent();
            DataContext = currentProduct;
            cbUnit.ItemsSource = db.Units.ToList();

            Unit currentUnit = db.Units.Where(b => b.id == currentProduct.id_Unit).FirstOrDefault();
            cbUnit.SelectedIndex = currentUnit.id - 1;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            try
            {
                Product editProduct = new Product();
                editProduct = (Product)DataContext;
                editProduct.id_Unit = cbUnit.SelectedIndex + 1;
                db.Products.AddOrUpdate(editProduct);
                db.SaveChanges();
                new CustomMessageBox("Успех!", "Изменино", "Ок", "Закрыть", 1, true).ShowDialog();

            }
            catch (System.Exception ex)
            {
                new CustomMessageBox("Ошибка!", ex.Message.ToString(), "Ок", "Закрыть", 4, true).ShowDialog();
            }
        }
    }
}
