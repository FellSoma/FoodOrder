using OrderFood.Entities;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OrderFood
{
    /// <summary>
    /// Логика взаимодействия для NewDish.xaml (сделал)
    /// сделай кнопку чтобы убирать лишние комбобоксы (сделал)
    /// сделай проверку на повторяющиеся ингридиенты+
    /// </summary>
    public partial class NewDish : Window
    {
        int i;
        string[] ingridientsArray;
        FoodOrderEntities2 db = new FoodOrderEntities2();
        public NewDish()
        {
            InitializeComponent();
            i = 0;
            massTextBoxs[0] = bxWeight;
            massComboBoxs[0] = cbIngridient;
            cbIngridient.ItemsSource = db.Products.ToList();
            MenuCompletion();
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
            if (massTextBoxs[0].Text == "" || massTextBoxs[0].Text == "0" || massComboBoxs[0].Text == "")
            {
                MessageBox.Show("Заполните массу ингридиентов \nУкажите все ингридиенты");
                return;
            }
            for (int i = 0; i < indexNameComboBoxs - 1; i++)
            {
                if (massComboBoxs[i].Text == massComboBoxs[++i].Text || massComboBoxs[i].Text == "")
                {
                    MessageBox.Show("Уберите повторяющиеся ингридиены");
                    return;
                }

            }
            for (int i = 0; i < indexNameComboBoxs; i++)
            {
                if (massTextBoxs[i].Text == "" || massTextBoxs[i].Text == "0")
                {
                    MessageBox.Show("Заполните массу ингридиентов");
                    return;
                }
                string word = massTextBoxs[i].Text;
                for (int j = 0; j < word.Length; j++)
                {
                    if (word[j] == '!' || word[j] == '@' || word[j] == '#' || word[j] == '$'
                        || word[j] == '%' || word[j] == '^' || word[j] == '&'
                        || word[j] == '*' || word[j] == '(' || word[j] == ')')
                    {
                        MessageBox.Show("Уберите лишние символы");
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
                Entities.Dish dish = new Entities.Dish()
                {
                    Name = nameDish.Text
                };
                Entities.Dish authDish = null;
                Entities.Product authIngridient = null;
                Entities.Menu authMenu = null;
                using (Entities.FoodOrderEntities2 context = new Entities.FoodOrderEntities2())
                {
                    authDish = context.Dishes.Where(b => b.Name == nameDish.Text).FirstOrDefault();
                    if (authDish != null)
                    {
                        MessageBox.Show("Такое блюдо уже есть");
                        return;
                    }
                    try
                    {
                        context.Dishes.Add(dish);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }

                    authDish = context.Dishes.Where(b => b.Name == nameDish.Text).FirstOrDefault();


                    for (int i = 0; i < indexNameCheckBox; i++)
                    {
                        if ((bool)massCheckBox[i].IsChecked)
                        {
                            string currentNameMenu = (string)massCheckBox[i].Content;
                            authMenu = context.Menus.Where(b => b.Name == currentNameMenu).FirstOrDefault();
                            DishesOfMenu dishesOfMenu = new DishesOfMenu();
                            dishesOfMenu.id_Menu = authMenu.id;
                            dishesOfMenu.id_Dishes = authDish.id;
                            context.DishesOfMenus.Add(dishesOfMenu);
                            context.SaveChanges();
                        }
                    }
                    if (authDish != null)
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
                                    dishesOfIngredient.id_Dishes = authDish.id;
                                    nowText = massTextBoxs[i].Text.Trim();
                                    dishesOfIngredient.weigth = Convert.ToDouble(nowText);
                                    context.DishesOfIngredients.Add(dishesOfIngredient);
                                    context.SaveChanges();
                                }
                            }
                        }
                        MessageBox.Show("Блюдо добавлено");
                    }
                }
            }
            else MessageBox.Show("Заполните поля");


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
                    if (indexNameComboBoxs < 9)
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
                        MessageBox.Show("Вы достигли лимита выбора услуг.");
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
                        MessageBox.Show("Вы достигли лимита выбора услуг.");
                    }
                    break;
                default:
                    break;
            }
        }
        private void Count_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

            if ((e.Key == Key.D0) || (e.Key == Key.D1) || (e.Key == Key.D2) || (e.Key == Key.D3) || (e.Key == Key.D4)
              || (e.Key == Key.D5) || (e.Key == Key.D6) || (e.Key == Key.D7) || (e.Key == Key.D8) || (e.Key == Key.D9)
              || (e.Key == Key.Decimal))
            {
                // цифра
                return;
            }


            // остальные символы запрещены
            e.Handled = true;
        }
    }
}
