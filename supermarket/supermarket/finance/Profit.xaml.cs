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

using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;

namespace supermarket.finance
{
    /// <summary>
    /// Profit.xaml 的交互逻辑
    /// </summary>
    public partial class Profit : Window
    {
        #region Data
        SupermarketDataSet sds;
        enum showSalesType { hour, day, month, year }
        private ObservableDataSource<Point> SalesIncomedataSource = new ObservableDataSource<Point>();
        private ObservableDataSource<Point> SalesProfitdataSource = new ObservableDataSource<Point>();
        #endregion

        #region constructor
        public Profit(SupermarketDataSet set)
        {
            InitializeComponent();
            sds = set;
            loadData();
        }
        public Profit()
        {
            InitializeComponent();
            sds = new SupermarketDataSet();
            loadData();
        }
        #endregion

        #region helpFounction
        private void initDataset()
        {
            SupermarketDataSetTableAdapters.DaySaleIncomeTableAdapter da = new SupermarketDataSetTableAdapters.DaySaleIncomeTableAdapter();
            SupermarketDataSetTableAdapters.MonthSaleIncomeTableAdapter ma = new SupermarketDataSetTableAdapters.MonthSaleIncomeTableAdapter();
            SupermarketDataSetTableAdapters.YearSaleIncomeTableAdapter ya = new SupermarketDataSetTableAdapters.YearSaleIncomeTableAdapter();
            SupermarketDataSetTableAdapters.CategoryIncomeTableAdapter ca = new SupermarketDataSetTableAdapters.CategoryIncomeTableAdapter();
            da.Fill(sds.DaySaleIncome);
            ma.Fill(sds.MonthSaleIncome);
            ya.Fill(sds.YearSaleIncome);
            ca.Fill(sds.CategoryIncome);
            
            plotter.AddLineGraph(SalesIncomedataSource, Colors.Green, 2, "销售额");
            plotter.AddLineGraph(SalesProfitdataSource, Colors.Yellow, 2, "利润");
        }

        private void loadData()
        {
            SupermarketDataSetTableAdapters.ExpenseTableAdapter eta =
                new SupermarketDataSetTableAdapters.ExpenseTableAdapter();
            eta.Fill(sds.Expense);

            initDataset();

            DateTime now = System.DateTime.Now;
            DateTime dt = new DateTime(now.Year, now.Month, 1);
            dt.AddSeconds(-1);
            ShowSalesIncomeChart(showSalesType.month, dt);
        }
        #endregion

        #region interact
        private void SalesIncomeDayClicked(object sender, RoutedEventArgs e)
        {
            DateTime now = System.DateTime.Now;
            DateTime dt = new DateTime(now.Year, now.Month, 1);
            dt.AddSeconds(-1);
            ShowSalesIncomeChart(showSalesType.day, dt);
        }
        private void SalesIncomeMonthBtnClicked(object sender, RoutedEventArgs e)
        {
            DateTime now = System.DateTime.Now;
            DateTime dt = new DateTime(now.Year, 1, 1);
            dt.AddSeconds(-1);
            ShowSalesIncomeChart(showSalesType.month, dt);
        }
        private void SalesIncomeyYearBtnClicked(object sender, RoutedEventArgs e)
        {
            DateTime dt = new DateTime(System.DateTime.Now.Year - 10, 1, 1);
            dt.AddSeconds(-1);
            ShowSalesIncomeChart(showSalesType.year, dt);
        }

        #endregion


        #region setchartdata
  
        private void ShowSalesIncomeChart(showSalesType type, DateTime start)
        {
            SalesIncomedataSource.Collection.Clear();
            SalesProfitdataSource.Collection.Clear();

            if (type == showSalesType.day)
            {
                SupermarketDataSet.DaySaleIncomeRow[] drs = (SupermarketDataSet.DaySaleIncomeRow[])sds.DaySaleIncome.Select(string.Format("Date > \'{0}\'", start));
                foreach (SupermarketDataSet.DaySaleIncomeRow dr in drs)
                {
                    SalesIncomedataSource.AppendAsync(base.Dispatcher, new Point(dr.Date.Day, (double)dr.SaleIncome));
                    SalesProfitdataSource.AppendAsync(base.Dispatcher, new Point(dr.Date.Day, (double)dr.Profit));
                }
            }
            else if (type == showSalesType.month)
            {
                SupermarketDataSet.MonthSaleIncomeRow[] drs = (SupermarketDataSet.MonthSaleIncomeRow[])sds.MonthSaleIncome.Select(string.Format("Date > \'{0}\'", start));
                foreach (SupermarketDataSet.MonthSaleIncomeRow dr in drs)
                {
                    SalesIncomedataSource.AppendAsync(base.Dispatcher, new Point(Convert.ToDateTime(dr.Date).Month, (double)dr.SaleIncome));
                    SalesProfitdataSource.AppendAsync(base.Dispatcher, new Point(Convert.ToDateTime(dr.Date).Month, (double)dr.Profit));
                }
            }
            else if (type == showSalesType.year)
            {
                SupermarketDataSet.YearSaleIncomeRow[] drs = (SupermarketDataSet.YearSaleIncomeRow[])sds.YearSaleIncome.Select(string.Format("Date > {0}", start.Year));
                foreach (SupermarketDataSet.YearSaleIncomeRow dr in drs)
                {
                    SalesIncomedataSource.AppendAsync(base.Dispatcher, new Point(dr.Date, (double)dr.SaleIncome));
                    SalesProfitdataSource.AppendAsync(base.Dispatcher, new Point(dr.Date, (double)dr.Profit));
                }
            }
            plotter.Viewport.FitToView();
        }
        #endregion
    }
}
