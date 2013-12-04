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
        private void loadData()
        {
            supermarket.MarketDataSetTableAdapters.DepartmentTableAdapter adapter1
                = new MarketDataSetTableAdapters.DepartmentTableAdapter();
            adapter1.Fill(mds.Department);

            supermarket.MarketDataSetTableAdapters.EmployeeTableAdapter adapter2
                = new MarketDataSetTableAdapters.EmployeeTableAdapter();
            adapter2.Fill(mds.Employee);

            var v = mds.Employee.ToList();
            EmployeeInfoDataGrid.ItemsSource = new ObservableCollection<MarketDataSet.EmployeeRow>(mds.Employee.ToList());
            //EmployeeInfoDataGrid.DataContext = new ObservableCollection<MarketDataSet.EmployeeRow>(mds.Employee);
            //EmployeeInfoDataGrid.ItemsSource = mds.Employee.DefaultView;                   
        }
    }
}
