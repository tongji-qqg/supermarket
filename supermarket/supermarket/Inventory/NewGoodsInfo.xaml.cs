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
        SupermarketDataSet sds;
        SupermarketDataSet.GoodsRow gr;
        #endregion


        public NewGoodsInfo()
        {
            InitializeComponent();
            sds = new SupermarketDataSet();
            loadData();
        }

        public NewGoodsInfo(SupermarketDataSet set)
        {
            InitializeComponent();
            sds = set;
            loadData();
        }

        private void loadData()
        {
            gr = sds.Goods.NewGoodsRow();
            newGoodsInfoGrid.DataContext = gr;
        }

        #region interact
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            if (gr.IsGoodsNameNull() || gr.IsDurabilityPeriodNull())
            {
                MessageBox.Show("请输入完整信息!");
                return;
            }
            try
            {
                sds.Goods.AddGoodsRow(gr);

                SupermarketDataSetTableAdapters.GoodsTableAdapter gta =
                    new SupermarketDataSetTableAdapters.GoodsTableAdapter();
                gta.Update(sds.Goods);
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
            this.Close();
        }
        #endregion

    }
}
