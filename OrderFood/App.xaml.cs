using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OrderFood
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly Entities.FoodOrderEntities2 Database = new Entities.FoodOrderEntities2();

        public static ConnectionWindow User_id = new ConnectionWindow();

    }
}
