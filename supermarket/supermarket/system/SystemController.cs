using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace supermarket.system
{


    class SystemController
    {
        public static int employeeID = -1;
        public static int  tryTimes = 0;
        private bool flag = false;
        private Window ChangePasswordWin;
        private Window ChangeUserWin;

        public int getTryTimes()
        {
            if (tryTimes > 0)
                return tryTimes;
            else
                return 0;
        }
        public SupermarketDataSet.EmployeeRow processLogin(int id,string pwd)
        {
            tryTimes++;            

            SupermarketDataSet set = new SupermarketDataSet();
            SupermarketDataSetTableAdapters.EmployeeTableAdapter a
                = new SupermarketDataSetTableAdapters.EmployeeTableAdapter();
            SupermarketDataSet.EmployeeRow er;
            try
            {
                a.Fill(set.Employee);
            }
            catch{
                throw new Exception("数据库连接失败！");
            }
            try{
                er = set.Employee.FindByEmployeeID(id);

                if (er == null)
                {
                    flag = false;
                    throw new  Exception("无此员工");
                }
                else if (er.IsPasswordNull())
                {
                    flag = true;
                    System.Windows.Forms.MessageBox.Show("您未设置密码，请及时设置");
                }
                else if (er.Password == pwd)
                {
                   
                    flag = true;
                }
                else
                {
                    flag = false;
                    throw new Exception("密码错误!");
                }
            }
            catch(Exception ex)
            {
                flag = false;
                throw new Exception(ex.Message);
            }
            if (flag)
            {
                employeeID = id;
                return er;
            }
            else
                return null;
        }

        public SupermarketDataSet.EmployeeRow changePassword(string oldPwd,string newPwd,SupermarketDataSet sds)
        {
            sds.Employee.FindByEmployeeID(SystemController.employeeID)["Password"] = newPwd;

            SupermarketDataSetTableAdapters.EmployeeTableAdapter eta =
                 new SupermarketDataSetTableAdapters.EmployeeTableAdapter();

            eta.Update(sds.Employee);

            return sds.Employee.FindByEmployeeID(SystemController.employeeID);
        }


        public void showChangePassword(SupermarketDataSet set)
        {
            if (!showIfWindowAlive(ChangePasswordWin))
            {
                ChangePasswordWin = new supermarket.system.ChangePasswordWindow();
                ChangePasswordWin.Show();
            }
        }

        public void showChangeUser(SupermarketDataSet set)
        {
            if (!showIfWindowAlive(ChangeUserWin))
            {
                ChangeUserWin = new supermarket.system.LoginWindow();
                ChangeUserWin.Show();
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
    
    
    }


    
}
