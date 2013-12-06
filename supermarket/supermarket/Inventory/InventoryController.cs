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
namespace supermarket.Inventory
{
    class InventoryController
    {
        #region constructor
        public InventoryController()
        {         
        }
        #endregion 

        #region data
        private Window GoodsInfoWin;
        private Window newGoodsInfoWin;
        private Window inventoryInfoWin;
        private Window inInventoryWin;
        #endregion

        #region function
        public void showGoodsInfo(SupermarketDataSet set)
        {
            if (!showIfWindowAlive(GoodsInfoWin))
            {
                GoodsInfoWin = new supermarket.Inventory.GoodsInfo(set);
                GoodsInfoWin.Show();
            }
        }
        public void showNewGoodsInfo(SupermarketDataSet set)
        {
            if (!showIfWindowAlive(newGoodsInfoWin))
            {
                newGoodsInfoWin = new supermarket.Inventory.NewGoodsInfo(set);
                newGoodsInfoWin.Show();
            }
        }
        public void showInventoryInfo(SupermarketDataSet set)
        {
            if (!showIfWindowAlive(inventoryInfoWin))
            {
                inventoryInfoWin = new supermarket.Inventory.InventoryInfo(set);
                inventoryInfoWin.Show();
            }
        }
        public void showInInventory(SupermarketDataSet set)
        {
            if (!showIfWindowAlive(inInventoryWin))
            {
                inInventoryWin = new supermarket.Inventory.InInventory(set);
                inInventoryWin.Show();
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
        #endregion
    }
}
