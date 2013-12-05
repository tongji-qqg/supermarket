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
        SupermarketDataSet sds;
        SupermarketDataSet.MemberRow mr;
        #endregion

        public NewMember(SupermarketDataSet set)
        {
            InitializeComponent();
            sds = set;
            loadData();
        }

        public NewMember()
        {
            InitializeComponent();
            sds = new SupermarketDataSet();
            loadData();
        }

        private void loadData()
        {
            mr = sds.Member.NewMemberRow();
            MemberSexComboBox.ItemsSource = new supermarket.HumanAffair.SexProvider().DefaultView;
            newMemberGrid.DataContext = mr;
        }

        #region interact
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sds.Member.AddMemberRow(mr);

                SupermarketDataSetTableAdapters.MemberTableAdapter mta =
                    new SupermarketDataSetTableAdapters.MemberTableAdapter();

                mta.Update(sds.Member);
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
