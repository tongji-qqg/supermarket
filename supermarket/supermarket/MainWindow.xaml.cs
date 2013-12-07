using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace supermarket
{


    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Data Members
        private SupermarketDataSet supermarketDataSet;
        private MainController mainCont;
        SupermarketDataSet.EmployeeRow employee;
        Thickness[] tabMargins = {
             new Thickness(5,0,0,0),
             new Thickness(80,0,0,0),
             new Thickness(155,0,0,0),
             new Thickness(230,0,0,0),
             new Thickness(305,0,0,0)
        };
        #endregion


        #region Constructor, Window_loaded，init
        public MainWindow(SupermarketDataSet.EmployeeRow er)
        {
            InitializeComponent();
            mainCont = MainController.getMainController();
            employee = er;
            accessCont(er);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            supermarketDataSet = ((supermarket.SupermarketDataSet)(this.FindResource("supermarketDataSet")));
            EmployeeIDTextBlock.Text = employee.EmployeeID.ToString();
            EmployeeNameTextBlock.Text = employee.Name;
        }

        private void accessCont(SupermarketDataSet.EmployeeRow er)
        {
            int count = 0;
            TabItem ti = null;
            if (er.PermissionInventory)
            {
                TabItemStock.Margin = tabMargins[count];
                if (count == 0)
                    ti = TabItemStock;
                count++;
            }
            else 
            {
                TabItemStock.Visibility = Visibility.Collapsed;
            }

            if (er.PermissionSaleman || er.PermissionSaleManager)
            {
                TabItemSale.Margin = tabMargins[count];
                if (count == 0)
                    ti = TabItemSale;
                count++;
            }
            else
            {
                TabItemSale.Visibility = Visibility.Collapsed;
            }

            if (er.PermissionFinance)
            {
                TabItemFinance.Margin = tabMargins[count];
                if (count == 0)
                    ti = TabItemFinance;
                count++;
            }
            else
            {
                TabItemFinance.Visibility = Visibility.Collapsed;
            }

            if (er.PermissionHR)
            {
                TabItemHA.Margin = tabMargins[count];
                if (count == 0)
                    ti = TabItemHA;
                count++;
            }
            else
            {
                TabItemHA.Visibility = Visibility.Collapsed;
            }

            TabItemSys.Margin = tabMargins[count++];
            if (count == 0)
                ti = TabItemSys;

            ti.Focus();
        }
        #endregion


        #region Interaction

       



        private void HumanAffair_Button_Click(object sender, RoutedEventArgs e)
        {
            mainCont.HumanAffair_Button_Click(sender, supermarketDataSet);
        }


        private void Sale_Button_Click(object sender, RoutedEventArgs e)
        {
            mainCont.Sale_Button_Click(sender, supermarketDataSet);
        }


        private void Finance_Button_Click(object sender, RoutedEventArgs e)
        {
            mainCont.Finance_Button_Click(sender, supermarketDataSet);
        }


        private void Inventory_Button_Click(object sender, RoutedEventArgs e)
        {
            mainCont.Inventory_Button_Click(sender, supermarketDataSet);
        }

        private void System_Button_Click(object sender, RoutedEventArgs e)
        {
            mainCont.System_Button_Click(sender, supermarketDataSet);
        }

        #endregion


        #region Window Behavior Founction

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void maxButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void mniButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            Menu.IsOpen = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainCont.closeAllChildWin();
        }
        #endregion

     
    }


    public sealed class ErrorCode
    {
        public static string ConnectFailed = "连接数据库失败！";
        public static string InfoNotComplete = "请输入完整信息！";
        public static string InfoFormatError = "数据格式错误！";
        public static string InfoSaved = "信息已保存!";
        public static string SaveFailed = "保存失败！";
        public static string DeleteSucceed = "删除成功！";
        public static string DeleteFailed = "删除失败！";
    } 
}
