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

namespace supermarket.sale
{
    /// <summary>
    /// SaleAnalysis.xaml 的交互逻辑
    /// </summary>
    public partial class SaleAnalysis : Window
    {
         #region Data
        SupermarketDataSet sds;
        enum showSalesType { hour, day, month, year }
        private showSalesType currentShowType = showSalesType.hour;
        private List<LineGraph> sourceList = new List<LineGraph>();
        #endregion

        #region constructor
        public SaleAnalysis(SupermarketDataSet set)
        {
            InitializeComponent();
            sds = set;
            loadData();
        }
        public SaleAnalysis()
        {
            InitializeComponent();
            sds = new SupermarketDataSet();
            loadData();
        }
        #endregion

        #region helpFounction
        private void initDataset()
        {            
            SupermarketDataSetTableAdapters.CategoryDaySaleNumTableAdapter da = new SupermarketDataSetTableAdapters.CategoryDaySaleNumTableAdapter();
            SupermarketDataSetTableAdapters.CategoryHourSaleNumTableAdapter ha = new SupermarketDataSetTableAdapters.CategoryHourSaleNumTableAdapter();
            SupermarketDataSetTableAdapters.CategoryMonthSaleNumTableAdapter ma = new SupermarketDataSetTableAdapters.CategoryMonthSaleNumTableAdapter();
            SupermarketDataSetTableAdapters.GoodsTableAdapter gta =
                new SupermarketDataSetTableAdapters.GoodsTableAdapter();
            try
            {
                da.Fill(sds.CategoryDaySaleNum);
                ha.Fill(sds.CategoryHourSaleNum);
                ma.Fill(sds.CategoryMonthSaleNum);
                gta.Fill(sds.Goods);
            }
            catch { MessageBox.Show("数据库连接失败！"); }
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
        }
        #endregion


        #region interaction
        private void OptimizationHourClicked(object sender, RoutedEventArgs e)
        {
            string name = OptimizationComboBox.SelectedValue as string;
            if (name == null)
                return;
            ShowCategoryNumChart(showSalesType.hour, name);
        }
        private void OptimizationDayBtnClicked(object sender, RoutedEventArgs e)
        {
            string name = OptimizationComboBox.SelectedValue as string;
            if (name == null)
                return;
            ShowCategoryNumChart(showSalesType.day, name);
        }
        private void OptimizationBtnYearClicked(object sender, RoutedEventArgs e)
        {
            string name = OptimizationComboBox.SelectedValue as string;
            if (name == null)
                return;
            ShowCategoryNumChart(showSalesType.month, name);
        }

        #endregion 
        #region setdata
        private void ShowCategoryNumChart(showSalesType type, String name)
        {
            foreach (LineGraph l in sourceList)
            {
                OptimizationPlotter.Children.Remove(l);
            }
            sourceList.Clear();

            ObservableDataSource<Point> source = new ObservableDataSource<Point>();
            sourceList.Add(OptimizationPlotter.AddLineGraph(source, Colors.Green, 2, name));

            if (type == showSalesType.hour)
            {
                SupermarketDataSet.CategoryHourSaleNumRow[] drs =
                    (SupermarketDataSet.CategoryHourSaleNumRow[])
                    sds.CategoryHourSaleNum.Select(string.Format("GoodsName = '{0}'", name));
                
                foreach (SupermarketDataSet.CategoryHourSaleNumRow dr in drs)
                {
                    source.AppendAsync(base.Dispatcher, new Point(dr.Hour, dr.Number));
                }

                currentShowType = showSalesType.hour;
            }
            else if (type == showSalesType.day)
            {
                SupermarketDataSet.CategoryDaySaleNumRow[] drs =
                    (SupermarketDataSet.CategoryDaySaleNumRow[])
                    sds.CategoryDaySaleNum.Select(string.Format("GoodsName = '{0}'", name));
                foreach (SupermarketDataSet.CategoryDaySaleNumRow dr in drs)
                {
                    source.AppendAsync(base.Dispatcher, new Point(dr.Day, dr.Number));
                }
                currentShowType = showSalesType.day;
            }
            else if (type == showSalesType.month)
            {
                SupermarketDataSet.CategoryMonthSaleNumRow[] drs = 
                    (SupermarketDataSet.CategoryMonthSaleNumRow[])
                    sds.CategoryMonthSaleNum.Select(string.Format("GoodsName = '{0}'", name));
                foreach (SupermarketDataSet.CategoryMonthSaleNumRow dr in drs)
                {
                    source.AppendAsync(base.Dispatcher, new Point(dr.Month, dr.Number));
                }
                currentShowType = showSalesType.month;
            }
            OptimizationPlotter.Viewport.FitToView();
        }
        #endregion
    }
}
