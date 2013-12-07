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

namespace supermarket.sale
{
    /// <summary>
    /// Price.xaml 的交互逻辑
    /// </summary>
    public partial class Price : Window
    {
        #region Data
        SupermarketDataSet sds;
        #endregion

        #region constructor
        public Price(SupermarketDataSet set)
        {
            InitializeComponent();
            sds = set;
            loadData();
        }

        public Price()
        {
            InitializeComponent();
            sds = new SupermarketDataSet();
            loadData();
        }
        #endregion

        #region helpfounction
        private void loadData()
        {
            try
            {
                SupermarketDataSetTableAdapters.InventoryTableAdapter ita =
                    new SupermarketDataSetTableAdapters.InventoryTableAdapter();
                ita.Fill(sds.Inventory);

                SupermarketDataSetTableAdapters.GoodsTableAdapter gta =
                    new SupermarketDataSetTableAdapters.GoodsTableAdapter();
                gta.Fill(sds.Goods);
            }
            catch { MessageBox.Show("连接数据库失败！"); return; }
            SetPriceDataGrid.ItemsSource = new ObservableCollection<SupermarketDataSet.InventoryRow>(sds.Inventory.ToList());                     
        }

        private double calProfit(SupermarketDataSet.InventoryRow ir)
        {
            double purchasePrice = 0,                
                salePrice = 0;
            int discount = 100;

            try { purchasePrice = ir.PurchasePrice; }
            catch {}
            try { salePrice = ir.SalePrice; }
            catch { }
            try { discount = ir.Discount;
                    if(discount <= 0 || discount>100)
                        discount = 100;
            }catch{}

            return salePrice * discount / 100 - purchasePrice;
        }
        private double calMemberProfit(SupermarketDataSet.InventoryRow ir)
        {
            double purchasePrice = 0,
                salePrice = 0;
            int discount = 100;

            try { purchasePrice = ir.PurchasePrice; }
            catch { }
            try { salePrice = ir.MemberPrice; }
            catch { }
            try
            {
                discount = ir.MemberDiscount;
                if (discount <= 0 || discount > 100)
                    discount = 100;
            }
            catch { }

            return salePrice * discount / 100 - purchasePrice;
        }
        private void showProfitWrap()
        {
            SupermarketDataSet.InventoryRow ir
                               = SetPriceDataGrid.SelectedItem as SupermarketDataSet.InventoryRow;
            if (ir != null)
                showProfit(calProfit(ir), calMemberProfit(ir));
        }
        #endregion 

        #region 

        private void showProfit(double p, double mp)
        {
            if (p > 0)
                profit.Foreground = Brushes.Green;
            else
                profit.Foreground = Brushes.Red;
            if (mp > 0)
                memberProfit.Foreground = Brushes.Green;
            else
                memberProfit.Foreground = Brushes.Red;

            profit.Content = p.ToString();
            memberProfit.Content = mp.ToString();
        }
        private void InventoryInfoDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SetPriceDataGrid.SelectedItem != null)
            {
                SelectedInventoryEntry.DataContext = SetPriceDataGrid.SelectedItem;

                showProfitWrap();
            }
            else
            {
                SelectedInventoryEntry.DataContext = null;
            }
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {           
                SupermarketDataSetTableAdapters.InventoryTableAdapter ita = 
                    new SupermarketDataSetTableAdapters.InventoryTableAdapter();
                try
                {
                    ita.Update(sds.Inventory);
                    MessageBox.Show("保存修改成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败！" + ex.Message);
                }            
        }

        private void Cal_Button_Click(object sender, RoutedEventArgs e)
        {
            showProfitWrap();
        }
        #endregion 


        #region TextBox Info deal
        private void SalePriceTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;

            #region 屏蔽非法按键
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || e.Key == Key.Decimal)
            {
                if (txt.Text.Contains(".") && e.Key == Key.Decimal)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9) || e.Key == Key.OemPeriod) && e.KeyboardDevice.Modifiers != ModifierKeys.Shift)
            {
                if (txt.Text.Contains(".") && e.Key == Key.OemPeriod)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            #endregion


        }

        private void SalePriceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            #region 屏蔽中文输入和非法字符粘贴输入
            TextBox textBox = sender as TextBox;
            TextChange[] change = new TextChange[e.Changes.Count];
            e.Changes.CopyTo(change, 0);

            int offset = change[0].Offset;
            if (change[0].AddedLength > 0)
            {
                double num = 0;
                if (!Double.TryParse(textBox.Text, out num))
                {
                    textBox.Text = textBox.Text.Remove(offset, change[0].AddedLength);
                    textBox.Select(offset, 0);
                }
            }
            #endregion           
        }

        private void MemberPrice_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;

            #region 屏蔽非法按键
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || e.Key == Key.Decimal)
            {
                if (txt.Text.Contains(".") && e.Key == Key.Decimal)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9) || e.Key == Key.OemPeriod) && e.KeyboardDevice.Modifiers != ModifierKeys.Shift)
            {
                if (txt.Text.Contains(".") && e.Key == Key.OemPeriod)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            #endregion
        }

        private void MemberPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            #region 屏蔽中文输入和非法字符粘贴输入
            TextBox textBox = sender as TextBox;
            TextChange[] change = new TextChange[e.Changes.Count];
            e.Changes.CopyTo(change, 0);

            int offset = change[0].Offset;
            if (change[0].AddedLength > 0)
            {
                double num = 0;
                if (!Double.TryParse(textBox.Text, out num))
                {
                    textBox.Text = textBox.Text.Remove(offset, change[0].AddedLength);
                    textBox.Select(offset, 0);
                }
            }
            #endregion         
        }
        #endregion
    }
}
