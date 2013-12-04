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
    /// UsePermission.xaml 的交互逻辑
    /// </summary>
    public partial class UsePermission : Window
    {

        #region Data
        MarketDataSet mds;
        #endregion

        public UsePermission()
        {
            InitializeComponent();
        }

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

        private void Save_Button_Click(object sender, RoutedEventArgs e)
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
}
