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
namespace supermarket.finance
{
    /// <summary>
    /// ExpenseInfo.xaml 的交互逻辑
    /// </summary>
    public partial class ExpenseInfo : Window
    {
         #region Data
        SupermarketDataSet sds;        
        #endregion

        #region constructor
        public ExpenseInfo(SupermarketDataSet set)
        {
            InitializeComponent();
            sds = set;
            loadData();
        }
        public ExpenseInfo()
        {
            InitializeComponent();
            sds = new SupermarketDataSet();
            loadData();
        }
        #endregion

        #region helpFounction
        private void loadData()
        {
            SupermarketDataSetTableAdapters.ExpenseTableAdapter eta =
                new SupermarketDataSetTableAdapters.ExpenseTableAdapter();
            eta.Fill(sds.Expense);

            ExpenseInfoDataGrid.ItemsSource =
               new ObservableCollection<SupermarketDataSet.ExpenseRow>(sds.Expense.ToList());
        }
        #endregion

    }
}
