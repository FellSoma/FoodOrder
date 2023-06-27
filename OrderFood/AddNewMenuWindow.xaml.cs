using OrderFood.Entities;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OrderFood
{
    /// <summary>
    /// Логика взаимодействия для AddNewMenuWindow.xaml
    /// </summary>
    public partial class AddNewMenuWindow : Window
    {
        Entities.FoodOrderEntities2 db = new Entities.FoodOrderEntities2();
        public AddNewMenuWindow()
        {
            InitializeComponent();
            MenuCompletion();
        }

        int indexNameCheckBox = 0;
        CheckBox[] massCheckBox = new CheckBox[100];
        public void MenuCompletion()
        {
            foreach (var item in db.Organizations)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Name = "cbService" + indexNameCheckBox;
                indexNameCheckBox++;
                checkBox.Content = item.Name;
                checkBox.Margin = new Thickness(10, 0, 10, 5);
                massCheckBox[indexNameCheckBox - 1] = checkBox;
                if (indexNameCheckBox < 15)
                    MenuPanelLeft.Children.Add(checkBox);
                else if (indexNameCheckBox > 15 && indexNameCheckBox < 30)
                    MenuPanelMidlle.Children.Add(checkBox);
                else if (indexNameCheckBox > 30 && indexNameCheckBox < 45)
                    MenuPanelRight.Children.Add(checkBox);
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void addNewMenu(object sender, RoutedEventArgs e)
        {
            if (nameMenu.Text != "")
            {

                Entities.Menu currentMenu = new Entities.Menu();
                currentMenu = db.Menus.Where(b => b.Name == nameMenu.Text.Trim()).FirstOrDefault();

                if (currentMenu == null)
                {
                    Entities.Menu menu = new Entities.Menu()
                    {
                        Name = nameMenu.Text.Trim()
                    };
                    db.Menus.Add(menu);
                    db.SaveChanges();


                    for (int i = 0; i < indexNameCheckBox; i++)
                    {
                        if ((bool)massCheckBox[i].IsChecked)
                        {
                            string currentNameOrganization = (string)massCheckBox[i].Content;
                            Organization organization = db.Organizations.Where(b => b.Name == currentNameOrganization).FirstOrDefault();
                            OrganizationsOfMenu organizationOfMenu = new OrganizationsOfMenu();
                            organizationOfMenu.id_Menu = menu.id;
                            organizationOfMenu.id_Organization = organization.id;
                            db.OrganizationsOfMenus.Add(organizationOfMenu);
                            db.SaveChanges();
                        }
                    }

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
