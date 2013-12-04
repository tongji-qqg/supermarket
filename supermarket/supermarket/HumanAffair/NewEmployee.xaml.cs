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

namespace supermarket.HumanAffair
{
    /// <summary>
    /// NewEmployee.xaml 的交互逻辑
    /// </summary>
    public partial class NewEmployee : Window
    {
        #region Data
        MarketDataSet mds;
        MarketDataSet.EmployeeRow er;
        #endregion

        public NewEmployee(MarketDataSet set)
        {
            InitializeComponent();
            mds = set;
            loadData();
        }

        public NewEmployee()
        {
            InitializeComponent();
            mds = new MarketDataSet();
            loadData();
        }

        private void loadData()
        {
            er = mds.Employee.NewEmployeeRow();
            newEmployeeGrid.DataContext = er;
        }

        #region interact
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mds.Employee.AddEmployeeRow(er);
                MarketDataSetTableAdapters.EmployeeTableAdapter eta =
                   new MarketDataSetTableAdapters.EmployeeTableAdapter();
                eta.Update(mds.Employee);
                MessageBox.Show("信息已保存");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败" + ex.Message);
            }
        }
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            mds.Employee.RemoveEmployeeRow(er);
            this.Close();
        }
        #endregion
    }
}
