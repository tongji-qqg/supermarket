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

         #region Data
        SupermarketDataSet sds;
        SupermarketDataSet.InventoryRow ir;
        #endregion


        public InInventory()
        {
            InitializeComponent();
            sds = new SupermarketDataSet();
            loadData();
        }

        public InInventory(SupermarketDataSet set)
        {
            InitializeComponent();
            sds = set;
            loadData();
        }

        private void loadData()
        {
            ir = sds.Inventory.NewInventoryRow();
            InInventoryGrid.DataContext = ir;

            SupermarketDataSetTableAdapters.GoodsTableAdapter gta =
                new SupermarketDataSetTableAdapters.GoodsTableAdapter();
            gta.Fill(sds.Goods);
        }

        #region interact
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ir.IsGoodsIDNull() || ir.IsGoodsNumNull() || ir.IsProductionDateNull() || ir.IsPurchasePriceNull())
            {
                MessageBox.Show("请填写完整信息！");
                return;
            }
            try
            {
                sds.Inventory.AddInventoryRow(ir);

                SupermarketDataSetTableAdapters.InventoryTableAdapter ita =
                    new SupermarketDataSetTableAdapters.InventoryTableAdapter();

                ita.Update(sds.Inventory);
                MessageBox.Show("信息已保存");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败" + ex.Message);
                loadData();
            }
        }
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
