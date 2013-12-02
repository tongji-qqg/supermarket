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
        private MarketDataSet marketDataSet;
        PromotionWindow promotionWindow;
        #endregion


        #region Constructor, Window_loaded
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            marketDataSet = ((supermarket.MarketDataSet)(this.FindResource("marketDataSet")));
        }
        #endregion


        #region Interaction

        private void Promotion_Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {                            
                if(promotionWindow == null)
                    promotionWindow = new PromotionWindow(PromotionEnum.None, marketDataSet);
                string content = button.Content as string;
                switch (content)
                {
                    case "价格调整":
                        promotionWindow.setFounction(PromotionEnum.ChangePrice);
                        promotionWindow.Show();
                        break;
                    case "限量购买":
                        promotionWindow.setFounction(PromotionEnum.Limit);
                        promotionWindow.Show();
                        break;
                    case "捆绑销售":
                        promotionWindow.setFounction(PromotionEnum.Together);
                        promotionWindow.Show();
                        break;
                    default:
                        break;
                }
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
