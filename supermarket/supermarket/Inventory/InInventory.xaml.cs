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

namespace supermarket.Inventory
{
    /// <summary>
    /// InInventory.xaml 的交互逻辑
    /// </summary>
    public partial class InInventory : Window
    {
        public InInventory()
        {
            InitializeComponent();
        }

         #region Data
        MarketDataSet mds;
        MarketDataSet.InventoryRow ir;
        #endregion


        public InInventory()
        {
            InitializeComponent();
            mds = new MarketDataSet();
            loadData();
        }

        public InInventory(MarketDataSet set)
        {
            InitializeComponent();
            mds = set;
            loadData();
        }

        private void loadData()
        {
            ir = mds.Inventory.NewInventoryRow();
            InInventoryGrid.DataContext = ir;
        }

        #region interact
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mds.Inventory.AddInventoryRow(ir);

                MarketDataSetTableAdapters.InventoryTableAdapter ita =
                    new MarketDataSetTableAdapters.InventoryTableAdapter();

                ita.Update(mds.Inventory);
                MessageBox.Show("信息已保存");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败" + ex.Message);
                loadData();
            }
        }
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            mds.Inventory.RemoveInventoryRow(ir);
            this.Close();
        }
        #endregion
    }
}
