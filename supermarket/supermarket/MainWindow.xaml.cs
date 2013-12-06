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
        private MainController mainCont = new MainController();
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
