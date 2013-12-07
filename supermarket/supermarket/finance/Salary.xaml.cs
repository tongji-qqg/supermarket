using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
namespace supermarket.finance
{
    /// <summary>
    /// Salary.xaml 的交互逻辑
    /// </summary>
    public partial class Salary : Window
    {
         #region Data
        SupermarketDataSet sds;
        ObservableCollection<SalaryBean> source;
        #endregion

        #region constructor
        public Salary(SupermarketDataSet set)
        {
            InitializeComponent();
            sds = set;
            loadData();
        }
        public Salary()
        {
            InitializeComponent();
            sds = new SupermarketDataSet();
            loadData();
        }
        #endregion

        #region helpFounction
        private void loadData()
        {
            SupermarketDataSetTableAdapters.EmployeeTableAdapter eta =
                new SupermarketDataSetTableAdapters.EmployeeTableAdapter();
            try
            {
                eta.Fill(sds.Employee);
            }
            catch { MessageBox.Show(ErrorCode.ConnectFailed); }
            source = new ObservableCollection<SalaryBean>();

            foreach (SupermarketDataSet.EmployeeRow er in sds.Employee)
            {
                SalaryBean s = new SalaryBean();
                s.EmployeeID=  er.EmployeeID;
                s.EmployeeName = er.Name;
                source.Add(s);
            }

            SalaryDataGrid.ItemsSource = source;
        }
        #endregion


        #region interact
        private void SalaryDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SalaryDataGrid.SelectedItem != null)
            {
                SetSalaryInfoGrid.DataContext = SalaryDataGrid.SelectedItem;
            }
            else
            {
                SetSalaryInfoGrid.DataContext = null;
            }
        }
        private void Next_Button_Click(object sender, RoutedEventArgs e)
        {
            if (SalaryDataGrid.SelectedIndex < source.Count)
                SalaryDataGrid.SelectedIndex++;
        }
        private void Give_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                foreach (SalaryBean sb in source)
                {
                    SupermarketDataSet.PaymentRow pr = sds.Payment.NewPaymentRow();
                    pr.BasicPay = sb.BasicPay   <0 ? 0: sb.BasicPay;
                    pr.ExtraPay = sb.ExtraPay <0 ? 0: sb.ExtraPay;
                    pr.CutPay = sb.CutPay        <0?  0: sb.CutPay;                   
                    pr.PayDate = System.DateTime.Now;
                    pr.ActualPay = pr.BasicPay + pr.ExtraPay - pr.CutPay;

                    SupermarketDataSetTableAdapters.PaymentTableAdapter pta = 
                        new SupermarketDataSetTableAdapters.PaymentTableAdapter();
                    sds.Payment.AddPaymentRow(pr);
                    
                    pta.Update(sds.Payment);

                    SupermarketDataSet.EmployeePayRow epr = sds.EmployeePay.NewEmployeePayRow();
                    epr.PaymentID = pr.PaymentID;
                    epr.EmployeeID = sb.EmployeeID;
                    sds.EmployeePay.AddEmployeePayRow(epr);
                }
                SupermarketDataSetTableAdapters.EmployeePayTableAdapter epta =
                    new SupermarketDataSetTableAdapters.EmployeePayTableAdapter();
                epta.Update(sds.EmployeePay);

                MessageBox.Show(ErrorCode.InfoSaved);
                this.Close();
            }
            catch (Exception ex)
            {
                sds.EmployeePay.RejectChanges();
                sds.Payment.RejectChanges();
                System.Windows.Forms.MessageBox.Show(ErrorCode.InfoFormatError+ex.Message);
                return;
            }
        }
        #endregion
    }

    class SalaryBean
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public double BasicPay { get; set; }
        public double ExtraPay { get; set; }
        public double CutPay { get; set; }
    }
}
