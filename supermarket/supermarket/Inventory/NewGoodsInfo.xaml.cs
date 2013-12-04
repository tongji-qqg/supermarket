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
    /// NewGoodsInfoxaml.xaml 的交互逻辑
    /// </summary>
    public partial class NewGoodsInfo : Window
    {
        #region Data
        MarketDataSet mds;
        MarketDataSet.GoodsRow gr;
        #endregion


        public NewGoodsInfo()
        {
            InitializeComponent();
            mds = new MarketDataSet();
            loadData();
        }

        public NewGoodsInfo(MarketDataSet set)
        {
            InitializeComponent();
            mds = set;
            loadData();
        }

        private void loadData()
        {
            gr = mds.Goods.NewGoodsRow();
            newGoodsInfoGrid.DataContext = gr;
        }

        #region interact
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mds.Goods.AddGoodsRow(gr);

                MarketDataSetTableAdapters.GoodsTableAdapter gta =
                    new MarketDataSetTableAdapters.GoodsTableAdapter();
                gta.Update(mds.Goods);
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
            mds.Goods.RemoveGoodsRow(gr);
            this.Close();
        }
        #endregion

    }
}
