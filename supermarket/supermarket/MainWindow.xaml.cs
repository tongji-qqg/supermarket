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
        #endregion


        #region Constructor, Window_loaded
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            supermarketDataSet = ((supermarket.SupermarketDataSet)(this.FindResource("supermarketDataSet")));
        }
        #endregion


        #region Interaction

       



        private void HumanAffair_Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {               
                string content = button.Content as string;
                Window window = null;
                switch (content)
                {
                    case "招聘新员工":
                        window = new supermarket.HumanAffair.NewEmployee(supermarketDataSet);
                        break;
                    case "员工信息":                        
                    case "职位调动":                        
                    case "解聘员工":
                        window = new supermarket.HumanAffair.EmployeeInfo(supermarketDataSet);                        
                        break;
                    case "系统使用权限":
                        window = new supermarket.HumanAffair.UsePermission(supermarketDataSet);
                        break;
                    default:
                        break;
                }

                if (window != null)
                    window.Show();
            }
        }


        private void Sale_Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string content = button.Content as string;
                Window window = null;
                switch (content)
                {
                    case "商品档案":
                        break;
                    case "收银":      
                        Suppermarket_POS.POS  pos= new Suppermarket_POS.POS(1,"guoguo");            
                        pos.Show();
                        break;
                    case "新加会员":
                        window = new supermarket.sale.NewMember(supermarketDataSet);
                        break;
                    case "会员管理":
                        window = new supermarket.sale.MemberInfo(supermarketDataSet);
                        break;
                    case "价格调整":
                        window = new supermarket.sale.Price(supermarketDataSet);
                        break;
                    case "销售分析":
                        
                        break;
                    default:
                        break;
                }

                if (window != null)
                    window.Show();
            }
        }

        private void Inventory_Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string content = button.Content as string;
                Window window = null;
                switch (content)
                {
                    case "添加新商品":
                        window = new supermarket.Inventory.NewGoodsInfo(supermarketDataSet);
                        break;
                    case "管理商品档案":
                        window = new supermarket.Inventory.GoodsInfo(supermarketDataSet);
                        break;
                    case "商品入库":
                        window = new supermarket.Inventory.InInventory(supermarketDataSet);
                        break;
                    case "商品出库":

                    case "库存查询":
                        
                    case "过期管理":
                        window = new supermarket.Inventory.InventoryInfo(supermarketDataSet);
                        break;
                    default:
                        break;
                }

                if (window != null)
                    window.Show();
            }
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

        #endregion
    }
}
