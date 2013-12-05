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
    /// GoodsInfo.xaml 的交互逻辑
    /// </summary>
    public partial class GoodsInfo : Window
    {
        #region Data
        SupermarketDataSet sds;
        #endregion

        #region constructor
        public GoodsInfo()
        {
            InitializeComponent();
            sds = new SupermarketDataSet();
            loadData();
        }

        public GoodsInfo(SupermarketDataSet set)
        {
            InitializeComponent();
            sds = set;
            loadData();
        }
        #endregion

        #region helpFounction
        private void loadData()
        {
            SupermarketDataSetTableAdapters.GoodsTableAdapter gta =
                new SupermarketDataSetTableAdapters.GoodsTableAdapter();

            gta.Fill(sds.Goods);

            GoodsInfoDataGrid.ItemsSource = new ObservableCollection<SupermarketDataSet.GoodsRow>(sds.Goods.ToList());                        
        }
        #endregion
        private void GoodsInfoDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GoodsInfoDataGrid.SelectedItem != null)
            {
                modifyGoodsInfoGrid.DataContext = GoodsInfoDataGrid.SelectedItem;
            }
            else
            {
                modifyGoodsInfoGrid.DataContext = null;
            }
        }

        private void save()
        {
            supermarket.MarketDataSetTableAdapters.GoodsTableAdapter gta =
                           new MarketDataSetTableAdapters.GoodsTableAdapter();
            
            gta.Update(mds.Goods);            
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                save();
                MessageBox.Show("保存成功");
                GoodsInfoDataGrid.ItemsSource = new ObservableCollection<MarketDataSet.GoodsRow>(mds.Goods.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败" + ex.Message);
            }
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (modifyGoodsInfoGrid.DataContext != null)
            {
                supermarket.MarketDataSetTableAdapters.GoodsTableAdapter gta =
                                   new MarketDataSetTableAdapters.GoodsTableAdapter();

                supermarket.MarketDataSet.GoodsRow gr =
                    modifyGoodsInfoGrid.DataContext as MarketDataSet.GoodsRow;

                mds.Goods.RemoveGoodsRow(gr);
                
                try
                {
                    gta.Update(mds.Goods);
                    GoodsInfoDataGrid.ItemsSource = new ObservableCollection<MarketDataSet.GoodsRow>(mds.Goods.ToList());
                    MessageBox.Show("删除信息成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除失败！" + ex.Message);
                }
            }
        }
    }
}
