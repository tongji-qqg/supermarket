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

namespace supermarket.HumanAffair
{
    class HumanAffairController
    {
         #region constructor
        public HumanAffairController()
        {         
        }
        #endregion 

        #region data
        private Window employeeInfoWin;
        private Window newEmployeeeWin;
        private Window usePermissionWin;        
        #endregion

        #region function
        public void showEmployeeInfo(SupermarketDataSet set)
        {
            if (!showIfWindowAlive(employeeInfoWin))
            {
                employeeInfoWin = new supermarket.HumanAffair.EmployeeInfo(set);
                employeeInfoWin.Show();
            }
        }
        public void showNewEmployee(SupermarketDataSet set)
        {
            if (!showIfWindowAlive(newEmployeeeWin))
            {
                newEmployeeeWin = new supermarket.HumanAffair.NewEmployee(set);
                newEmployeeeWin.Show();
            }
        }
        public void showUsePermission(SupermarketDataSet set)
        {
            if (!showIfWindowAlive(usePermissionWin))
            {
                usePermissionWin = new supermarket.HumanAffair.UsePermission(set);
                usePermissionWin.Show();
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
        #endregion
    }
}
