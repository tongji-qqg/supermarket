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
    public partial class Window
    {
        BoolWrapper isAlive;
        public void StartLife(ref BoolWrapper b)
        {
            isAlive = b;
            isAlive.Value = true;
            this.Closed += new EventHandler(Window_Closed);
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            isAlive.Value=false;
        }
    }
}
