using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using supermarket.finance;
using AvalonUnitTesting;

namespace supermarket.Test
{
    [TestFixture]
    class FinanceTest
    {
        private SupermarketDataSet testDataSet;
        private FinanceController testController;

        [SetUp]
        public void setUp()
        {
            testDataSet = new SupermarketDataSet();
            testController = new FinanceController();
        }

        [Test]
        public void ShowExpenseInfoTest()
        {
            AvalonTestRunner.RunInSTA(
                delegate
                {
                    //ExpenseInfo testWindow = new ExpenseInfo();
                    //testWindow.Show();
                    testController.showExpenseInfo(testDataSet);
                }
            );
        }

        [Test]
        public void NewExpenseTest()
        {
            AvalonTestRunner.RunInSTA(
                delegate
                {
                    NewExpense testWindow = new NewExpense();

                    testController.showNewExpense(testDataSet);

                });
        }


        [Test]
        public void ProfitTest()
        {
            AvalonTestRunner.RunInSTA(
                delegate
                {
                   // testController.showProfit(testDataSet);
                });
        }

        [Test]
        public void SalaryTest()
        {
            AvalonTestRunner.RunInSTA(
                delegate
                {
                    testController.showSalary(testDataSet);
                });
        }
    }
}
