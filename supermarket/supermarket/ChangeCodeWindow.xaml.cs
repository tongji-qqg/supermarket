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

namespace supermarket
{
    /// <summary>
    /// Interaction logic for ChangeCodeWindow.xaml
    /// </summary>
    public partial class ChangeCodeWindow : Window
    {
        public ChangeCodeWindow()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
