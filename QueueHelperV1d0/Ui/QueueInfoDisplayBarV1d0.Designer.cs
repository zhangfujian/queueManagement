namespace QueueHelperV1d0.Ui
{
    partial class QueueInfoDisplayBarV1d0
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTelephone = new System.Windows.Forms.Label();
            this.labelCallNo = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelWaitMinute = new System.Windows.Forms.Label();
            this.labelNumberOfMeals = new System.Windows.Forms.Label();
            this.buttonCall = new QueueHelperV1d0.Ui.ButtonExV1d0();
            this.buttonCallConfirm = new QueueHelperV1d0.Ui.ButtonExV1d0();
            this.buttonCallPass = new QueueHelperV1d0.Ui.ButtonExV1d0();
            this.buttonMenu = new QueueHelperV1d0.Ui.ButtonExV1d0();
            this.labelDisplayIndex = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Controls.Add(this.labelTelephone, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelCallNo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonCall, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonCallConfirm, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonCallPass, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonMenu, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelDisplayIndex, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(848, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelTelephone
            // 
            this.labelTelephone.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelTelephone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTelephone.Location = new System.Drawing.Point(213, 3);
            this.labelTelephone.Margin = new System.Windows.Forms.Padding(2);
            this.labelTelephone.Name = "labelTelephone";
            this.labelTelephone.Size = new System.Drawing.Size(205, 94);
            this.labelTelephone.TabIndex = 1;
            this.labelTelephone.Text = "电话";
            this.labelTelephone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCallNo
            // 
            this.labelCallNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCallNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCallNo.ForeColor = System.Drawing.Color.Red;
            this.labelCallNo.Location = new System.Drawing.Point(87, 3);
            this.labelCallNo.Margin = new System.Windows.Forms.Padding(2);
            this.labelCallNo.Name = "labelCallNo";
            this.labelCallNo.Size = new System.Drawing.Size(121, 94);
            this.labelCallNo.TabIndex = 0;
            this.labelCallNo.Text = "序号";
            this.labelCallNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.labelWaitMinute, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelNumberOfMeals, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(424, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(118, 90);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // labelWaitMinute
            // 
            this.labelWaitMinute.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelWaitMinute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWaitMinute.Location = new System.Drawing.Point(3, 47);
            this.labelWaitMinute.Margin = new System.Windows.Forms.Padding(2);
            this.labelWaitMinute.Name = "labelWaitMinute";
            this.labelWaitMinute.Size = new System.Drawing.Size(112, 40);
            this.labelWaitMinute.TabIndex = 3;
            this.labelWaitMinute.Text = "等待时间";
            this.labelWaitMinute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNumberOfMeals
            // 
            this.labelNumberOfMeals.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelNumberOfMeals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNumberOfMeals.Location = new System.Drawing.Point(3, 3);
            this.labelNumberOfMeals.Margin = new System.Windows.Forms.Padding(2);
            this.labelNumberOfMeals.Name = "labelNumberOfMeals";
            this.labelNumberOfMeals.Size = new System.Drawing.Size(112, 39);
            this.labelNumberOfMeals.TabIndex = 2;
            this.labelNumberOfMeals.Text = "人数";
            this.labelNumberOfMeals.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonCall
            // 
            this.buttonCall.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.buttonCall.BackColorEx = System.Drawing.Color.DodgerBlue;
            this.buttonCall.BorderColor = System.Drawing.Color.Red;
            this.buttonCall.ClickColorEx = System.Drawing.Color.LightGray;
            this.buttonCall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCall.IsLockClickStatus = false;
            this.buttonCall.Location = new System.Drawing.Point(550, 4);
            this.buttonCall.Name = "buttonCall";
            this.buttonCall.Size = new System.Drawing.Size(77, 92);
            this.buttonCall.TabIndex = 3;
            this.buttonCall.TextColor = System.Drawing.Color.Black;
            this.buttonCall.TextEX = "呼叫";
            this.buttonCall.ButtonClick += new System.EventHandler(this.buttonCall_ButtonClick);
            // 
            // buttonCallConfirm
            // 
            this.buttonCallConfirm.BackColorEx = System.Drawing.Color.LimeGreen;
            this.buttonCallConfirm.BorderColor = System.Drawing.Color.Red;
            this.buttonCallConfirm.ClickColorEx = System.Drawing.Color.LightGray;
            this.buttonCallConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCallConfirm.IsLockClickStatus = false;
            this.buttonCallConfirm.Location = new System.Drawing.Point(634, 4);
            this.buttonCallConfirm.Name = "buttonCallConfirm";
            this.buttonCallConfirm.Size = new System.Drawing.Size(77, 92);
            this.buttonCallConfirm.TabIndex = 4;
            this.buttonCallConfirm.TextColor = System.Drawing.Color.Black;
            this.buttonCallConfirm.TextEX = "就餐";
            this.buttonCallConfirm.ButtonClick += new System.EventHandler(this.buttonCallConfirm_ButtonClick);
            // 
            // buttonCallPass
            // 
            this.buttonCallPass.BackColorEx = System.Drawing.Color.Orange;
            this.buttonCallPass.BorderColor = System.Drawing.Color.Red;
            this.buttonCallPass.ClickColorEx = System.Drawing.Color.LightGray;
            this.buttonCallPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCallPass.IsLockClickStatus = false;
            this.buttonCallPass.Location = new System.Drawing.Point(718, 4);
            this.buttonCallPass.Name = "buttonCallPass";
            this.buttonCallPass.Size = new System.Drawing.Size(77, 92);
            this.buttonCallPass.TabIndex = 5;
            this.buttonCallPass.TextColor = System.Drawing.Color.Black;
            this.buttonCallPass.TextEX = "过号";
            this.buttonCallPass.ButtonClick += new System.EventHandler(this.buttonCallPass_ButtonClick);
            // 
            // buttonMenu
            // 
            this.buttonMenu.BackColorEx = System.Drawing.Color.LightGray;
            this.buttonMenu.BorderColor = System.Drawing.Color.Red;
            this.buttonMenu.ClickColorEx = System.Drawing.Color.DodgerBlue;
            this.buttonMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMenu.IsLockClickStatus = false;
            this.buttonMenu.Location = new System.Drawing.Point(802, 4);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(42, 92);
            this.buttonMenu.TabIndex = 6;
            this.buttonMenu.TextColor = System.Drawing.Color.Black;
            this.buttonMenu.TextEX = "...";
            // 
            // labelDisplayIndex
            // 
            this.labelDisplayIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDisplayIndex.Location = new System.Drawing.Point(4, 1);
            this.labelDisplayIndex.Name = "labelDisplayIndex";
            this.labelDisplayIndex.Size = new System.Drawing.Size(77, 98);
            this.labelDisplayIndex.TabIndex = 7;
            this.labelDisplayIndex.Text = "label1";
            this.labelDisplayIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QueueInfoDisplayBarV1d0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "QueueInfoDisplayBarV1d0";
            this.Size = new System.Drawing.Size(848, 100);
            this.Load += new System.EventHandler(this.QueueInfoDisplayBarV1d0_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelTelephone;
        private System.Windows.Forms.Label labelCallNo;
        private System.Windows.Forms.Label labelWaitMinute;
        private System.Windows.Forms.Label labelNumberOfMeals;
        private ButtonExV1d0 buttonCall;
        private ButtonExV1d0 buttonCallConfirm;
        private ButtonExV1d0 buttonCallPass;
        private ButtonExV1d0 buttonMenu;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelDisplayIndex;
    }
}
