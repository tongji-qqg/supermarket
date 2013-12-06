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
using System.Collections.ObjectModel;

namespace supermarket.HumanAffair
{    

    /// <summary>
    /// EmployeeInfo.xaml 的交互逻辑
    /// </summary>
    public partial class EmployeeInfo : Window
    {
        #region Data
        SupermarketDataSet sds;        
        #endregion

        #region constructor
        public EmployeeInfo(SupermarketDataSet set)
        {
            InitializeComponent();
            sds = set;
            loadData();
        }
        public EmployeeInfo()
        {
            InitializeComponent();
            sds = new SupermarketDataSet();
            loadData();
        }
        #endregion

        #region helpFounction
        private void loadData()
        {
            SupermarketDataSetTableAdapters.EmployeeTableAdapter eta =
                new SupermarketDataSetTableAdapters.EmployeeTableAdapter();
            SupermarketDataSetTableAdapters.DepartmentTableAdapter dta =
                new SupermarketDataSetTableAdapters.DepartmentTableAdapter();
            eta.Fill(sds.Employee);
            dta.Fill(sds.Department);

            SupermarketDataSet.DepartmentDataTable tmpdt= new SupermarketDataSet.DepartmentDataTable();
            dta.Fill(tmpdt);
            DepartmentComboBox.ItemsSource = tmpdt.DefaultView;
            EmployeeSexComboBox.ItemsSource = new SexProvider().DefaultView;

            setItemSource();              
        }
        private void setItemSource()
        {
            EmployeeInfoDataGrid.ItemsSource = 
                new ObservableCollection<SupermarketDataSet.EmployeeRow>(sds.Employee.ToList());
        }
        #endregion

        #region interact
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            if (modifyEmployeeInfoGrid.DataContext != null)
            {
                SupermarketDataSetTableAdapters.EmployeeTableAdapter eta =
                    new SupermarketDataSetTableAdapters.EmployeeTableAdapter();
                try
                {
                    eta.Update(sds.Employee);
                    MessageBox.Show("保存修改成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败！" + ex.Message);
                }
            }
        }

        private void Dismiss_Button_Click(object sender, RoutedEventArgs e)
        {
            if (modifyEmployeeInfoGrid.DataContext != null)
            {                                
                try
                {
                    SupermarketDataSet.EmployeeRow er =
                    modifyEmployeeInfoGrid.DataContext as SupermarketDataSet.EmployeeRow;
                    er.Delete();

                    SupermarketDataSetTableAdapters.EmployeeTableAdapter eta =
                        new SupermarketDataSetTableAdapters.EmployeeTableAdapter();

                    eta.Update(sds.Employee);
                    setItemSource();
                    MessageBox.Show("删除信息成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败！" + ex.Message);
                }
            }
        }
        private void EmployeeInfoDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeeInfoDataGrid.SelectedItem != null)
            {                                
                modifyEmployeeInfoGrid.DataContext = EmployeeInfoDataGrid.SelectedItem;
            }
            else
            {
                modifyEmployeeInfoGrid.DataContext = null;
            }
        }
        #endregion
    }

    class SexProvider : System.Data.DataTable
    {
        public SexProvider()
        {
            this.Columns.Add("name");
            this.Columns.Add("value");
            System.Data.DataRow dr = this.NewRow();
            dr[0] = "男";
            dr[1] = 0;
            this.Rows.Add(dr);
            dr = this.NewRow();
            dr[0] = "女";
            dr[1] = 1;
            this.Rows.Add(dr);
        }
    }
}
