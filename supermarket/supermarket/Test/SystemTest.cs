using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using supermarket.system;
using AvalonUnitTesting;
using System.Windows;


namespace supermarket.Test
{
    [TestFixture]
    class SystemTest
    {
        [SetUp]
        public void mySetUpTest()
        {

        }//teardown

        [Test]
        public void test()
        {
            Assert.Catch(delegate
            {
                int a = 1;
                int b = 2;
                int sum = a + b;
                throw new Exception();
            });
            
        }

        [Test]
        public void ChangePasswordTest()
        {
           AvalonTestRunner.RunInSTA(
                delegate
                {
                   SystemController controller = new SystemController();

                   SupermarketDataSet.EmployeeRow er
                       = controller.processLogin(1, "888888");    
                   MainWindow testWindow = new MainWindow(er);
                   SupermarketDataSet sds = ((supermarket.SupermarketDataSet)(testWindow.FindResource("supermarketDataSet")));

                   controller.changePassword("888888", "999999", sds);
                });
        }

        [Test]
        public void loginTest()
        {
            //AvalonTestRunner.RunInSTA(
            //    delegate
            //    {
            //        LoginWindow window = new LoginWindow();
            //        window.loginTest();

            //        Assert.AreEqual(1, 1);
            //    });

            //Assert.Catch(
            //    delegate
            //    {
            //        LoginWindow window = new LoginWindow();
            //        window.loginTest();

            //        Assert.AreEqual(1, 1);
            //    }
            //);

        }

        #region logintest
        [Test]
        public void systemConTest()
        {
            SystemController controller = new SystemController();

            controller.processLogin(1, "888888");

        }

        [Test]
        public void systemConTest2()
        {
            Assert.Catch(typeof(Exception),delegate
            {
                SystemController controller = new SystemController();

                controller.processLogin(2, "999999");
            });

        }

        #endregion

    }
}
