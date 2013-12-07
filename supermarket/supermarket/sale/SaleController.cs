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
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace supermarket.sale
{
    class SaleController
    {
        #region constructor
        public SaleController()
        {         
        }
        #endregion 

        #region data
        private Window memberInfoWin;
        private Window newMemberWin;
        private Window PriceWin;
        private Window saleAnalysisWin;
        Suppermarket_POS.POS pos;
        #endregion

        #region 
        public void closeAllChildWin()
        {
            closeIfWindowAlive(memberInfoWin);
            closeIfWindowAlive(newMemberWin);
            closeIfWindowAlive(PriceWin);
            closeIfWindowAlive(saleAnalysisWin);
            if(pos != null && !pos.IsDisposed)
            {
                pos.Close();
            }
        }
        public void showPos(long id, string name)
        {
            if (pos != null && !pos.IsDisposed)
            {
                pos.Activate();
            }
            else
            {
                pos = new Suppermarket_POS.POS(id, name);
                pos.Show();
            }
        }
        public void showMemberInfo(SupermarketDataSet set)
        {
            if (!showIfWindowAlive(memberInfoWin))
            {
                memberInfoWin = new supermarket.sale.MemberInfo(set);
                memberInfoWin.Show();
            }
        }
        public void showNewMember(SupermarketDataSet set)
        {
            if (!showIfWindowAlive(newMemberWin))
            {
                newMemberWin = new supermarket.sale.NewMember(set);
                newMemberWin.Show();
            }
        }
        public void showPrice(SupermarketDataSet set)
        {
            if (!showIfWindowAlive(PriceWin))
            {
                PriceWin = new supermarket.sale.Price(set);
                PriceWin.Show();
            }
        }
        public void showAnalysis(SupermarketDataSet set)
        {
            if (!showIfWindowAlive(saleAnalysisWin))
            {
                saleAnalysisWin = new supermarket.sale.SaleAnalysis(set);
                saleAnalysisWin.Show();
            }
        }
        private bool showIfWindowAlive(Window w)
        {
            if (w != null && w.IsVisible)
            {
                w.Activate();
                return true;
            }
            else
                return false;
        }

        private void closeIfWindowAlive(Window w)
        {
            if (w != null && w.IsVisible)
                w.Close();
        }
        #endregion
    }
}
