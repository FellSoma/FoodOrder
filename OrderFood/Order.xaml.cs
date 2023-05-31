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
        object[,,] WdCellCount;
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
            SummWeigth = new object[db.Products.Count(), 3];
            WdCellCount = new object[orderArray.Length, db.DishesOfIngredients.Count(), 4];
            for (int j = 0; j < db.Products.Count(); j++)
            {
                SummWeigth[j, 0] = productArray[j];
                SummWeigth[j, 1] = 0;
                SummWeigth[j, 2] = false;
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
                            int indexDofi = 0;
                            foreach (DishesOfIngredient item in DofiArray)
                            {
                                WdCellCount[i, 0, 0] = authDish;
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

                                            WdCellCount[i, l, 1] = authIngridient;
                                            WdCellCount[i, l, 2] = value;
                                            WdCellCount[i, l, 3] = false;

                                            SummWeigth[l, 1] = weigth + value;
                                        }
                                    }
                                }
                                if (weigth > 1000)
                                {
                                    WdCellCount[i, indexDofi, 3] = true;
                                    countRows++;
                                    weigth = weigth / 1000;
                                    ListViewOrder.Items.Add(authIngridient.Name.ToString() + " " + weigth.ToString()
                                    + " (" + authIngridient.Unit.Name + ") " + "Кг");
                                }
                                else
                                {
                                    WdCellCount[i, indexDofi, 3] = false;
                                    countRows++;
                                    ListViewOrder.Items.Add(authIngridient.Name.ToString() + " " + weigth.ToString()
                                    + " (" + authIngridient.Unit.Name + ") " + "Гр");
                                }
                                indexDofi++;
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
                            SummWeigth[i, 2] = true;
                            ProductsRow[indexProductRow] = authProduct;
                            indexProductRow++;
                            ListViewOrder.Items.Add(authProduct.Name + " " + ((double)SummWeigth[i, 1] / 1000).ToString() + " (" + authProduct.Unit.Name + ") " + "Кг");
                        }
                        else
                        {
                            SummWeigth[i, 2] = false;
                            ProductsRow[indexProductRow] = authProduct;
                            indexProductRow++;
                            ListViewOrder.Items.Add(authProduct.Name + " " + (SummWeigth[i, 1]).ToString() + " (" + authProduct.Unit.Name + ") " + "Гр");
                        }

                    }
                }
            }


        }
        int indexProductRow = 0;
        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PrintButton(object sender, RoutedEventArgs e)
        {
            var application = new Microsoft.Office.Interop.Word.Application();

            Document document = application.Documents.Add();

            document.PageSetup.BottomMargin = 1;
            document.PageSetup.TopMargin = 20;
            document.PageSetup.LeftMargin = 30;
            document.PageSetup.RightMargin = 30;

            Paragraph tableParagaph = document.Paragraphs.Add();
            Range tableRange = tableParagaph.Range;
            Table orderTable = document.Tables.Add(tableRange, indexProductRow + 1, 2);//
            orderTable.Borders.InsideLineStyle = orderTable.Borders.OutsideLineStyle
                = WdLineStyle.wdLineStyleSingle;
            orderTable.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;


            Range cellRange;
            cellRange = orderTable.Cell(1, 1).Range;
            cellRange.Text = "Наименование продуктов";
            cellRange = orderTable.Cell(1, 2).Range;
            cellRange.Text = "Количество продуктов";

            int x = 0;
            int countDishes= 0;
          // for (int j = 1; j <= countColmns; j++)
          // {
          //     if (countArray != null)
          //     {
          //         cellRange = orderTable.Cell(1, j + 1).Range;
          //         cellRange.Text = orderArray[x].Name;
          //         countDishes++;
          //         x++;
          //     }
          // }



            x = 0;
            for (int j = 1; j <= indexProductRow; j++)
            {
                if (countArray != null)
                {
                    orderTable.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    if (Convert.ToDouble(SummWeigth[x, 1]) != 0)
                    {
                        if ((bool)SummWeigth[x, 2])
                        {
                            cellRange = orderTable.Cell(j + 1, 2).Range;
                            cellRange.Text = Convert.ToDouble((double)SummWeigth[x, 1] / 1000).ToString() + " Кг";
                        }
                        else
                        {
                            cellRange = orderTable.Cell(j + 1, 2).Range;
                            cellRange.Text = Convert.ToDouble((double)SummWeigth[x, 1]).ToString() + " Гр";
                        }

                    }
                    else
                    j--;
                    x++;
                }
            }

            x = 0;
            for (int j = 1; j <= indexProductRow; j++)
            {
                if (countArray != null)
                {

                    orderTable.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    //  cellRange = orderTable.Cell(1, j).Range.HorizontalInVertical = WdHorizontalInVerticalType.wdHorizontalInVerticalResizeLine;
                    cellRange = orderTable.Cell(j + 1, 1).Range;
                    cellRange.Text = ProductsRow[x].Name;
                    x++;
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
