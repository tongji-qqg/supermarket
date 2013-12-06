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
        SupermarketDataSet sds;
        #endregion

        #region constructor
        public InventoryInfo()
        {
            InitializeComponent();
            sds = new SupermarketDataSet();
            loadData();
        }

        public InventoryInfo(SupermarketDataSet set)
        {
            InitializeComponent();
            sds = set;
            loadData();
        }
        #endregion 

        #region helpFounction
        private void loadData()
        {
            SupermarketDataSetTableAdapters.InventoryTableAdapter ita =
                new SupermarketDataSetTableAdapters.InventoryTableAdapter();

            ita.Fill(sds.Inventory);

            InventoryInfoDataGrid.ItemsSource = new ObservableCollection<SupermarketDataSet.InventoryRow>(sds.Inventory.ToList());                     
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
                SupermarketDataSet.InventoryRow ir =
                    InventoryInfoDataGrid.SelectedItem as SupermarketDataSet.InventoryRow;
                if (ir != null)
                {
                    int outNumber =  (int)OutInventoryNumberSlider.Value;
                    if (ir.GoodsNum > outNumber)
                    {
                        ir.GoodsNum = ir.GoodsNum - outNumber;
                    }
                    else 
                    {
                        ir.Delete();
                    }
                    SupermarketDataSetTableAdapters.InventoryTableAdapter ita =
                        new SupermarketDataSetTableAdapters.InventoryTableAdapter();
                    try
                    {
                        ita.Update(sds.Inventory);
                        MessageBox.Show("出库成功");
                        InventoryInfoDataGrid.ItemsSource = new ObservableCollection<SupermarketDataSet.InventoryRow>(sds.Inventory.ToList());
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
