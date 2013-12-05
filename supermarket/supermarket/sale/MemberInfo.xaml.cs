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
        SupermarketDataSet sds;
        #endregion

        #region constructor
        public MemberInfo(SupermarketDataSet set)
        {
            InitializeComponent();
            sds = set;
            loadData();
        }
        public MemberInfo()
        {
            InitializeComponent();
            sds = new SupermarketDataSet();
            loadData();
        }
        #endregion

        #region helpFounction
        private void loadData()
        {
            SupermarketDataSetTableAdapters.MemberTableAdapter mta =
                   new SupermarketDataSetTableAdapters.MemberTableAdapter();
            mta.Fill(sds.Member);

            MemberSexComboBox.ItemsSource = new supermarket.HumanAffair.SexProvider().DefaultView;
            setItemSource();
        }

        private void setItemSource()
        {
            MemberInfoDataGrid.ItemsSource = new ObservableCollection<SupermarketDataSet.MemberRow>(sds.Member.ToList());
        }
        #endregion

        #region interact
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            if (modifyMemberInfoGrid.DataContext != null)
            {
                SupermarketDataSetTableAdapters.MemberTableAdapter mta =
                    new SupermarketDataSetTableAdapters.MemberTableAdapter();
                try
                {
                    mta.Update(sds.Member);
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
                SupermarketDataSetTableAdapters.MemberTableAdapter mta = new SupermarketDataSetTableAdapters.MemberTableAdapter();                
                
                try
                {
                    SupermarketDataSet.MemberRow mr =
                    modifyMemberInfoGrid.DataContext as SupermarketDataSet.MemberRow;
                    mr.Delete();

                    mta.Update(sds.Member);
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
