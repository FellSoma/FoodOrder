using OrderFood.Entities;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OrderFood
{
    /// <summary>
    /// Логика взаимодействия для EditDishWindow.xaml
    /// Здесь реализуйизменение имени и меню продукта а изменения продуктов сделай отдельным окном
    /// или седалй разделение изменений вначале чтобы продукты были запонены но к ним (Enabled false) только визуально
    /// потом реализуй смену объектов для изменения, с помощью DataContext(по другому ты не знаешь как дебил)
    /// </summary>
    public partial class EditDishWindow : Window
    {
        int i;
        string[] ingridientsArray;
        FoodOrderEntities2 db = new FoodOrderEntities2();
        Dish dishNow;
        int indexConnection = 1;
        DishesOfIngredient[] connectionIngridient;
        DishesOfMenu[] connectionMenu;
        public EditDishWindow(Entities.Dish selectetDish, Entities.Menu selectedMenu)
        {
            InitializeComponent();

            //Заполнение Меню
            Entities.FoodOrderEntities2 contextMenu = new Entities.FoodOrderEntities2();
            var currentMenu = contextMenu.DishesOfMenus.Where(b => b.id_Dishes.Equals(selectetDish.DishesOfMenus));
            int indexMenu = 0;
            dishNow = selectetDish;
            MenuCompletion();

            DataContext = selectetDish;

            i = 0;
            massTextBoxs[0] = bxWeight;
            massComboBoxs[0] = cbIngridient;
            cbIngridient.ItemsSource = db.Products.ToList();
            //Заполнние первого Ингридиента
            UpdateFillMass();
        }


        public void UpdateFillMass()
        {
            connectionIngridient = db.DishesOfIngredients.Where(b => b.id_Dishes == dishNow.id).ToArray();
            connectionMenu = db.DishesOfMenus.Where(b => b.id_Dishes == dishNow.id).ToArray();

            cbIngridient.SelectedIndex = connectionIngridient[0].id_ingridient - 1;
            bxWeight.Text = connectionIngridient[0].weigth.ToString();

            for (; indexConnection < connectionIngridient.Length; indexConnection++)
            {
                IngridientCompletion();
            }

        }

        public void IngridientCompletion()
        {

            ComboBox comboBox = new ComboBox();
            TextBox textBox = new TextBox();
            comboBox.Name = "cbService" + indexNameComboBoxs;
            textBox.Name = "cbService" + indexNameComboBoxs;
            indexNameComboBoxs++;
            comboBox.DisplayMemberPath = "Name";
            comboBox.Margin = new Thickness(10, 7, 10, 0);
            comboBox.ItemsSource = db.Products.ToList();
            comboBox.SelectedIndex = connectionIngridient[indexConnection].id_ingridient - 1;
            textBox.Height = 29;
            textBox.Text = connectionIngridient[indexConnection].weigth.ToString();
            textBox.KeyDown += Count_KeyDown;
            textBox.Style = (Style)Resources["Textboxes"];
            massComboBoxs[indexNameComboBoxs - 1] = comboBox;
            massTextBoxs[indexNameComboBoxs - 1] = textBox;
            panelIngridients.Children.Add(comboBox);
            panelWeith.Children.Add(textBox);

        }


        CheckBox[] massCheckBox = new CheckBox[100];

        int indexNameCheckBox = 0;
        public void MenuCompletion()
        {
            foreach (var item in db.Menus)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Name = "cbService" + indexNameCheckBox;
                indexNameCheckBox++;
                checkBox.Content = item.Name;
                checkBox.Margin = new Thickness(10, 0, 10, 5);
                massCheckBox[indexNameCheckBox - 1] = checkBox;
                var MenuConnected = db.DishesOfMenus.Where(b => b.id_Menu == item.id && b.id_Dishes == dishNow.id).FirstOrDefault();
                if (MenuConnected != null)
                {
                    checkBox.IsChecked = true;
                    MenuConnected = null;
                }
                else
                    checkBox.IsChecked = false;
                if (indexNameCheckBox < 6)
                    MenuPanelLeft.Children.Add(checkBox);
                else if (indexNameCheckBox > 6 && indexNameCheckBox < 12)
                    MenuPanelMidlle.Children.Add(checkBox);
                else if (indexNameCheckBox > 12 && indexNameCheckBox < 18)
                    MenuPanelRight.Children.Add(checkBox);
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void addDish(object sender, RoutedEventArgs e)
        {


            db.Dishes.AddOrUpdate(dishNow);
            db.SaveChanges();

            if (massTextBoxs[0].Text == "" || massTextBoxs[0].Text == "0" || massComboBoxs[0].Text == "")
            {
                new CustomMessageBox("Внимание!", "Заполните массу ингридиентов \nУкажите все ингридиенты", "Ок", "Закрыть", 3, true).ShowDialog();

                return;
            }
            if (!double.TryParse(massTextBoxs[0].Text, out double result))
            {
                new CustomMessageBox("Внимание!", "Масса  должна быть с плавающей запятой", "Ок", "Закрыть", 3, true).ShowDialog();
                return;
            }
            for (int i = 0; i < indexNameComboBoxs - 1; i++)
            {
                for (int j = 1; j <= indexNameComboBoxs - 1; j++)
                {
                    if (j != i)
                    {
                        if (massComboBoxs[i].Text == massComboBoxs[j].Text || massComboBoxs[j].Text == "" || massComboBoxs[i].Text == "")
                        {
                            new CustomMessageBox("Внимание!", "Уберите повторяющиеся ингридиены", "Ок", "Закрыть", 3, true).ShowDialog();
                            return;
                        }
                    }
                    if (!double.TryParse(massTextBoxs[i].Text, out double result1))
                    {
                        new CustomMessageBox("Внимание!", "Масса  должна быть с плавающей запятой", "Ок", "Закрыть", 3, true).ShowDialog();
                        break;
                    }
                }


            }
            for (int i = 0; i < indexNameComboBoxs; i++)
            {
                if (massTextBoxs[i].Text == "" || massTextBoxs[i].Text == "0")
                {
                    new CustomMessageBox("Внимание!", "Заполните массу ингридиентов", "Ок", "Закрыть", 3, true).ShowDialog();
                    return;
                }
                string word = massTextBoxs[i].Text;
                for (int j = 0; j < word.Length; j++)
                {
                    if (word[j] == '!' || word[j] == '@' || word[j] == '#' || word[j] == '$'
                        || word[j] == '%' || word[j] == '^' || word[j] == '&'
                        || word[j] == '*' || word[j] == '(' || word[j] == ')')
                    {
                        new CustomMessageBox("Внимание!", "Уберите лишние символы", "Ок", "Закрыть", 3, true).ShowDialog();
                        return;
                    }
                }

            }
            bool MenuChecked = false;
            for (int i = 0; i < indexNameCheckBox; i++)
            {
                if ((bool)massCheckBox[i].IsChecked)
                {
                    MenuChecked = true;
                }
            }
            if (nameDish.Text != "" && MenuChecked == true)
            {
                //Удаление старых связей
                db.DishesOfIngredients.RemoveRange(connectionIngridient);
                db.DishesOfMenus.RemoveRange(connectionMenu);
                db.SaveChanges();

                Entities.Dish authDish = null;
                Entities.Product authIngridient = null;
                Entities.Menu authMenu = null;
                using (Entities.FoodOrderEntities2 context = new Entities.FoodOrderEntities2())
                {
                    authDish = context.Dishes.Where(b => b.Name == nameDish.Text).FirstOrDefault();

                    for (int i = 0; i < indexNameCheckBox; i++)
                    {
                        if ((bool)massCheckBox[i].IsChecked)
                        {

                            string currentNameMenu = (string)massCheckBox[i].Content;
                            authMenu = context.Menus.Where(b => b.Name == currentNameMenu).FirstOrDefault();
                            DishesOfMenu dishesOfMenu = new DishesOfMenu();
                            dishesOfMenu.id_Menu = authMenu.id;
                            dishesOfMenu.id_Dishes = dishNow.id;
                            context.DishesOfMenus.Add(dishesOfMenu);
                            context.SaveChanges();
                        }
                    }
                    if (dishNow != null)
                    {
                        for (int i = 0; i < indexNameComboBoxs; i++)//проверь на макс элементов в  цикле, селай если, перед добовлением есть пустые столбцы спроси нужно 
                        {

                            if (massComboBoxs[i] != null)
                            {
                                var nowText = massComboBoxs[i].Text;
                                authIngridient = context.Products.Where(b => b.Name == nowText).FirstOrDefault();
                                if (authIngridient != null)
                                {
                                    DishesOfIngredient dishesOfIngredient = new DishesOfIngredient();
                                    dishesOfIngredient.id_ingridient = authIngridient.id;
                                    dishesOfIngredient.id_Dishes = dishNow.id;
                                    nowText = massTextBoxs[i].Text.Trim();
                                    dishesOfIngredient.weigth = Convert.ToDouble(nowText);
                                    context.DishesOfIngredients.Add(dishesOfIngredient);
                                    context.SaveChanges();
                                }
                            }
                        }
                        new CustomMessageBox("Внимание!", "Блюдо изменено", "Ок", "Закрыть", 1, true).ShowDialog();
                        UpdateFillMass();
                    }
                }
            }
            else new CustomMessageBox("Внимание!", "Заполните поля", "Ок", "Закрыть", 3, true).ShowDialog();

        }

        ComboBox[] massComboBoxs = new ComboBox[100];
        TextBox[] massTextBoxs = new TextBox[100];
        int indexNameComboBoxs = 1;
        private void AddIngridient(object sender, RoutedEventArgs e)
        {
            Button vibor2 = new Button();
            vibor2 = (Button)sender;

            switch (vibor2.Content)
            {
                case "+":
                    if (indexNameComboBoxs < 15)
                    {
                        ComboBox comboBox = new ComboBox();
                        TextBox textBox = new TextBox();
                        comboBox.Name = "cbService" + indexNameComboBoxs;
                        textBox.Name = "cbService" + indexNameComboBoxs;
                        indexNameComboBoxs++;
                        comboBox.DisplayMemberPath = "Name";
                        comboBox.Margin = new Thickness(10, 7, 10, 0);
                        comboBox.ItemsSource = db.Products.ToList();
                        comboBox.SelectedIndex = 0;
                        textBox.Height = 29;
                        textBox.KeyDown += Count_KeyDown;
                        textBox.Style = (Style)Resources["Textboxes"];
                        massComboBoxs[indexNameComboBoxs - 1] = comboBox;
                        massTextBoxs[indexNameComboBoxs - 1] = textBox;
                        panelIngridients.Children.Add(comboBox);
                        panelWeith.Children.Add(textBox);
                    }
                    else
                    {
                        new CustomMessageBox("Внимание!", "Вы достигли лимита выбора услуг.", "Ок", "Закрыть", 1, true).ShowDialog();
                    }
                    break;
                case "-":
                    if (indexNameComboBoxs > 1)
                    {
                        ComboBox comboBox = new ComboBox();
                        TextBox textBox = new TextBox();
                        panelIngridients.Children.Remove(massComboBoxs[indexNameComboBoxs - 1]);
                        panelWeith.Children.Remove(massTextBoxs[indexNameComboBoxs - 1]);
                        massComboBoxs[indexNameComboBoxs - 1] = null;
                        massTextBoxs[indexNameComboBoxs - 1] = null;
                        indexNameComboBoxs--;

                    }
                    else
                    {
                        new CustomMessageBox("Внимание!", "Вы достигли лимита выбора услуг.", "Ок", "Закрыть", 1, true).ShowDialog();
                    }
                    break;
                default:
                    break;
            }
        }
        private void Count_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
          
        }
    }
}
