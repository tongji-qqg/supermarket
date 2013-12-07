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
        SupermarketDataSet sds;
        #endregion

        public UsePermission(SupermarketDataSet set)
        {
            InitializeComponent();
            sds = set;
            loadData();
        }

        #region helpFounction
        private void loadData()
        {
            SupermarketDataSetTableAdapters.EmployeeTableAdapter eta =
                 new SupermarketDataSetTableAdapters.EmployeeTableAdapter();

            eta.Fill(sds.Employee);
            
            EmployeeInfoDataGrid.ItemsSource = new ObservableCollection<SupermarketDataSet.EmployeeRow>(sds.Employee.ToList());                           
        }
        #endregion

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            SupermarketDataSetTableAdapters.EmployeeTableAdapter eta =
                new SupermarketDataSetTableAdapters.EmployeeTableAdapter();
            try
            {
                eta.Update(sds.Employee);
                MessageBox.Show(ErrorCode.InfoSaved);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorCode.SaveFailed + ex.Message);
            }
        }
    }
}
