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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace supermarket.finance
{
    class FinanceController
    {
        #region constructor
        public FinanceController()
        {         
        }
        #endregion 

        #region data
        private Window expenseInfoWin;
        private Window newExpenseWin;
        private Window profinWin;
        private Window salaryWin;
        #endregion

        #region function
        public void closeAllChildWin()
        {
            closeIfWindowAlive(expenseInfoWin);
            closeIfWindowAlive(newExpenseWin);
            closeIfWindowAlive(profinWin);
            closeIfWindowAlive(salaryWin);
        }
        public void showExpenseInfo(SupermarketDataSet set)
        {
            if(!showIfWindowAlive(expenseInfoWin))
            {
                expenseInfoWin = new supermarket.finance.ExpenseInfo();
                expenseInfoWin.Show();
            }
        }
        public void showNewExpense(SupermarketDataSet set)
        {
            if(!showIfWindowAlive(newExpenseWin))
            {
                newExpenseWin = new supermarket.finance.NewExpense();
                newExpenseWin.Show();
            }
        }
        public void showProfit(SupermarketDataSet set)
        {
            if(!showIfWindowAlive(profinWin))
            {
                profinWin = new supermarket.finance.Profit();
                profinWin.Show();
            }
        }
        public void showSalary(SupermarketDataSet set)
        {
            if(!showIfWindowAlive(salaryWin))
            {
                salaryWin = new supermarket.finance.Salary();
                salaryWin.Show();
            }
        }
        private bool showIfWindowAlive(Window w)
        {
            if (w != null && w.IsVisible)
            {
                w.Activate();
                return true;
            }
            else
                return false;
        }
        private void closeIfWindowAlive(Window w)
        {
            if (w != null && w.IsVisible)
                w.Close();
        }
        #endregion
    }
}
