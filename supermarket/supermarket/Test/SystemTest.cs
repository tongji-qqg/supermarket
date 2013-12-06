using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using supermarket.system;

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
        public void firstTest()
        {

            Assert.AreEqual(1, 1);
        }

        [Test]
        public void loginTest()
        {
           
            CrossThreadTestRunner runner = new CrossThreadTestRunner();

            int result = 0;
            runner.RunInSTA(
            delegate
            {
                Console.WriteLine(Thread.CurrentThread.GetApartmentState());

            
                LoginWindow testLogin = new LoginWindow();

                result = testLogin.loginTest();
     
              

            });

            Assert.AreEqual(1, result);

        }

    }
}
