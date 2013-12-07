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

namespace supermarket.system
{
    /// <summary>
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        #region  Data
        SupermarketDataSet sds;
        SupermarketDataSet.EmployeeRow er;
        SystemController systemcontroller = new SystemController();
        #endregion

        #region constructors
        public ChangePasswordWindow()
        {
            InitializeComponent();
            sds = new SupermarketDataSet();
            loadData();
        }

        public ChangePasswordWindow(SupermarketDataSet set)
        {
            InitializeComponent();
            sds = set;
            loadData();
        }

        private void loadData()
        {
            er = sds.Employee.NewEmployeeRow();
           // er = sds.Employee.FindByEmployeeID(SystemController.employeeID);
            
            SupermarketDataSetTableAdapters.EmployeeTableAdapter eta =
                new SupermarketDataSetTableAdapters.EmployeeTableAdapter();
            eta.Fill(sds.Employee);

        }

        #endregion 

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (OldPassword.Password == "")
            {
                MessageBox.Show("请输入密码！");
                return;
            }
            if (NewPassword.Password == "")
            {
                MessageBox.Show("请输入新密码！");
                return;
            }
            if (OldPassword.Password == er.Password)
            {
                try
                {
                    systemcontroller.changePassword(OldPassword.Password, NewPassword.Password, sds);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("密码更改失败！");
                }
            }
            else
            {
                OldPassword.Clear();
                NewPassword.Clear();
                MessageBox.Show("密码错误!");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void test(string oldPwd,string newPwd)
        {
            InitializeComponent();
            sds = new SupermarketDataSet();
            loadData();

            OldPassword.Password = oldPwd;
            NewPassword.Password = newPwd;

            ConfirmButton_Click(this, new RoutedEventArgs());

        }
    }
}
