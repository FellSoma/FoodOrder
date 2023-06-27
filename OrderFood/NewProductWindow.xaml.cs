using OrderFood.Entities;
using System.Linq;
using System.Windows;

namespace OrderFood
{
    /// <summary>
    /// Логика взаимодействия для NewProductWindow.xaml
    /// </summary>
    public partial class NewProductWindow : Window
    {
        Entities.FoodOrderEntities2 db = new Entities.FoodOrderEntities2();
        public NewProductWindow()
        {
            InitializeComponent();
            cbUnit.ItemsSource = db.Units.ToArray();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (cbUnit.SelectedItem != null || nameProduct.Text != "")
            {

                Product currentProduct = new Product();
                currentProduct = db.Products.Where(b => b.Name == nameProduct.Text.Trim()).FirstOrDefault();

                if (currentProduct == null)
                {
                    Product product = new Product()
                    {
                        Name = nameProduct.Text.Trim(),
                        id_Unit = cbUnit.SelectedIndex + 1,
                        Mass = "Кг"
                    };
                    db.Products.Add(product);
                    db.SaveChanges();
                    new CustomMessageBox("Успех!", "Добавлено", "Ок", "Закрыть", 1, true).ShowDialog();
                }
                else
                {
                    new CustomMessageBox("Внимание!", "Такой ингридиент уже существует", "Ок", "Закрыть", 3, true).ShowDialog();
                }
            }
            else
            {
                new CustomMessageBox("Внимание!", "Заполните все поля", "Ок", "Закрыть", 3, true).ShowDialog();
            }
        }
    }
}
