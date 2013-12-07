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
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Windows.Media.Animation;

namespace supermarket.system
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    /// 

    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        #region data
        SystemController systemcontroller = new SystemController();
        #endregion

        #region interface
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard sbd = Resources["leafLeave"] as Storyboard;
            sbd.Begin();

            Storyboard baiyun = Resources["cloudMove"] as Storyboard;
            baiyun.Begin();
        }

        #endregion

        #region animation
        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            Image ig = sender as Image;
            if (ig.Tag.ToString() == "close")
            {
                Uri ur = new Uri("../images/close1.png", UriKind.Relative);
                BitmapImage bp = new BitmapImage(ur);
                ig.Source = bp;
            }
            else
            {
                Uri ur = new Uri("../images/mini1.png", UriKind.Relative);
                BitmapImage bp = new BitmapImage(ur);
                ig.Source = bp;
            }
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            Image ig = sender as Image;
            if (ig.Tag.ToString() == "close")
            {
                Uri ur = new Uri("../images/close0.png", UriKind.Relative);
                BitmapImage bp = new BitmapImage(ur);
                ig.Source = bp;
            }
            else
            {
                Uri ur = new Uri("../images/mini0.png", UriKind.Relative);
                BitmapImage bp = new BitmapImage(ur);
                ig.Source = bp;
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image ig = sender as Image;
            if (ig.Tag.ToString() == "close")
            {
                App.Current.Shutdown();          
            }
            else this.WindowState = System.Windows.WindowState.Minimized; ;
        }
        #endregion
        
        #region login
        private void LoginInButtonDown(object sender, RoutedEventArgs e)
        {
            SupermarketDataSet.EmployeeRow er;

            if (systemcontroller.getTryTimes() > 5)
            {
                MessageBox.Show("密码输入错误过多！");
                return;
            }
                try
                {
                    int id = -1;
                    id = Convert.ToInt32(txtName.Text);
                    er = systemcontroller.processLogin(id, txtPass.Password);                    
                }
                catch(Exception ex) 
                {
                    MessageBox.Show("登录失败，原因："+ex.Message);
                    return;
                }

                if (er != null)
                {
                    MainController.getMainController().startMainWindow(er);
                    this.Close();
                }
        }

        private void CancelInButtonDown(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
        #endregion

        public void loginTest()
        {
            
        }


    }
}
