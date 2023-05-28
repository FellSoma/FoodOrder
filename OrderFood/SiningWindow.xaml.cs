using OrderFood.Entities;
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
    /// Логика взаимодействия для SiningWindow.xaml
    /// </summary>
    public partial class SiningWindow : Window
    {
        FoodOrderEntities2 db = new FoodOrderEntities2();
        public SiningWindow()
        {
            InitializeComponent();
            CbUsers.ItemsSource = App.Database.Users.ToList();
        }

        private void Sing(object sender, RoutedEventArgs e)
        {
            User authUser = null;
            authUser = db.Users.Where(b => b.Name == CbUsers.Text && b.Password == Passwordbx.Password).FirstOrDefault();
            if (authUser != null)
            {
                ConnectionWindow connection = new ConnectionWindow();
                App.User_id.id = authUser.id;
                Window g = new MainWindow();
                g.Show();
                this.Close();
            }
            else
            {
                new CustomMessageBox("Внимание!", "Пользователь не найден", "Ок", "Закрыть", 1, true).ShowDialog();

            }
        }
    }
}
