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
        SupermarketDataSet sds;
        SupermarketDataSet.EmployeeRow er;
        #endregion

        public NewEmployee(SupermarketDataSet set)
        {
            InitializeComponent();
            sds = set;
            loadData();
        }

        public NewEmployee()
        {
            InitializeComponent();
            sds = new SupermarketDataSet();
            loadData();
        }

        private void loadData()
        {
            er = sds.Employee.NewEmployeeRow();
            newEmployeeGrid.DataContext = er;
            EmployeeSexComboBox.ItemsSource = new SexProvider().DefaultView;

            SupermarketDataSetTableAdapters.DepartmentTableAdapter dta =
                new SupermarketDataSetTableAdapters.DepartmentTableAdapter();
            dta.Fill(sds.Department);
        }

        #region interact
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                er.StartWorkDate = System.DateTime.Now;
                sds.Employee.AddEmployeeRow(er);
                SupermarketDataSetTableAdapters.EmployeeTableAdapter eta =
                   new SupermarketDataSetTableAdapters.EmployeeTableAdapter();
                eta.Update(sds.Employee);
                MessageBox.Show("信息已保存");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败" + ex.Message);
            }
        }
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
