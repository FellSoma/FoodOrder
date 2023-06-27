using OrderFood.Classes;
using OrderFood.Entities;
using System;
using System.Collections.Generic;
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
            DataGridAllDishes.ItemsSource = db.Dishes.ToList();
            FillOrderArray();

        }
        Int32[] orderArrayCount;
        Dish[] orderArrayDish;
        // Узнай что за переменная AllCount
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
            LoadData();
        }
        int i;
        int j;
        Entities.Dish[] dishes;
        public void LoadData()
        {
            dishes = db.Dishes.ToArray();
            dishes = FindDishes(dishes); ;
            if (dishes.Length != 0)
            {
                DataGridAllDishes.ItemsSource = dishes.ToList();
            }
            else
            {
                DataGridAllDishes.Visibility = Visibility.Collapsed;
            }
        }


        public Entities.Dish[] FindDishes(Dish[] array)
        {
            if (SortTextBox.Text != null)
            {
                array = dishes.Where(s => s.Name.ToLower()
                .Contains(SortTextBox.Text.ToLower())).ToArray();
            }
            return array;
        }
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
        }


        public void FillOrderArray()
        {
            orderArrayCount = new int[db.Dishes.LongCount()];
            orderArrayDish = db.Dishes.ToArray();

        }

        private void CangeMenu(object sender, SelectionChangedEventArgs e)
        {
            FillDataGrid();
            DataGridAllDishes.Visibility = Visibility.Hidden;
            DataGridOrder.Visibility = Visibility.Visible;
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

        public void TestFillOrder()
        {
            allCount = 0;
            try
            {
                if (orderArrayDish != null && orderArrayCount != null)
                {
                    for (int i = 0; i < orderArrayDish.Length / 2; i++)
                    {
                        allCount = allCount + Convert.ToInt32(orderArrayCount[i]);
                    }
                }
            }
            catch (InvalidCastException)
            {
                ListBoxOrder.Items.Clear();
                allCount = -1;
            }
        }

        private void Preview(object sender, RoutedEventArgs e)
        {
            ListBoxOrder.Items.Clear();
            DataGridOrder.Visibility = Visibility.Hidden;
            ListBoxOrder.Visibility = Visibility.Visible;
            allCount = 0;
            try
            {
                if (orderArrayDish != null && orderArrayCount != null)
                {
                    for (int i = 0; i < orderArrayDish.Length / 2; i++)
                    {
                        Entities.Dish dish = orderArrayDish[i];
                        if (Convert.ToInt32(orderArrayCount[i]) != 0 || orderArrayCount[i] != null)
                        {
                            ListBoxOrder.Items.Add(dish.Name + " " + orderArrayCount[i].ToString());
                            allCount = allCount + Convert.ToInt32(orderArrayCount[i]);
                        }
                    }
                }
            }
            catch (InvalidCastException)
            {
                ListBoxOrder.Items.Clear();
                for (int i = 0; i < orderArrayDish.Length / 2; i++)
                {
                    ListBoxOrder.Items.Add(orderArrayDish[i].ToString() + " " + orderArrayCount[i].ToString());
                }
                allCount = -1;
            }
        }
        private void addToOrder(object sender, RoutedEventArgs e)
        {
            try
            {

                if (DataGridAllDishes.Visibility == Visibility.Visible)
                {
                    if (DataGridAllDishes.SelectedItem != null)
                    {
                        string currentCount = "";
                        foreach (var item in Count.Text)
                        {
                            if (item != ' ')
                            {
                                currentCount = currentCount + item;
                            }
                        }

                        if (currentCount.Length == 0 || currentCount[0] == '0')
                        {
                            new CustomMessageBox("Внимание!", "Вы ввели неправильно количество", "Ок", "Закрыть", 3, true).ShowDialog();
                            return;
                        }

                        Dish currentItemDataGrid = (Dish)DataGridAllDishes.SelectedItem;
                        indexSelectDish = 0;
                        foreach (var item in orderArrayDish)
                        {
                            if (item.id == currentItemDataGrid.id)
                            {
                                break;
                            }
                            indexSelectDish++;
                        }
                        orderArrayCount[indexSelectDish] = Convert.ToInt32(currentCount);
                        new CustomMessageBox("Успех!", "Добавлено", "Ок", "Закрыть", 1, true).ShowDialog();
                        Count.Text = "";
                        return;
                    }
                    else
                        new CustomMessageBox("Внимание!", "Выберите", "Ок", "Закрыть", 3, true).ShowDialog();
                }
                else
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

                        if (currentCount.Length == 0 || currentCount[0] == '0')
                        {
                            new CustomMessageBox("Внимание!", "Вы ввели неправильно количество", "Ок", "Закрыть", 3, true).ShowDialog();
                            return;
                        }
                        Entities.FoodOrderEntities2 context = new Entities.FoodOrderEntities2();
                        string nameDish = DataGridOrder.SelectedItem.ToString().Substring(9, DataGridOrder.SelectedItem.ToString().Length - 11);
                        var selectDish = context.Dishes.Where(b => b.Name == nameDish).FirstOrDefault();
                        indexSelectDish = 0;
                        foreach (var item in orderArrayDish)
                        {
                            if (item.id == selectDish.id)
                            {
                                break;
                            }
                            indexSelectDish++;
                        }
                        orderArrayCount[indexSelectDish] = Convert.ToInt32(currentCount);
                        new CustomMessageBox("Успех!", "Добавлено", "Ок", "Закрыть", 1, true).ShowDialog();
                        Count.Text = "";
                    }
                    else
                        new CustomMessageBox("Внимание!", "Выберите", "Ок", "Закрыть", 3, true).ShowDialog();
                }
            }
            catch (Exception)
            {
                new CustomMessageBox("Внимание!", "Неизвестная ошибка", "Ок", "Закрыть", 4, true).ShowDialog();
            }
        }
        int indexSelectDish;
        private void PreviewBack(object sender, RoutedEventArgs e)
        {
            DataGridOrder.Visibility = Visibility.Visible;
            ListBoxOrder.Visibility = Visibility.Hidden;
        }
        //Переделай поиск
        List<String> ProductsList = new List<String>();

        private void SortTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadData();
            DataGridAllDishes.Visibility = Visibility.Visible;
        }

        private void AddNewDish(object sender, RoutedEventArgs e)
        {
            AddMenu g = new AddMenu();
            g.ShowDialog();

        }

        private void DeleteDish(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGridAllDishes.SelectedItem != null)
                {
                    new CustomMessageBox("Вы уверены?", "Вы точно хотите удалить данное блюдо?",
                   "Да", "Нет", 2, true).ShowDialog();
                    if (ListEvents.incidentResult is true)
                    {
                        Dish currentrow = DataGridAllDishes.SelectedItem as Dish;
                        try
                        {
                            db.Dishes.Remove(currentrow);
                            db.SaveChanges();
                            new CustomMessageBox("Успех!", "Блюдо удалено", "Ок", "Закрыть", 1, true).ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            new CustomMessageBox("Ошибка!", ex.Message.ToString(), "Ок", "Закрыть", 4, true).ShowDialog();
                        }
                        DataGridAllDishes.ItemsSource = db.Dishes.ToList();
                        return;
                    }
                }
                if (DataGridOrder.SelectedItem != null)
                {
                    Entities.Dish authDish = null;
                    new CustomMessageBox("Вы уверены?", "Вы точно хотите удалить данное блюдо?",
                    "Да", "Нет", 2, true).ShowDialog();
                    if (ListEvents.incidentResult is true)
                    {
                        string nameDish = shortName(DataGridOrder.SelectedItem.ToString());
                        using (Entities.FoodOrderEntities2 context = new Entities.FoodOrderEntities2())
                        {
                            authDish = context.Dishes.Where(b => b.Name == nameDish).FirstOrDefault();
                            try
                            {
                                context.Dishes.Remove(authDish);
                                context.SaveChanges();
                                new CustomMessageBox("Успех!", "Блюдо удалено", "Ок", "Закрыть", 1, true).ShowDialog();
                            }
                            catch (Exception ex)
                            {
                                new CustomMessageBox("Ошибка!", ex.Message.ToString(), "Ок", "Закрыть", 4, true).ShowDialog();
                            }
                        }
                        FillDataGrid();
                    }
                }
                else
                    new CustomMessageBox("Внимание!", "Не выбрано блюдо для удаление!", "Ок", "Закрыть", 3, true).ShowDialog();

            }
            catch (Exception)
            {
                new CustomMessageBox("Внимание!", "Не выбрана ни одна строка для удаления!", "Ок", "Закрыть", 3, true).ShowDialog();

            }
        }

        private void NextOrder(object sender, RoutedEventArgs e)
        {
            if (DataGridAllDishes.Visibility == Visibility.Visible)
            {
                TestFillOrder();
                if (allCount != 0)
                {
                    Order g = new Order(orderArrayCount, orderArrayDish);
                    g.ShowDialog();
                }
                else
                {
                    new CustomMessageBox("Внимание!", "Ни одно блюдо не заполнено!", "Ок", "Закрыть", 3, true).ShowDialog();

                }
            }
            else
            {

                if (MenuBx.SelectedItem != null)
                {
                    TestFillOrder();
                    if (allCount != 0)
                    {
                        Order g = new Order(orderArrayCount, orderArrayDish);
                        g.ShowDialog();
                    }
                    else
                    {
                        new CustomMessageBox("Внимание!", "Ни одно блюдо не заполнено!", "Ок", "Закрыть", 3, true).ShowDialog();
                    }
                }
                else
                    new CustomMessageBox("Внимание!", "Выберите меню!", "Ок", "Закрыть", 3, true).ShowDialog();
            }
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
            try
            {
                if (DataGridAllDishes.SelectedItem != null)
                {
                    if (MenuBx.SelectedItem != null)
                    {
                        Dish currentrow = DataGridAllDishes.SelectedItem as Dish;
                        string NameMenu = MenuBx.SelectedItem.ToString().Substring(9, MenuBx.SelectedItem.ToString().Length - 11);
                        var selectMenu = db.Menus.Where(b => b.Name == NameMenu).FirstOrDefault();
                        DishesOfMenu Dom = db.DishesOfMenus.Where(b => b.id_Menu == selectMenu.id && b.id_Dishes == currentrow.id).FirstOrDefault();
                        if (Dom != null)
                        {
                            new EditDishWindow(currentrow, selectMenu).ShowDialog();
                            return;
                        }
                        else
                            new CustomMessageBox("Внимание!", "Этого блюда нет в меню!", "Ок", "Закрыть", 3, true).ShowDialog();
                    }
                    else
                        new CustomMessageBox("Внимание!", "Выберите меню!", "Ок", "Закрыть", 3, true).ShowDialog();
                }
                if (DataGridOrder.SelectedItem != null)
                {
                    Entities.FoodOrderEntities2 context = new Entities.FoodOrderEntities2();
                    string nameDish = DataGridOrder.SelectedItem.ToString().Substring(9, DataGridOrder.SelectedItem.ToString().Length - 11);
                    var selectDish = context.Dishes.Where(b => b.Name == nameDish).FirstOrDefault();

                    //  string nameMenu = MenuBx.SelectedItem.ToString();

                    string NameMenu = MenuBx.SelectedItem.ToString().Substring(9, MenuBx.SelectedItem.ToString().Length - 11);
                    var selectMenu = context.Menus.Where(b => b.Name == NameMenu).FirstOrDefault();

                    new EditDishWindow(selectDish, selectMenu).ShowDialog();
                    FillDataGrid();
                }
            }
            catch (Exception)
            {
                new CustomMessageBox("Внимание!", "Не выбрана ни одна строка для редактирования!", "Ок", "Закрыть", 3, true).ShowDialog();
            }

        }
    }
}
