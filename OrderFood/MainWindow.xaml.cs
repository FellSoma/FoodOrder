using OrderFood.Entities;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OrderFood
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FoodOrderEntities2 db = new FoodOrderEntities2();
        public MainWindow()
        {
            InitializeComponent();

        }
        object[,] orderArray;

        //Сделать предварительный просмотр СДЕЛАЛ 
        //Сделать добовление СДЕЛАЛ
        //Сделать удаление СДЕЛАЛ
        //Сделать редактирование Пока что не работает и скорее всего не будет работать
        //Сделать сам заказ СДЕЛАЛ ( можно улутшить обеденить вес всех ингридиентов и вывести отделно)
        //Протестировать приложение и добавить обработчики исключений +-СДЕЛАЛ

        //ЗАГОТОВКИ НА ДИПЛОМ
        //Сделать поиск по блюдам в DatagridOder 
        //Сделать стииль для DataGreidOrder с выезжающем блюдом чтобы можно было видеть игридиенты блюда
        private void Exit(object sender, RoutedEventArgs e)
        {
            Window g = new SiningWindow();
            g.Show();
            this.Close();
        }
        int i;
        int j;

        public void FillDataGrid()
        {
            //заполнение DataGridOrder
            string nameMenu = shortName(MenuBx.SelectedItem.ToString());
            ConnectionWindow connection = new ConnectionWindow();
            var query = (
            from ds in db.Dishes
            from us in db.Users
            from dofm in db.DishesOfMenus
            from menu in db.Menus
            where menu.Name == nameMenu
            where dofm.id_Dishes == ds.id
            where dofm.id_Menu == menu.id
            select new { ds.Name }).Distinct();
            DataGridOrder.ItemsSource = query.ToList();

            //массив количества

            orderArray = new string[DataGridOrder.Items.Count, 2];
            int j = 0;
            Entities.Dish authMenu = null;

            i = 0;
            j = 0;

            foreach (var item in query)
            {
                using (Entities.FoodOrderEntities2 context = new Entities.FoodOrderEntities2())
                {
                    authMenu = context.Dishes.Where(b => b.Name == item.Name.Trim()).FirstOrDefault();
                }
                if (authMenu != null)
                {
                    orderArray[i, j] = authMenu.Name;
                    j = 1;
                    orderArray[i, j] = "0";
                    i++;
                    j = 0;
                }
            }
        }

        private void CangeMenu(object sender, SelectionChangedEventArgs e)
        {
            FillDataGrid();
        }

        public string shortName(string name)
        {
            char[] separators = new char[] { '{', ':', '/', '=', '}' };
            string[] subs = name.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            name = subs[1];
            //1 элемен в масиве 
            return name.Trim();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //ПОПРОБУЙ ЗАПОЛНИТЬ DATAGRID ЧЕРЕЗ LINQ 
            ConnectionWindow connection = new ConnectionWindow();

            var munues =
            from menu in db.Menus
            from us in db.Users
            from org in db.Organizations
            from oom in db.OrganizationsOfMenus
            where us.id == App.User_id.id
            where us.id == org.id_User
            where menu.id == oom.id_Menu
            where org.id == oom.id_Organization
            select new { menu.Name };

            MenuBx.ItemsSource = munues.ToList();

        }

        int allCount;
        private void Preview(object sender, RoutedEventArgs e)
        {
            ListBoxOrder.Items.Clear();
            DataGridOrder.Visibility = Visibility.Hidden;
            ListBoxOrder.Visibility = Visibility.Visible;
            allCount = 0;
           try
           {
                if (orderArray != null)
                {
                    for (int i = 0; i < orderArray.Length / 2; i++)
                    {
                        ListBoxOrder.Items.Add(orderArray[i, 0].ToString() + " " + orderArray[i, 1].ToString());
                        allCount = allCount + (int)orderArray[i, 1];
                    }
                }
           }
            catch (InvalidCastException)
           {
                ListBoxOrder.Items.Clear();
                for (int i = 0; i < orderArray.Length / 2; i++)
                {
                    ListBoxOrder.Items.Add(orderArray[i, 0].ToString() + " " + orderArray[i, 1].ToString());
                }
                allCount = -1;
           }
        }
        private void addToOrder(object sender, RoutedEventArgs e)
        {
            if (DataGridOrder.SelectedItem != null)
            {
                string currentCount = "";
                foreach (var item in Count.Text)
                {
                    if (item != ' ')
                    {
                        currentCount = currentCount + item;
                    }
                }

                if (currentCount[0] == '0')
                {
                    MessageBox.Show("Вы ввели неправильное количество");
                    return;
                }

                orderArray[DataGridOrder.SelectedIndex, 1] = currentCount;
                MessageBox.Show("Добавлено");
                Count.Text = "";
            }
        }

        private void PreviewBack(object sender, RoutedEventArgs e)
        {
            DataGridOrder.Visibility = Visibility.Visible;
            ListBoxOrder.Visibility = Visibility.Hidden;
        }

        private void SortTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddNewDish(object sender, RoutedEventArgs e)
        {
            NewDish g = new NewDish();
            g.ShowDialog();

        }

        private void DeleteDish(object sender, RoutedEventArgs e)
        {
            try
            {
                Entities.Dish authDish = null;
                if (DataGridOrder.SelectedItem != null)
                {
                    string nameDish = shortName(DataGridOrder.SelectedItem.ToString());
                    using (Entities.FoodOrderEntities2 context = new Entities.FoodOrderEntities2())
                    {
                        authDish = context.Dishes.Where(b => b.Name == nameDish).FirstOrDefault();
                        try
                        {
                            context.Dishes.Remove(authDish);
                            context.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                    FillDataGrid();

                }
                else
                    MessageBox.Show("Не выбрано блюдо для удаление");
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана ни одна строка для удаления!");
            }
        }

        private void NextOrder(object sender, RoutedEventArgs e)
        {
            if (MenuBx.SelectedItem != null)
            {
                if (allCount != 0)
                {
                    Order g = new Order(orderArray);
                    g.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Ни одно блюдо не заполнено");
                }
            }
            else
                MessageBox.Show("Выберите меню");
        }

        private void Count_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if ((e.Key == Key.D0) || (e.Key == Key.D1) || (e.Key == Key.D2) || (e.Key == Key.D3) || (e.Key == Key.D4)
              || (e.Key == Key.D5) || (e.Key == Key.D6) || (e.Key == Key.D7) || (e.Key == Key.D8) || (e.Key == Key.D9))
            {
                // цифра
                return;
            }

            // остальные символы запрещены
            e.Handled = true;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Entities.FoodOrderEntities2 context = new Entities.FoodOrderEntities2();
            string nameDish = DataGridOrder.SelectedItem.ToString().Substring(9, DataGridOrder.SelectedItem.ToString().Length - 11);
            var selectDish =  context.Dishes.Where(b=> b.Name == nameDish).FirstOrDefault();
            new EditDishWindow(selectDish).ShowDialog();
        }
    }
}
