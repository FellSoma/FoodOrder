using OrderFood.Classes;
using OrderFood.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Логика взаимодействия для NewMenuWindow.xaml
    /// </summary>
    public partial class NewMenuWindow : Window
    {
        Entities.FoodOrderEntities2 db = new FoodOrderEntities2();
        public NewMenuWindow()
        {
            InitializeComponent();
            DataGridAllMenues.ItemsSource = db.Menus.ToArray();
        }

        private void AddNewProduct(object sender, RoutedEventArgs e)
        {
            AddNewMenuWindow g = new AddNewMenuWindow();
            g.ShowDialog();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridAllMenues.SelectedItem != null)
            {
                Entities.Menu currentrow = DataGridAllMenues.SelectedItem as Entities.Menu;
                new EditMenutWindow(currentrow).ShowDialog();
            }
            else
                new CustomMessageBox("Внимание!", "Выберите меню для редактирования", "Ок", "Закрыть", 3, true).ShowDialog();

        }

        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            if (DataGridAllMenues.SelectedItem != null)
            {
                new CustomMessageBox("Вы уверены?", "Вы точно хотите удалить данное меню?",
                    "Да", "Нет", 2, true).ShowDialog();
                if (ListEvents.incidentResult is true)
                {
                    Entities.Menu currentrow = DataGridAllMenues.SelectedItem as Entities.Menu;
                    try
                    {
                        db.Menus.Remove(currentrow);
                        db.SaveChanges();
                        new CustomMessageBox("Успех!", "Меню удалено", "Ок", "Закрыть", 1, true).ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        new CustomMessageBox("Ошибка!", ex.Message.ToString(), "Ок", "Закрыть", 4, true).ShowDialog();
                    }
                    DataGridAllMenues.ItemsSource = db.Menus.ToList();
                    return;
                }
            }
            else
                new CustomMessageBox("Внимание!", "Выберите меню для удаления", "Ок", "Закрыть", 3, true).ShowDialog();
        }

        Entities.Menu[] menu;
        private void SortTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            menu = db.Menus.ToArray();
            menu = FindDishes(menu); ;
            if (menu.Length != 0)
            {
                DataGridAllMenues.ItemsSource = menu.ToList();
            }
        }
        public Entities.Menu[] FindDishes(Entities.Menu[] array)
        {
            if (SortTextBox.Text != null)
            {
                array = menu.Where(s => s.Name.ToLower()
                .Contains(SortTextBox.Text.ToLower())).ToArray();
            }
            return array;
        }
        private void FillDataGrid(object sender, RoutedEventArgs e)
        {
            DataGridAllMenues.ItemsSource = db.Menus.ToList();
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

       
    }
}
