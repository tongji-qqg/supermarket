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

namespace supermarket
{
    class MainController
    {
        public MainController()
        {
            financeController = new finance.FinanceController();
            humanAffairController = new HumanAffair.HumanAffairController();
            inventoryController = new Inventory.InventoryController();
            saleController = new sale.SaleController();
        }

        #region data
        supermarket.finance.FinanceController financeController;
        supermarket.HumanAffair.HumanAffairController humanAffairController;
        supermarket.Inventory.InventoryController inventoryController;
        supermarket.sale.SaleController saleController;
        #endregion 

        #region interaction
        public void HumanAffair_Button_Click(object sender, SupermarketDataSet set)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string content = button.Content as string;
                switch (content)
                {
                    case "招聘新员工":                        
                        humanAffairController.showNewEmployee(set);
                        break;
                    case "员工信息":
                    case "职位调动":
                    case "解聘员工":                       
                        humanAffairController.showEmployeeInfo(set);
                        break;
                    case "系统使用权限":                        
                        humanAffairController.showUsePermission(set);
                        break;
                    default:
                        break;
                }
            }
        }

         public void Sale_Button_Click(object sender, SupermarketDataSet set)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string content = button.Content as string;
                Window window = null;
                switch (content)
                {
                    case "商品档案":
                        break;
                    case "收银":
                        saleController.showPos(1, "guoguo");
                        break;
                    case "新加会员":                        
                        saleController.showNewMember(set);
                        break;
                    case "会员管理":                        
                        saleController.showMemberInfo(set);
                        break;
                    case "价格调整":                        
                        saleController.showPrice(set);
                        break;
                    case "销售分析":                       
                        saleController.showAnalysis(set);
                        break;
                    default:
                        break;
                }

                if (window != null)
                    window.Show();
            }
        }


        public void Finance_Button_Click(object sender, SupermarketDataSet set)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string content = button.Content as string;                
                switch (content)
                {
                    case "日常支出":
                        financeController.showNewExpense(set);
                        break;
                    case "日常支出查看":                        
                        financeController.showExpenseInfo(set);
                        break;
                    case "工资发放管理":
                        financeController.showSalary(set);
                        break;
                    case "利润报表":
                        financeController.showProfit(set);
                        break;                   
                    default:
                        break;
                }
            }
        }


        public void Inventory_Button_Click(object sender, SupermarketDataSet set)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string content = button.Content as string;
                Window window = null;
                switch (content)
                {
                    case "添加新商品":                        
                        inventoryController.showNewGoodsInfo(set);
                        break;
                    case "管理商品档案":                        
                        inventoryController.showGoodsInfo(set);
                        break;
                    case "商品入库":                        
                        inventoryController.showInInventory(set);
                        break;
                    case "商品出库":
                    case "库存查询":                        
                    case "过期管理":                        
                        inventoryController.showInventoryInfo(set);
                        break;
                    default:
                        break;
                }

                if (window != null)
                    window.Show();
            }
        }
        #endregion
    }
}
