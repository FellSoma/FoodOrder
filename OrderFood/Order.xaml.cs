using Microsoft.Office.Interop.Word;
using OrderFood.Entities;
using System;
using System.Linq;
using System.Windows;

namespace OrderFood
{
    /// <summary>
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : System.Windows.Window
    {
        int countRows;
        int countColmns;
        Dish[] orderArray;
        Int32[] countArray;
        int j = 0;
        public Order(Int32[] array, Dish[] array1)
        {
            InitializeComponent();
            orderArray = array1;
            countArray = array;

        }
        object[,] SummWeigth;
        object[] DofiArray;
        Entities.Product[] ProductsRow;
        Product authProduct;
        FoodOrderEntities2 db = new FoodOrderEntities2();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < orderArray.Length; i++)
            {
                if (countArray[i].ToString() != "0")
                {
                    countColmns++;
                    ListViewOrder.Items.Add(orderArray[i].Name + " " + countArray[i].ToString() + " порций");
                }
            }
            ListViewOrder.Items.Add("------------------------------------------------");
            ListViewOrder.Items.Add("");

            Product[] productArray = db.Products.ToArray();
            SummWeigth = new object[db.Products.Count(), 2];
            for (int j = 0; j < db.Products.Count(); j++)
            {
                SummWeigth[j, 0] = productArray[j];
                SummWeigth[j, 1] = 0;
            }

            for (int i = 0; i < orderArray.Length; i++)
            {
                if (countArray[i].ToString() != "0")
                {
                    ListViewOrder.Items.Add(orderArray[i].Name + " " + countArray[i].ToString() + " порций" + ":");
                    Entities.Product authIngridient = null;
                    Entities.Dish authDish = null;

                    using (Entities.FoodOrderEntities2 context = new Entities.FoodOrderEntities2())
                    {
                        string currentName = orderArray[i].Name.Trim();
                        authDish = context.Dishes.Where(b => b.Name == currentName).FirstOrDefault();
                        if (authDish != null)
                        {
                            DofiArray = db.DishesOfIngredients.Where(x => x.id_Dishes == authDish.id).ToArray();
                            double weigth;
                            foreach (DishesOfIngredient item in DofiArray)
                            {
                                Entities.DishesOfIngredient currentDOfI = (DishesOfIngredient)item;
                                authIngridient = context.Products.Where(b => b.id == currentDOfI.id_ingridient).FirstOrDefault();

                                weigth = (double)(item.weigth * Convert.ToDouble(countArray[i]));

                                for (int l = 0; l < db.Products.Count(); l++)
                                {
                                    authProduct = (Product)SummWeigth[l, 0];
                                    if (authProduct.id == authIngridient.id)
                                    {
                                        if (Double.TryParse(SummWeigth[l, 1].ToString(), out Double value))
                                        {
                                            SummWeigth[l, 1] = weigth + value;

                                        }
                                    }
                                }
                                if (weigth > 1000)
                                {
                                    countRows++;
                                    weigth = weigth / 1000;
                                    ListViewOrder.Items.Add(authIngridient.Name.ToString() + " " + weigth.ToString()
                                    + " (" + authIngridient.Unit.Name + ") " + "Кг");
                                }
                                else
                                {
                                    countRows++;
                                    ListViewOrder.Items.Add(authIngridient.Name.ToString() + " " + weigth.ToString()
                                    + " (" + authIngridient.Unit.Name + ") " + "Гр");
                                }
                            }
                        }
                    }
                    ListViewOrder.Items.Add("");
                }
            }
            ListViewOrder.Items.Add("------------------------------------------------");
            ListViewOrder.Items.Add("Общие масса ингридиентов");
            ProductsRow = new Entities.Product[db.Products.Count()];
            for (int i = 0; i < db.Products.Count(); i++)
            {
                if (Double.TryParse(SummWeigth[i, 1].ToString(), out Double value))
                {
                    if (value != 0)
                    {

                        authProduct = (Product)SummWeigth[i, 0];
                        if ((double)SummWeigth[i, 1] > 1000)
                        {
                            ProductsRow[i] = authProduct;
                            ListViewOrder.Items.Add(authProduct.Name + " " + ((double)SummWeigth[i, 1] / 1000).ToString() + " (" + authProduct.Unit.Name + ") " + "Кг");
                        }
                        else
                        {
                            ProductsRow[i] = authProduct;
                            ListViewOrder.Items.Add(authProduct.Name + " " + (SummWeigth[i, 1]).ToString() + " (" + authProduct.Unit.Name + ") " + "Гр");
                        }

                    }
                }
            }


        }

        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PrintButton(object sender, RoutedEventArgs e)
        {
            var application = new Microsoft.Office.Interop.Word.Application();

            Document document = application.Documents.Add();

            Paragraph tableParagaph = document.Paragraphs.Add();
            Range tableRange = tableParagaph.Range;
            Table orderTable = document.Tables.Add(tableRange, ProductsRow.Length + 1, countColmns + 2);
            orderTable.Borders.InsideLineStyle = orderTable.Borders.OutsideLineStyle
                = WdLineStyle.wdLineStyleSingle;
            orderTable.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Range cellRange;
            cellRange = orderTable.Cell(1, 1).Range;
            cellRange.Text = "Наименование продуктов";
            cellRange = orderTable.Cell(1, countColmns + 2).Range;
            cellRange.Text = "Количество продуктов";
            for (int i = 0; i < 1; i++)
            {
                int x = 0;
                for (int j = 1; j <= countColmns; j++)
                {
                    if (countArray != null)
                    {
                        cellRange = orderTable.Cell(1, j + 1).Range;
                        cellRange.Text = orderArray[x].Name;
                        x++;
                    }
                }
            }

            for (int i = 0; i < 1; i++)
            {
                int x = 0;
                for (int j = 1; j <= ProductsRow.Length; j++)
                {
                    if (countArray != null)
                    {
                        orderTable.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        //  cellRange = orderTable.Cell(1, j).Range.HorizontalInVertical = WdHorizontalInVerticalType.wdHorizontalInVerticalResizeLine;
                        cellRange = orderTable.Cell(j+1, 1).Range;
                        cellRange.Text = ProductsRow[x].Name;
                        x++;
                    }
                }
            }

            application.Visible = true;
            object filenameDox = $@"Формирования заказа {DateTime.Now.ToShortDateString()}.docx";
            object filenamePdf = $@"Формирования заказа {DateTime.Now.ToShortDateString()}.pdf";
            document.SaveAs2(filenameDox);
            document.SaveAs2(filenamePdf, WdExportFormat.wdExportFormatPDF);

        }
    }
}
