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

            try
            {
                gta.Fill(sds.Goods);
            }
            catch { MessageBox.Show(ErrorCode.ConnectFailed); return; }

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
            SupermarketDataSetTableAdapters.GoodsTableAdapter gta =
                           new SupermarketDataSetTableAdapters.GoodsTableAdapter();
            
                gta.Update(sds.Goods);                      
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                save();
                MessageBox.Show(ErrorCode.InfoSaved);
                GoodsInfoDataGrid.ItemsSource = new ObservableCollection<SupermarketDataSet.GoodsRow>(sds.Goods.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorCode.SaveFailed + ex.Message);
            }
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (modifyGoodsInfoGrid.DataContext != null)
            {
                SupermarketDataSetTableAdapters.GoodsTableAdapter gta =
                                   new SupermarketDataSetTableAdapters.GoodsTableAdapter();
                               
                try
                {
                    SupermarketDataSet.GoodsRow gr =
                    modifyGoodsInfoGrid.DataContext as SupermarketDataSet.GoodsRow;

                    gr.Delete();

                    gta.Update(sds.Goods);
                    GoodsInfoDataGrid.ItemsSource = new ObservableCollection<SupermarketDataSet.GoodsRow>(sds.Goods.ToList());
                    MessageBox.Show(ErrorCode.DeleteSucceed);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ErrorCode.DeleteFailed + ex.Message);
                }
            }
        }
    }
}
