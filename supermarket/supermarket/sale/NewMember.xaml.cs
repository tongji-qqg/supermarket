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

namespace supermarket.sale
{
    /// <summary>
    /// NewMember.xaml 的交互逻辑
    /// </summary>
    public partial class NewMember : Window
    {
              #region Data
        MarketDataSet mds;
        MarketDataSet.MemberRow mr;
        #endregion

        public NewMember(MarketDataSet set)
        {
            InitializeComponent();
            mds = set;
            loadData();
        }

        public NewMember()
        {
            InitializeComponent();
            mds = new MarketDataSet();
            loadData();
        }

        private void loadData()
        {
            mr = mds.Member.NewMemberRow();
            newMemberGrid.DataContext = mr;
        }

        #region interact
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mds.Member.AddMemberRow(mr);

                MarketDataSetTableAdapters.MemberTableAdapter mta =
                    new MarketDataSetTableAdapters.MemberTableAdapter();

                mta.Update(mds.Member);
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
            mds.Member.RemoveMemberRow(mr);
            this.Close();
        }
        #endregion
    }
}
