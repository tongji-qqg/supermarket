using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Suppermarket_POS
{
    public partial class POS : Form
    {
        private DataTable viewTable;
        private int rowNum;
        private long salesID;
        private long employeeID;
        private string employeeName;
        bool isMember;
        private SqlConnector goodsConnector;
        private SqlConnector salesOrderConnector;
        private SqlConnector salesInfoConnector;
        private SqlConnector inventoryConnector;
        private SqlConnector memberConnector;
        private DataRow newOrder;

        public POS(long id, string name)
        {
            InitializeComponent();
            //初始化条目数、是否会员、收银员信息
            rowNum = 0;
            isMember = false;
            employeeID = id;
            employeeName = name;
            //界面显示收银员姓名、工号显示
            textBoxEmployeeID.Text = employeeID.ToString();
            textBoxCashier.Text = employeeName;
            //画viewTable"
            viewTable = new DataTable();
            viewTable.Columns.Add("序号",typeof(int));
            viewTable.Columns.Add("商品编号", typeof(string));
            viewTable.Columns.Add("商品名称", typeof(string));
            viewTable.Columns.Add("单价", typeof(string));
            viewTable.Columns.Add("数量", typeof(int));
            viewTable.Columns.Add("小计", typeof(string));
            //数据库表的连接
            goodsConnector = new SqlConnector("select * from Goods");
            salesOrderConnector = new SqlConnector("select * from SalesOrder");
            salesInfoConnector = new SqlConnector("select * from SalesInfo");
            inventoryConnector = new SqlConnector("select * from Inventory");
            memberConnector = new SqlConnector("select * from Member");
            
            //生成新的订单、获取订单号
            newOrder = salesOrderConnector.DataTable.NewRow();
            salesOrderConnector.DataTable.Rows.Add(newOrder);
            salesOrderConnector.Update();
            newOrder["employeeID"] = employeeID;
            salesID = (long)newOrder["SalesID"];
            //dataGridView的初始设定
            dataGridView1.DataSource = viewTable;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns[0].FillWeight = 8;
            dataGridView1.Columns[1].FillWeight = 12;
            dataGridView1.Columns[2].FillWeight = 50;
            dataGridView1.Columns[3].FillWeight = 10;
            dataGridView1.Columns[4].FillWeight = 10;
            dataGridView1.Columns[5].FillWeight = 10;    
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;
            //编辑时事件
            //dataGridView1.CellParsing += new DataGridViewCellParsingEventHandler(dataGridView1_CellParsing);
            //添加单元格编辑结束触发事件
            dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
            //添加窗口关闭触发事件
            this.FormClosing += new FormClosingEventHandler(POS_FormClosing);
            this.KeyPreview = true;
            /*this.KeyPress += new KeyPressEventHandler(POS_KeyPress);
            textBoxGoodsID.KeyPress += new KeyPressEventHandler(textBoxGoodsID_KeyPress);
            textBoxMemberID.KeyPress += new KeyPressEventHandler(textBoxMemberID_KeyPress);
            textBoxNum.KeyPress += new KeyPressEventHandler(textBoxNum_KeyPress);*/
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }
        
        //添加商品
        private void AddProduct()
        {
            long storageID = -1;
            int num = 1;
            try
            {
                storageID = Convert.ToInt64(textBoxGoodsID.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("商品编号输入错误！", ex.Message);
                return;
            }
            try
            {
                num = Convert.ToInt32(textBoxNum.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("商品数量输入错误！", ex.Message);
                return;
            }

            DataRow goodsInventory = inventoryConnector.DataTable.Rows.Find(storageID);

            if (goodsInventory == null)
            {
                MessageBox.Show("无此商品！请确认商品编号是否正确！");
                return;
            }

            int goodsID = Convert.ToInt32(goodsInventory["GoodsID"]);
            DataRow goods = goodsConnector.DataTable.Rows.Find(goodsID);
            DataRow[] existedRow = viewTable.Select("商品编号 = " + storageID.ToString());

            if (num <= 0)
            {
                MessageBox.Show("商品数量必须为正！");
                return;
            }


            int numAfterAdd = num;

            //若已经有该商品,合并项目
            if (existedRow.GetLength(0) != 0)
            {
                numAfterAdd = (int)existedRow[0]["数量"] + num;
                
                //显示出来的商品数量、小计增加
                existedRow[0]["数量"] = (int)existedRow[0]["数量"] + num;
                existedRow[0]["小计"] = (Convert.ToDouble(
                    existedRow[0]["单价"]) * (int)existedRow[0]["数量"]).ToString("f2");


                //详单数量、小计修改
                DataRow[] existedInfo = salesInfoConnector.DataTable.Select(
                    "SalesID = " + salesID.ToString() + " and StorageID = " + storageID.ToString());
                existedInfo[0]["GoodsNum"] = existedRow[0]["数量"];
                existedInfo[0]["SubPrice"] = existedRow[0]["小计"];
            }
            else
            {
                //折扣率
                Double discount = 100;
                double salePrice = Convert.ToDouble(goodsInventory["SalePrice"]);
                double memberPrice = 0;
                int memberDiscount = 100;

                //要显示的一行商品信息
                DataRow dr = viewTable.NewRow();
                dr["序号"] = ++rowNum;
                dr["商品编号"] = storageID;
                dr["商品名称"] = goods["GoodsName"];

                if (goodsInventory["MemberPrice"].ToString() != "")
                {
                    memberPrice = Convert.ToDouble(goodsInventory["MemberPrice"]);
                }
                if (goodsInventory["MemberDiscount"].ToString() != "")
                {
                    memberDiscount = Convert.ToInt32(goodsInventory["MemberDiscount"]);
                    if (memberDiscount == 0)
                        memberDiscount = 100;
                }
                
                if (goodsInventory["Discount"].ToString() != "")
                {
                    discount = Convert.ToDouble(goodsInventory["Discount"]);
                    if (discount == 0)
                        discount = 100;                    
                }

                if (isMember && (memberPrice!=0 || memberDiscount !=100))
                {
                    MessageBox.Show("会员优惠商品: " + goods["GoodsName"].ToString()
                            + "\n\n原价：" + memberPrice.ToString("f2")
                            + "\n折扣率：" + memberDiscount.ToString() + "%"
                            + "\n折后价：" + (memberPrice * memberDiscount / 100).ToString("f2"));
                    dr["单价"] = (memberPrice * memberDiscount / 100).ToString("f2");
                }
                else if (discount != 100)
                {
                    MessageBox.Show("打折商品: " + goods["GoodsName"].ToString()
                            + "\n\n原价：" + salePrice.ToString("f2")
                            + "\n折扣率：" + discount.ToString() + "%"
                            + "\n折后价：" + (salePrice * discount / 100).ToString("f2"));
                    dr["单价"] = (salePrice * discount / 100).ToString("f2");
                }
                else
                {
                    dr["单价"] = salePrice.ToString("f2");
                }
                dr["数量"] = num;
                dr["小计"] = (Convert.ToDouble(dr["单价"]) * num).ToString("f2");
                //在数据表里为这份订单添加一行salesInfo
                DataRow newInfo = salesInfoConnector.DataTable.NewRow();
                newInfo["SalesID"] = salesID;
                newInfo["StorageID"] = storageID;
                newInfo["GoodsNum"] = num;
                newInfo["SubPrice"] = dr["小计"];
                salesInfoConnector.DataTable.Rows.Add(newInfo);

                //添加该行商品并修改总价、数量
                viewTable.Rows.Add(dr);
            }
            //更新datatable里商品库存数量
            goodsInventory["GoodsNum"] = (int)goodsInventory["GoodsNum"] - num;            
            //更新总价，还原默认数量
            UpdateTotal();
            textBoxNum.Text = "1";
        }
        //确认会员
        private void GetMember()
        {
            if (isMember)
                return;
            long id = -1;
            try
            {
                id = Convert.ToInt64(textBoxMemberID.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("会员卡号输入错误！", ex.Message);
                return;
            }

            DataRow member = memberConnector.DataTable.Rows.Find(id);
            if (member == null)
                MessageBox.Show("无此会员！请确认会员卡号是否正确！");
            else
            {
                newOrder["MemberID"] = id;
                isMember = true;
                textBoxMemberID.Text = id.ToString();
                textBoxMemberName.Text = member["MemberName"].ToString();
                textBoxMemberScore.Text = member["MemberPoint"].ToString();
                textBoxMemberID.ReadOnly = true;
                buttonGetMember.Visible = false;

                //保留到“分”
                string discountedTotal = (Convert.ToDouble(textBoxTotal.Text) * 0.9).ToString("f2");
                //小数点后2位的形式显示
                //textBoxDiscountedTotal.Text = Convert.ToDouble(discountedTotal).ToString("f2");
            }
        }        
        //取消交易
        private void CancelOrder()
        {
            if (MessageBox.Show(
                        "确定要取消交易吗？", "警告",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                newOrder["Remark"] = "订单取消";
                salesOrderConnector.Update();
                salesInfoConnector.DataTable.RejectChanges();
                OrderFinishedForm();
            }
        }       
        //确认交易
        private void ConfirmOrder()
        {
            //是否有商品
            if (rowNum == 0)
            {
                MessageBox.Show("没有商品售出！");
                return;
            }
            //是否会员，确认最终总价，积分累积
            string total = textBoxTotal.Text;
            /*
            if (isMember)
            {
                total = textBoxDiscountedTotal.Text;
            }
            else
            {
                total = textBoxTotal.Text;
            }
             * */
            //新订单属性赋值
            newOrder["TotalPrice"] = total;
            newOrder["SalesDate"] = DateTime.Now;
            //应收、实收、找零
            MessageBox.Show("应收：" + total);
            double actualPay;
            try
            {
                actualPay =
                    Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox(
                    "实收：", "实收", "", -1, -1));
            }
            catch (Exception ex)
            {
                MessageBox.Show("订单确认取消");
                return;
            }
            if (actualPay < Convert.ToDouble(total))
            {
                MessageBox.Show("实收金额小于总价！请检查是否输入错误！");
                return;
            }
            textBoxActualPay.Text = actualPay.ToString("f2");
            //找零保留到“角”
            string change = (actualPay - Convert.ToDouble(total)).ToString("f1");
            change = Convert.ToDouble(change).ToString("f2");
            MessageBox.Show("找零: " + change, "找零");
            textBoxChange.Text = change;
            newOrder["ActualPay"] = actualPay;
            newOrder["Change"] = change;
            /*商品库存数量减少
            for (int i = 0; i < rowNum; i++)
            {

                DataRow inventory = inventoryConnector.DataTable.Rows.Find(
                    Convert.ToInt64(dataGridView1.Rows[i].Cells["商品编号"].Value));
                DataRow goods = goodsConnector.DataTable.Rows.Find(inventory["GoodsID"]);
                inventory["GoodsNum"] = Convert.ToInt32(inventory["GoodsNum"])
                    - Convert.ToInt32(dataGridView1.Rows[i].Cells["数量"].Value);
                goods["GoodsNum"] = Convert.ToInt32(goods["GoodsNum"])
                    - Convert.ToInt32(dataGridView1.Rows[i].Cells["数量"].Value);
            }*/
            if (isMember)
            {
                DataRow member = memberConnector.DataTable.Rows.Find(Convert.ToInt64(textBoxMemberID.Text));
                member["MemberPoint"] = (int)member["MemberPoint"] + Convert.ToDouble(total);
                textBoxMemberScore.Text = member["MemberPoint"].ToString();
            }
            //更新数据库
            salesOrderConnector.Update();
            salesInfoConnector.Update();
            inventoryConnector.Update();
            goodsConnector.Update();
            memberConnector.Update();
            MessageBox.Show("交易成功！");
            //结束、只能查看交易
            OrderFinishedForm();
        }        
        //新建交易
        private void NewOrder()
        {
            if (salesID != -1)
            {
                MessageBox.Show(
                        "当前交易未完成，请先确认或取消交易", "警告",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            newOrder = salesOrderConnector.DataTable.NewRow();
            salesOrderConnector.DataTable.Rows.Add(newOrder);
            salesOrderConnector.Update();
            newOrder["employeeID"] = employeeID;
            salesID = (long)newOrder["SalesID"];
            ResetForm();
        }      
        //删除条目
        private void DeleteItem()
        {
            int count = dataGridView1.SelectedRows.Count;
            if (count == 0)
                MessageBox.Show("请先单击最左边的空白列选择要删除的行，可以按住<Ctrl>同时选中多行");
            else
            {
                if (MessageBox.Show(
                    "确实要删除选定的行吗？", "警告",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //MessageBox.Show();
                    //salesInfoConnector.DataTable.Rows.Find(
                    //  ((DataRow)(dataGridView1.SelectedRows[0].DataBoundItem))["商品编号"].ToString());
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Selected == true)
                        {                        
                            string name = dataGridView1.Rows[i].Cells["商品名称"].Value.ToString();
                            
                            string storageID = dataGridView1.Rows[i].Cells["商品编号"].Value.ToString();
                            DataRow[] infoRows = salesInfoConnector.DataTable.Select(
                                "SalesID = " + salesID.ToString() + " and StorageID = " +
                                dataGridView1.Rows[i].Cells["商品编号"].Value.ToString());

                            DataRow goodsInventory = inventoryConnector.DataTable.Rows.Find(storageID);
                            DataRow goods = goodsConnector.DataTable.Rows.Find(goodsInventory["GoodsID"]);
                            //更新商品库存
                            int num = (int)dataGridView1.Rows[i].Cells["数量"].Value;
                            goodsInventory["GoodsNum"] = (int)goodsInventory["GoodsNum"] + num;
                   

                            viewTable.Rows.RemoveAt(i);
                            rowNum--;
                            UpdateTotal();
                            for (int j = i; j < rowNum; j++)
                                viewTable.Rows[j]["序号"] = j + 1;
                            salesInfoConnector.DataTable.Rows.Remove(infoRows[0]);

                            //删除之后之后的行往上移，继续从当前行开始遍历
                            i--;
                        }
                    }
                    MessageBox.Show(count + "个条目已被移除！");

                }
            }
        }        
        //编辑选中条目数量
        private void ChangeNum()
        {
            try
            {
                dataGridView1.Columns[4].ReadOnly = false;
                dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[4];
                dataGridView1.BeginEdit(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("没有选中条目！", ex.Message);
            }
        }
        //打印小票
        private void Print()
        {
            string str;
            string memberID = null;
            string total = textBoxTotal.Text;
            if (isMember)
            {
                memberID = textBoxMemberID.Text.ToString();
                //total = textBoxDiscountedTotal.Text;
            }
            str = "                     国国超市                   "
                + "\n================================================"
                + "\n收银员：" + employeeName
                + "\n工号：" + employeeID
                + "\n日期：" + DateTime.Now.ToString()
                + "\n会员：" + memberID
                + "\n================================================"
                + "\n编号      商品名称                数量  小计    \n";
            for (int i = 0; i < rowNum; i++)
            {
                string id = dataGridView1.Rows[i].Cells["商品编号"].Value.ToString().PadRight(8, ' ');
                string name = dataGridView1.Rows[i].Cells["商品名称"].Value.ToString().PadRight(22, ' ');
                string num = dataGridView1.Rows[i].Cells["数量"].Value.ToString().PadRight(4, ' ');
                string subtotal = dataGridView1.Rows[i].Cells["小计"].Value.ToString().PadRight(8, ' ');
                str = str + id + "  " + name + "  " + num + "  " + subtotal + "\n";
            }
            str = str + "\n================================================"
                      + "\n总计：" + total
                      + "\n收您：" + textBoxActualPay.Text
                      + "\n找零：" + textBoxChange.Text
                      + "\n================================================"
                      + "\n################请妥善保管购物小票##############";
            Form Receipt = new Form();
            Label lable = new Label();
            lable.AutoSize = true;
            lable.Dock = DockStyle.Fill;
            lable.Text = str;
            Receipt.Controls.Add(lable);
            Receipt.Show();

        }        
        //总价更新时，更新会员价
        private void textBoxTotal_TextChanged(object sender, EventArgs e)
        {
            if (isMember)
            {
                //优惠保留到“分”
                string discountedTotal = (Convert.ToDouble(textBoxTotal.Text) * 0.9).ToString("f2");
                //小数点后2位的形式显示
                //textBoxDiscountedTotal.Text = Convert.ToDouble(discountedTotal).ToString("f2");
            }
        }     
        //在dataGridView修改数量后，更新到dataTable
        private void dataGridView1_CellEndEdit(object sender, EventArgs e)
        {
            int numAfterEdit = 0;
            try
            {
                numAfterEdit = Convert.ToInt32((dataGridView1.CurrentRow.Cells["数量"].EditedFormattedValue.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show("数量输入有误！", ex.Message);
                dataGridView1.CancelEdit();
                dataGridView1.Columns[4].ReadOnly = true;
                return;
            }
            if (numAfterEdit <= 0)
            {
                MessageBox.Show("数量只能改为正整数！");
                dataGridView1.CancelEdit();
                dataGridView1.Columns[4].ReadOnly = true;
                return;
            }
            //是否为捆绑商品（。。看名称有没有乘号。。。）
            string name = dataGridView1.CurrentRow.Cells["商品名称"].Value.ToString();
                       

            long storageID = Convert.ToInt64(
                (dataGridView1.CurrentRow.Cells["商品编号"].Value.ToString()));
            
            //非绑定商品，修改数量
            string subtotal = (Convert.ToDouble(
                (dataGridView1.CurrentRow.Cells["单价"].Value.ToString())) * numAfterEdit).ToString("f2");
            DataRow[] changeInfo = salesInfoConnector.DataTable.Select(
                "SalesID = " + salesID.ToString() + " and StorageID = " + storageID.ToString());
            /*DataRow goodsInventory = inventoryConnector.DataTable.Rows.Find(storageID);
            DataRow goods = goodsConnector.DataTable.Rows.Find(goodsInventory["GoodsID"]);
            int numBeforeEdit = Convert.ToInt32(changeInfo[0]["GoodsNum"]);*/

            //修改详单的数量、小计           
            changeInfo[0]["GoodsNum"] = numAfterEdit;
            changeInfo[0]["SubTotalPrice"] = subtotal;
            dataGridView1.CurrentRow.Cells["小计"].Value = subtotal;
            /*修改库存、商品数量
            goodsInventory["GoodsNum"] = (int)goodsInventory["GoodsNum"] + numBeforeEdit - numAfterEdit;
            goods["GoodsNum"] = (int)goods["GoodsNum"] + numBeforeEdit - numAfterEdit;*/
            //修改总价
            UpdateTotal();   
            dataGridView1.Columns[4].ReadOnly = true;
            MessageBox.Show("商品数量已更改！");         
        }
        

         
        //总价更新
        private void UpdateTotal()
        {
            double total = 0;
            if(rowNum != 0)
                for (int i = 0; i < rowNum; i++)
                {
                    total = total + Convert.ToDouble(
                        dataGridView1.Rows[i].Cells["小计"].Value.ToString());
                }
            textBoxTotal.Text = total.ToString("f2");
        }
        //重置界面
        private void ResetForm()
        {
            viewTable.Clear();
            rowNum = 0;
            isMember = false;
            textBoxGoodsID.Text = "";
            textBoxNum.Text = "1";
            textBoxTotal.Text = "0.00";
            textBoxMemberID.Text = "";
            textBoxMemberName.Text = "";
            textBoxMemberScore.Text = "";
            //textBoxDiscountedTotal.Text = "";            
            textBoxActualPay.Text = "";
            textBoxChange.Text = "";
            textBoxGoodsID.ReadOnly = false;
            textBoxNum.ReadOnly = false;
            textBoxMemberID.ReadOnly = false;
            buttonPrint.Visible = false;
            buttonCancel.Enabled = true;
            buttonConfirm.Enabled = true;
            buttonAddProduct.Enabled = true;
            buttonDelete.Enabled = true;
            buttonGetMember.Enabled = true;
            buttonChangeNum.Enabled = true;
            buttonGetMember.Visible = true;
            
        }
        //订单完成后界面改变
        private void OrderFinishedForm()
        {
            salesID = -1;
            textBoxMemberID.ReadOnly = true;
            textBoxGoodsID.ReadOnly = true;
            textBoxNum.ReadOnly = true;
            buttonPrint.Visible = true;
            buttonConfirm.Enabled = false;
            buttonCancel.Enabled = false;
            buttonAddProduct.Enabled = false;
            buttonGetMember.Enabled = false;
            buttonDelete.Enabled = false;
            buttonChangeNum.Enabled = false;
        }
        //关闭窗口事件
        private void POS_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (salesID == -1)
            {
                if (MessageBox.Show(
                        "确定要退出吗？", "警告",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                MessageBox.Show(
                        "当前交易未完成，请确认或取消交易后退出", "警告",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }

        }
        //添加商品 button
        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            AddProduct();
        }
        //确认会员 button
        private void buttonGetMember_Click(object sender, EventArgs e)
        {
            GetMember();
        }
        //取消交易 button
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            CancelOrder();
        }
        //确认交易 button
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            ConfirmOrder();
        }
        //新建交易 button
        private void buttonNewOrder_Click(object sender, EventArgs e)
        {
            NewOrder();
        }
        //编辑选中条目数量 button
        private void buttonChangeNum_Click(object sender, EventArgs e)
        {
            ChangeNum();
        }
        //删除条目 button
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }
        //打印小票 button
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            Print();
        }
        //关闭窗口 button
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
