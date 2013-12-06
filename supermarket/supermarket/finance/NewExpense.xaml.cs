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

namespace supermarket.finance
{
    /// <summary>
    /// NewExpense.xaml 的交互逻辑
    /// </summary>
    public partial class NewExpense : Window
    {
        #region Data
        SupermarketDataSet sds;
        SupermarketDataSet.ExpenseRow er;
        #endregion

        #region constructor
        public NewExpense(SupermarketDataSet set)
        {
            InitializeComponent();
            sds = set;
            loadData();
        }

        public NewExpense()
        {
            InitializeComponent();
            sds = new SupermarketDataSet();
            loadData();
        }
        #endregion
        private void loadData()
        {
            er = sds.Expense.NewExpenseRow();
            newExpenseGrid.DataContext = er;            
        }

        #region interact
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            if (er.IsMoneyNull() || er.IsReasonNull())
            {
                MessageBox.Show("请输入完整信息！");
                return;
            }
            try
            {
                er.Date = System.DateTime.Now;
                er.EmployeeID = 0;
                sds.Expense.AddExpenseRow(er);
                SupermarketDataSetTableAdapters.ExpenseTableAdapter eta =
                   new SupermarketDataSetTableAdapters.ExpenseTableAdapter();
                eta.Update(sds.Expense);
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
