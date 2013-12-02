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

namespace supermarket
{
    public enum PromotionEnum { 
        ChangePrice,
        Limit,
        Together,
        None
    }
    /// <summary>
    /// ChangePrice.xaml 的交互逻辑
    /// </summary>
    public partial class PromotionWindow : Window
    {
        #region Data
        MarketDataSet mds;
        #endregion
        public PromotionWindow(PromotionEnum founction, MarketDataSet set)
        {
            InitializeComponent();
            mds = set;
            setFounction(founction);
        }
        public void setFounction(PromotionEnum founction)
        {
            MarketDataSetTableAdapters.GoodsTableAdapter gta;
            switch (founction)
            {
                case PromotionEnum.ChangePrice:
                    Promotion_ChangePriceGrid.Visibility = Visibility.Visible;
                    gta = new MarketDataSetTableAdapters.GoodsTableAdapter();
                    gta.Fill(mds.Goods);
                    Promotion_ChangePriceDataGrid.ItemsSource = mds.Goods.DefaultView;
                    break;               
                case PromotionEnum.Limit:
                    Promotion_QuantityLimitGrid.Visibility = Visibility.Visible;
                    gta = new MarketDataSetTableAdapters.GoodsTableAdapter();
                    gta.Fill(mds.Goods);
                    Promotion_QuantityLimitDataGrid.ItemsSource = mds.Goods.DefaultView;
                    break;
                case PromotionEnum.Together:
                    Promotion_TogetherSaleGrid.Visibility = Visibility.Visible;
                    MarketDataSetTableAdapters.InventoryTableAdapter ita = new MarketDataSetTableAdapters.InventoryTableAdapter() ;
                    ita.Fill(mds.Inventory);
                    MarketDataSetTableAdapters.BundlingTableAdapter bta = new MarketDataSetTableAdapters.BundlingTableAdapter();
                    bta.Fill(mds.Bundling);

                    MarketDataSet.InventoryDataTable gdt = new MarketDataSet.InventoryDataTable();
                    ita.Fill(gdt);

                    TagetherSaleGoodsComboBox.ItemsSource = gdt.DefaultView;

                    Promotion_TogetherSaleDataGrid.ItemsSource = mds.Bundling.DefaultView;
                    MarketDataSet.BundlingRow br = mds.Bundling.NewBundlingRow();
                    EditBundlingGrid.DataContext = br;

                    break;
                case PromotionEnum.None:
                    Promotion_ChangePriceGrid.Visibility = Visibility.Collapsed;
                    Promotion_QuantityLimitGrid.Visibility = Visibility.Collapsed;
                    Promotion_TogetherSaleGrid.Visibility = Visibility.Collapsed;
                    break;   
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.setFounction(PromotionEnum.None);
            this.Hide();
        }
    }
}
