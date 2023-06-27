using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace OrderFood
{
    /// <summary>
    /// Логика взаимодействия для AddMenu.xaml
    /// </summary>
    public partial class AddMenu : Window
    {
        public AddMenu()
        {
            InitializeComponent();
        }

        private void AddNewDish(object sender, RoutedEventArgs e)
        {
            NewDish g = new NewDish();
            g.ShowDialog();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddIngridient(object sender, RoutedEventArgs e)
        {
            AddNewIngridient g = new AddNewIngridient();
            g.ShowDialog();
        }

        private void AddNewMenu(object sender, RoutedEventArgs e)
        {
            NewMenuWindow g = new NewMenuWindow();
            g.ShowDialog();
        }
    }
}
