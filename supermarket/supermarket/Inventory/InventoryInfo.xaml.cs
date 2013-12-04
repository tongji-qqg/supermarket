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

namespace supermarket.Inventory
{
    /// <summary>
    /// InventoryInfo.xaml 的交互逻辑
    /// </summary>
    public partial class InventoryInfo : Window
    {
        #region Data
        MarketDataSet mds;
        #endregion

        #region constructor
        public InventoryInfo()
        {
            InitializeComponent();
            mds = new MarketDataSet();
            loadData();
        }

        public InventoryInfo(MarketDataSet set)
        {
            InitializeComponent();
            mds = set;
            loadData();
        }
        #endregion 

        #region helpFounction
        private void loadData()
        {
            supermarket.MarketDataSetTableAdapters.InventoryTableAdapter ita =
                new MarketDataSetTableAdapters.InventoryTableAdapter();

            ita.Fill(mds.Inventory);

            InventoryInfoDataGrid.ItemsSource = new ObservableCollection<MarketDataSet.InventoryRow>(mds.Inventory.ToList());
            //EmployeeInfoDataGrid.DataContext = new ObservableCollection<MarketDataSet.EmployeeRow>(mds.Employee);
            //EmployeeInfoDataGrid.ItemsSource = mds.Employee.DefaultView;                   
        }
        #endregion

        private void InventoryInfoDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (InventoryInfoDataGrid.SelectedItem != null)
            {
                SelectedInventoryEntry.DataContext = InventoryInfoDataGrid.SelectedItem;
            }
            else
            {
                SelectedInventoryEntry.DataContext = null;
            }
        }

        private void Out_Button_Click(object sender, RoutedEventArgs e)
        {
            if (InventoryInfoDataGrid.SelectedItem != null)
            {
                supermarket.MarketDataSet.InventoryRow ir =
                    InventoryInfoDataGrid.SelectedItem as supermarket.MarketDataSet.InventoryRow;
                if (ir != null)
                {
                    int outNumber =  (int)OutInventoryNumberSlider.Value;
                    if (ir.GoodsNum > outNumber)
                    {
                        ir.GoodsNum = ir.GoodsNum - outNumber;
                    }
                    else 
                    {
                        mds.Inventory.RemoveInventoryRow(ir);
                    }
                    supermarket.MarketDataSetTableAdapters.InventoryTableAdapter ita =
                        new MarketDataSetTableAdapters.InventoryTableAdapter();
                    try
                    {
                        ita.Update(mds.Inventory);
                        MessageBox.Show("出库成功");
                        InventoryInfoDataGrid.ItemsSource = new ObservableCollection<MarketDataSet.InventoryRow>(mds.Inventory.ToList());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("出库失败" + ex.Message);
                    }                    
                }
            }
        }
    }
}
