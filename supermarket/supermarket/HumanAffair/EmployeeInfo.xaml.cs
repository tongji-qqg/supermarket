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

    public enum Sex { 男, 女 };  //注意 写在命名空间内 ，不要写在类里，否则台前local:Sex找不到路径  

    /// <summary>
    /// EmployeeInfo.xaml 的交互逻辑
    /// </summary>
    public partial class EmployeeInfo : Window
    {
        #region Data
        MarketDataSet mds;
        #endregion

        #region constructor
        public EmployeeInfo(MarketDataSet set)
        {
            InitializeComponent();
            mds = set;
            loadData();
        }
        public EmployeeInfo()
        {
            InitializeComponent();
            mds = new MarketDataSet();
            loadData();
        }
        #endregion

        #region helpFounction
        private void loadData()
        {
            supermarket.MarketDataSetTableAdapters.EmployeeTableAdapter adapter2
                = new MarketDataSetTableAdapters.EmployeeTableAdapter();
            adapter2.Fill(mds.Employee);

            var v = mds.Employee.ToList();
            EmployeeInfoDataGrid.ItemsSource = new ObservableCollection<MarketDataSet.EmployeeRow>(mds.Employee.ToList());
            //EmployeeInfoDataGrid.DataContext = new ObservableCollection<MarketDataSet.EmployeeRow>(mds.Employee);
            //EmployeeInfoDataGrid.ItemsSource = mds.Employee.DefaultView;                   
        }
        #endregion

        #region interact
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            if (modifyEmployeeInfoGrid.DataContext != null)
            {
                MarketDataSetTableAdapters.EmployeeTableAdapter eta =
                    new MarketDataSetTableAdapters.EmployeeTableAdapter();
                try
                {
                    eta.Update(mds.Employee);
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
                MarketDataSetTableAdapters.EmployeeTableAdapter eta =
                    new MarketDataSetTableAdapters.EmployeeTableAdapter();
                supermarket.MarketDataSet.EmployeeRow er = 
                    modifyEmployeeInfoGrid.DataContext as MarketDataSet.EmployeeRow;
                mds.Employee.RemoveEmployeeRow(er);
                try
                {
                    eta.Update(mds.Employee);
                    EmployeeInfoDataGrid.ItemsSource = new ObservableCollection<MarketDataSet.EmployeeRow>(mds.Employee.ToList());
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
}
