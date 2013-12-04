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
    /// MemberInfo.xaml 的交互逻辑
    /// </summary>
    public partial class MemberInfo : Window
    {
         #region Data
        MarketDataSet mds;
        #endregion

        #region constructor
        public MemberInfo(MarketDataSet set)
        {
            InitializeComponent();
            mds = set;
            loadData();
        }
        public MemberInfo()
        {
            InitializeComponent();
            mds = new MarketDataSet();
            loadData();
        }
        #endregion

        #region helpFounction
        private void loadData()
        {
            MarketDataSetTableAdapters.MemberTableAdapter mta =
                   new MarketDataSetTableAdapters.MemberTableAdapter();
            mta.Fill(mds.Member);            

            setItemSource();
        }

        private void setItemSource()
        {
            MemberInfoDataGrid.ItemsSource = new ObservableCollection<MarketDataSet.MemberRow>(mds.Member.ToList());
        }
        #endregion

        #region interact
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            if (modifyMemberInfoGrid.DataContext != null)
            {
                MarketDataSetTableAdapters.MemberTableAdapter mta =
                    new MarketDataSetTableAdapters.MemberTableAdapter();
                try
                {
                    mta.Update(mds.Member);
                    MessageBox.Show("保存修改成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败！" + ex.Message);
                }
            }
        }

        private void Dismiss_Button_Click(object sender, RoutedEventArgs e)
        {
            if (modifyMemberInfoGrid.DataContext != null)
            {
                MarketDataSetTableAdapters.MemberTableAdapter mta = new MarketDataSetTableAdapters.MemberTableAdapter();

                supermarket.MarketDataSet.MemberRow mr =
                    modifyMemberInfoGrid.DataContext as MarketDataSet.MemberRow;

                mds.Member.RemoveMemberRow(mr);
                try
                {
                    mta.Update(mds.Member);
                    setItemSource();
                    MessageBox.Show("删除信息成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除失败！" + ex.Message);
                }
            }
        }
        private void MemberInfoDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MemberInfoDataGrid.SelectedItem != null)
            {
                modifyMemberInfoGrid.DataContext = MemberInfoDataGrid.SelectedItem;
            }
            else
            {
                modifyMemberInfoGrid.DataContext = null;
            }
        }
        #endregion
    }
}
