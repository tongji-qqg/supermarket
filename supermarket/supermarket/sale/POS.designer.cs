namespace Suppermarket_POS
{
    partial class POS
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxGoodsID = new System.Windows.Forms.TextBox();
            this.labelProductID = new System.Windows.Forms.Label();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.labelCashier = new System.Windows.Forms.Label();
            this.textBoxCashier = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelNum = new System.Windows.Forms.Label();
            this.textBoxNum = new System.Windows.Forms.TextBox();
            this.labelTotal = new System.Windows.Forms.Label();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.labelEmployeeID = new System.Windows.Forms.Label();
            this.textBoxEmployeeID = new System.Windows.Forms.TextBox();
            this.labelMemberID = new System.Windows.Forms.Label();
            this.textBoxMemberID = new System.Windows.Forms.TextBox();
            this.buttonGetMember = new System.Windows.Forms.Button();
            this.groupBoxMember = new System.Windows.Forms.GroupBox();
            this.textBoxMemberScore = new System.Windows.Forms.TextBox();
            this.labelMemberScore = new System.Windows.Forms.Label();
            this.textBoxMemberName = new System.Windows.Forms.TextBox();
            this.labelMemberName = new System.Windows.Forms.Label();
            this.groupBoxGoods = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelDiscountedTotal = new System.Windows.Forms.Label();
            this.textBoxDiscountedTotal = new System.Windows.Forms.TextBox();
            this.groupBoxTotal = new System.Windows.Forms.GroupBox();
            this.labelActualPay = new System.Windows.Forms.Label();
            this.labelChange = new System.Windows.Forms.Label();
            this.textBoxActualPay = new System.Windows.Forms.TextBox();
            this.textBoxChange = new System.Windows.Forms.TextBox();
            this.groupBoxPayChange = new System.Windows.Forms.GroupBox();
            this.buttonNewOrder = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonChangeNum = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxMember.SuspendLayout();
            this.groupBoxGoods.SuspendLayout();
            this.groupBoxTotal.SuspendLayout();
            this.groupBoxPayChange.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxGoodsID
            // 
            this.textBoxGoodsID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGoodsID.Font = new System.Drawing.Font("宋体", 15F);
            this.textBoxGoodsID.Location = new System.Drawing.Point(121, 37);
            this.textBoxGoodsID.Name = "textBoxGoodsID";
            this.textBoxGoodsID.Size = new System.Drawing.Size(110, 30);
            this.textBoxGoodsID.TabIndex = 0;
            // 
            // labelProductID
            // 
            this.labelProductID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelProductID.AutoSize = true;
            this.labelProductID.Font = new System.Drawing.Font("宋体", 15F);
            this.labelProductID.Location = new System.Drawing.Point(6, 40);
            this.labelProductID.Name = "labelProductID";
            this.labelProductID.Size = new System.Drawing.Size(109, 20);
            this.labelProductID.TabIndex = 1;
            this.labelProductID.Text = "商品编号：";
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddProduct.Location = new System.Drawing.Point(10, 196);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(113, 44);
            this.buttonAddProduct.TabIndex = 4;
            this.buttonAddProduct.Text = "确认添加";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConfirm.AutoSize = true;
            this.buttonConfirm.Location = new System.Drawing.Point(786, 443);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(100, 29);
            this.buttonConfirm.TabIndex = 2;
            this.buttonConfirm.Text = "确认交易";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // labelCashier
            // 
            this.labelCashier.Font = new System.Drawing.Font("宋体", 12F);
            this.labelCashier.Location = new System.Drawing.Point(3, 57);
            this.labelCashier.Name = "labelCashier";
            this.labelCashier.Size = new System.Drawing.Size(78, 21);
            this.labelCashier.TabIndex = 14;
            this.labelCashier.Text = "收银员：";
            // 
            // textBoxCashier
            // 
            this.textBoxCashier.Font = new System.Drawing.Font("宋体", 12F);
            this.textBoxCashier.Location = new System.Drawing.Point(71, 54);
            this.textBoxCashier.Name = "textBoxCashier";
            this.textBoxCashier.ReadOnly = true;
            this.textBoxCashier.Size = new System.Drawing.Size(75, 26);
            this.textBoxCashier.TabIndex = 13;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.Location = new System.Drawing.Point(-7, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 36;
            this.dataGridView1.Size = new System.Drawing.Size(905, 157);
            this.dataGridView1.TabIndex = 15;
            // 
            // labelNum
            // 
            this.labelNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNum.AutoSize = true;
            this.labelNum.Font = new System.Drawing.Font("宋体", 15F);
            this.labelNum.Location = new System.Drawing.Point(6, 83);
            this.labelNum.Name = "labelNum";
            this.labelNum.Size = new System.Drawing.Size(69, 20);
            this.labelNum.TabIndex = 2;
            this.labelNum.Text = "数量：";
            // 
            // textBoxNum
            // 
            this.textBoxNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxNum.Font = new System.Drawing.Font("宋体", 15F);
            this.textBoxNum.Location = new System.Drawing.Point(121, 81);
            this.textBoxNum.Name = "textBoxNum";
            this.textBoxNum.Size = new System.Drawing.Size(59, 30);
            this.textBoxNum.TabIndex = 3;
            this.textBoxNum.Text = "1";
            // 
            // labelTotal
            // 
            this.labelTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("宋体", 15F);
            this.labelTotal.Location = new System.Drawing.Point(10, 41);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(69, 20);
            this.labelTotal.TabIndex = 0;
            this.labelTotal.Text = "总价：";
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTotal.Font = new System.Drawing.Font("宋体", 15F);
            this.textBoxTotal.Location = new System.Drawing.Point(97, 37);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.ReadOnly = true;
            this.textBoxTotal.Size = new System.Drawing.Size(96, 30);
            this.textBoxTotal.TabIndex = 1;
            this.textBoxTotal.Text = "0.00";
            this.textBoxTotal.TextChanged += new System.EventHandler(this.textBoxTotal_TextChanged);
            // 
            // labelEmployeeID
            // 
            this.labelEmployeeID.Font = new System.Drawing.Font("宋体", 12F);
            this.labelEmployeeID.Location = new System.Drawing.Point(152, 57);
            this.labelEmployeeID.Name = "labelEmployeeID";
            this.labelEmployeeID.Size = new System.Drawing.Size(58, 21);
            this.labelEmployeeID.TabIndex = 12;
            this.labelEmployeeID.Text = "工号：";
            // 
            // textBoxEmployeeID
            // 
            this.textBoxEmployeeID.Font = new System.Drawing.Font("宋体", 12F);
            this.textBoxEmployeeID.Location = new System.Drawing.Point(197, 54);
            this.textBoxEmployeeID.Name = "textBoxEmployeeID";
            this.textBoxEmployeeID.ReadOnly = true;
            this.textBoxEmployeeID.Size = new System.Drawing.Size(97, 26);
            this.textBoxEmployeeID.TabIndex = 11;
            // 
            // labelMemberID
            // 
            this.labelMemberID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMemberID.AutoSize = true;
            this.labelMemberID.Font = new System.Drawing.Font("宋体", 15F);
            this.labelMemberID.Location = new System.Drawing.Point(4, 41);
            this.labelMemberID.Name = "labelMemberID";
            this.labelMemberID.Size = new System.Drawing.Size(109, 20);
            this.labelMemberID.TabIndex = 6;
            this.labelMemberID.Text = "会员卡号：";
            // 
            // textBoxMemberID
            // 
            this.textBoxMemberID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxMemberID.Font = new System.Drawing.Font("宋体", 15F);
            this.textBoxMemberID.Location = new System.Drawing.Point(117, 37);
            this.textBoxMemberID.Name = "textBoxMemberID";
            this.textBoxMemberID.Size = new System.Drawing.Size(137, 30);
            this.textBoxMemberID.TabIndex = 0;
            // 
            // buttonGetMember
            // 
            this.buttonGetMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGetMember.Location = new System.Drawing.Point(6, 196);
            this.buttonGetMember.Name = "buttonGetMember";
            this.buttonGetMember.Size = new System.Drawing.Size(107, 44);
            this.buttonGetMember.TabIndex = 1;
            this.buttonGetMember.Text = "确认";
            this.buttonGetMember.UseVisualStyleBackColor = true;
            this.buttonGetMember.Click += new System.EventHandler(this.buttonGetMember_Click);
            // 
            // groupBoxMember
            // 
            this.groupBoxMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxMember.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxMember.Controls.Add(this.textBoxMemberScore);
            this.groupBoxMember.Controls.Add(this.labelMemberScore);
            this.groupBoxMember.Controls.Add(this.textBoxMemberName);
            this.groupBoxMember.Controls.Add(this.buttonGetMember);
            this.groupBoxMember.Controls.Add(this.labelMemberID);
            this.groupBoxMember.Controls.Add(this.labelMemberName);
            this.groupBoxMember.Controls.Add(this.textBoxMemberID);
            this.groupBoxMember.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBoxMember.Location = new System.Drawing.Point(6, 259);
            this.groupBoxMember.Name = "groupBoxMember";
            this.groupBoxMember.Size = new System.Drawing.Size(272, 260);
            this.groupBoxMember.TabIndex = 1;
            this.groupBoxMember.TabStop = false;
            // 
            // textBoxMemberScore
            // 
            this.textBoxMemberScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxMemberScore.Font = new System.Drawing.Font("宋体", 15F);
            this.textBoxMemberScore.Location = new System.Drawing.Point(117, 124);
            this.textBoxMemberScore.Name = "textBoxMemberScore";
            this.textBoxMemberScore.ReadOnly = true;
            this.textBoxMemberScore.Size = new System.Drawing.Size(135, 30);
            this.textBoxMemberScore.TabIndex = 6;
            // 
            // labelMemberScore
            // 
            this.labelMemberScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMemberScore.AutoSize = true;
            this.labelMemberScore.Font = new System.Drawing.Font("宋体", 15F);
            this.labelMemberScore.Location = new System.Drawing.Point(6, 127);
            this.labelMemberScore.Name = "labelMemberScore";
            this.labelMemberScore.Size = new System.Drawing.Size(69, 20);
            this.labelMemberScore.TabIndex = 6;
            this.labelMemberScore.Text = "积分：";
            // 
            // textBoxMemberName
            // 
            this.textBoxMemberName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxMemberName.Font = new System.Drawing.Font("宋体", 15F);
            this.textBoxMemberName.Location = new System.Drawing.Point(117, 80);
            this.textBoxMemberName.Name = "textBoxMemberName";
            this.textBoxMemberName.ReadOnly = true;
            this.textBoxMemberName.Size = new System.Drawing.Size(135, 30);
            this.textBoxMemberName.TabIndex = 6;
            // 
            // labelMemberName
            // 
            this.labelMemberName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMemberName.AutoSize = true;
            this.labelMemberName.Font = new System.Drawing.Font("宋体", 15F);
            this.labelMemberName.Location = new System.Drawing.Point(4, 84);
            this.labelMemberName.Name = "labelMemberName";
            this.labelMemberName.Size = new System.Drawing.Size(109, 20);
            this.labelMemberName.TabIndex = 6;
            this.labelMemberName.Text = "会员姓名：";
            // 
            // groupBoxGoods
            // 
            this.groupBoxGoods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxGoods.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxGoods.Controls.Add(this.textBoxNum);
            this.groupBoxGoods.Controls.Add(this.labelNum);
            this.groupBoxGoods.Controls.Add(this.buttonAddProduct);
            this.groupBoxGoods.Controls.Add(this.labelProductID);
            this.groupBoxGoods.Controls.Add(this.textBoxGoodsID);
            this.groupBoxGoods.Location = new System.Drawing.Point(284, 259);
            this.groupBoxGoods.Name = "groupBoxGoods";
            this.groupBoxGoods.Size = new System.Drawing.Size(245, 260);
            this.groupBoxGoods.TabIndex = 0;
            this.groupBoxGoods.TabStop = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.Location = new System.Drawing.Point(786, 484);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 29);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "取消交易";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelDiscountedTotal
            // 
            this.labelDiscountedTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDiscountedTotal.AutoSize = true;
            this.labelDiscountedTotal.Font = new System.Drawing.Font("宋体", 15F);
            this.labelDiscountedTotal.Location = new System.Drawing.Point(10, 83);
            this.labelDiscountedTotal.Name = "labelDiscountedTotal";
            this.labelDiscountedTotal.Size = new System.Drawing.Size(89, 20);
            this.labelDiscountedTotal.TabIndex = 2;
            this.labelDiscountedTotal.Text = "会员价：";
            this.labelDiscountedTotal.Visible = false;
            // 
            // textBoxDiscountedTotal
            // 
            this.textBoxDiscountedTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDiscountedTotal.Font = new System.Drawing.Font("宋体", 15F);
            this.textBoxDiscountedTotal.Location = new System.Drawing.Point(97, 80);
            this.textBoxDiscountedTotal.Name = "textBoxDiscountedTotal";
            this.textBoxDiscountedTotal.ReadOnly = true;
            this.textBoxDiscountedTotal.Size = new System.Drawing.Size(96, 30);
            this.textBoxDiscountedTotal.TabIndex = 3;
            this.textBoxDiscountedTotal.Visible = false;
            // 
            // groupBoxTotal
            // 
            this.groupBoxTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTotal.Controls.Add(this.textBoxDiscountedTotal);
            this.groupBoxTotal.Controls.Add(this.labelDiscountedTotal);
            this.groupBoxTotal.Controls.Add(this.textBoxTotal);
            this.groupBoxTotal.Controls.Add(this.labelTotal);
            this.groupBoxTotal.Location = new System.Drawing.Point(535, 259);
            this.groupBoxTotal.Name = "groupBoxTotal";
            this.groupBoxTotal.Size = new System.Drawing.Size(212, 136);
            this.groupBoxTotal.TabIndex = 8;
            this.groupBoxTotal.TabStop = false;
            // 
            // labelActualPay
            // 
            this.labelActualPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelActualPay.AutoSize = true;
            this.labelActualPay.Font = new System.Drawing.Font("宋体", 15F);
            this.labelActualPay.Location = new System.Drawing.Point(10, 23);
            this.labelActualPay.Name = "labelActualPay";
            this.labelActualPay.Size = new System.Drawing.Size(69, 20);
            this.labelActualPay.TabIndex = 0;
            this.labelActualPay.Text = "实收：";
            // 
            // labelChange
            // 
            this.labelChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelChange.AutoSize = true;
            this.labelChange.Font = new System.Drawing.Font("宋体", 15F);
            this.labelChange.Location = new System.Drawing.Point(10, 69);
            this.labelChange.Name = "labelChange";
            this.labelChange.Size = new System.Drawing.Size(69, 20);
            this.labelChange.TabIndex = 2;
            this.labelChange.Text = "找零：";
            // 
            // textBoxActualPay
            // 
            this.textBoxActualPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxActualPay.Font = new System.Drawing.Font("宋体", 15F);
            this.textBoxActualPay.Location = new System.Drawing.Point(97, 20);
            this.textBoxActualPay.Name = "textBoxActualPay";
            this.textBoxActualPay.ReadOnly = true;
            this.textBoxActualPay.Size = new System.Drawing.Size(96, 30);
            this.textBoxActualPay.TabIndex = 1;
            // 
            // textBoxChange
            // 
            this.textBoxChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxChange.Font = new System.Drawing.Font("宋体", 15F);
            this.textBoxChange.Location = new System.Drawing.Point(97, 66);
            this.textBoxChange.Name = "textBoxChange";
            this.textBoxChange.ReadOnly = true;
            this.textBoxChange.Size = new System.Drawing.Size(96, 30);
            this.textBoxChange.TabIndex = 3;
            // 
            // groupBoxPayChange
            // 
            this.groupBoxPayChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPayChange.Controls.Add(this.textBoxChange);
            this.groupBoxPayChange.Controls.Add(this.textBoxActualPay);
            this.groupBoxPayChange.Controls.Add(this.labelChange);
            this.groupBoxPayChange.Controls.Add(this.labelActualPay);
            this.groupBoxPayChange.Location = new System.Drawing.Point(535, 403);
            this.groupBoxPayChange.Name = "groupBoxPayChange";
            this.groupBoxPayChange.Size = new System.Drawing.Size(212, 116);
            this.groupBoxPayChange.TabIndex = 7;
            this.groupBoxPayChange.TabStop = false;
            // 
            // buttonNewOrder
            // 
            this.buttonNewOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewOrder.AutoSize = true;
            this.buttonNewOrder.Location = new System.Drawing.Point(786, 403);
            this.buttonNewOrder.Name = "buttonNewOrder";
            this.buttonNewOrder.Size = new System.Drawing.Size(100, 29);
            this.buttonNewOrder.TabIndex = 5;
            this.buttonNewOrder.Text = "新建交易";
            this.buttonNewOrder.UseVisualStyleBackColor = true;
            this.buttonNewOrder.Click += new System.EventHandler(this.buttonNewOrder_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.Font = new System.Drawing.Font("宋体", 18F);
            this.labelTitle.Location = new System.Drawing.Point(267, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(336, 31);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "欢迎使用国国超市收银系统";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(753, 272);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(133, 31);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.TabStop = false;
            this.buttonDelete.Text = "删除选中条目";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonChangeNum
            // 
            this.buttonChangeNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChangeNum.Location = new System.Drawing.Point(753, 309);
            this.buttonChangeNum.Name = "buttonChangeNum";
            this.buttonChangeNum.Size = new System.Drawing.Size(133, 31);
            this.buttonChangeNum.TabIndex = 4;
            this.buttonChangeNum.TabStop = false;
            this.buttonChangeNum.Text = "修改选中条目数量";
            this.buttonChangeNum.UseVisualStyleBackColor = true;
            this.buttonChangeNum.Click += new System.EventHandler(this.buttonChangeNum_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrint.Location = new System.Drawing.Point(786, 366);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(100, 29);
            this.buttonPrint.TabIndex = 6;
            this.buttonPrint.TabStop = false;
            this.buttonPrint.Text = "打印小票";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Visible = false;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Location = new System.Drawing.Point(786, 12);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(89, 30);
            this.buttonExit.TabIndex = 16;
            this.buttonExit.Text = "退出";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // POS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 531);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.buttonChangeNum);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonNewOrder);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.groupBoxPayChange);
            this.Controls.Add(this.groupBoxTotal);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBoxGoods);
            this.Controls.Add(this.groupBoxMember);
            this.Controls.Add(this.textBoxEmployeeID);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxCashier);
            this.Controls.Add(this.labelCashier);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelEmployeeID);
            this.Name = "POS";
            this.Text = "Suppermarket_POS";
            this.Load += new System.EventHandler(this.POS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxMember.ResumeLayout(false);
            this.groupBoxMember.PerformLayout();
            this.groupBoxGoods.ResumeLayout(false);
            this.groupBoxGoods.PerformLayout();
            this.groupBoxTotal.ResumeLayout(false);
            this.groupBoxTotal.PerformLayout();
            this.groupBoxPayChange.ResumeLayout(false);
            this.groupBoxPayChange.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxGoodsID;
        private System.Windows.Forms.Label labelProductID;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Label labelCashier;
        private System.Windows.Forms.TextBox textBoxCashier;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelNum;
        private System.Windows.Forms.TextBox textBoxNum;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.Label labelEmployeeID;
        private System.Windows.Forms.TextBox textBoxEmployeeID;
        private System.Windows.Forms.Label labelMemberID;
        private System.Windows.Forms.TextBox textBoxMemberID;
        private System.Windows.Forms.Button buttonGetMember;
        private System.Windows.Forms.GroupBox groupBoxMember;
        private System.Windows.Forms.GroupBox groupBoxGoods;
        private System.Windows.Forms.TextBox textBoxMemberScore;
        private System.Windows.Forms.Label labelMemberScore;
        private System.Windows.Forms.TextBox textBoxMemberName;
        private System.Windows.Forms.Label labelMemberName;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelDiscountedTotal;
        private System.Windows.Forms.TextBox textBoxDiscountedTotal;
        private System.Windows.Forms.GroupBox groupBoxTotal;
        private System.Windows.Forms.Label labelActualPay;
        private System.Windows.Forms.Label labelChange;
        private System.Windows.Forms.TextBox textBoxActualPay;
        private System.Windows.Forms.TextBox textBoxChange;
        private System.Windows.Forms.GroupBox groupBoxPayChange;
        private System.Windows.Forms.Button buttonNewOrder;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonChangeNum;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonExit;
    }
}

