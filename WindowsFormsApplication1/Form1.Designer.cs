﻿namespace WindowsFormsApplication1
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ucDiningTableInfoSetupV1d03 = new QueueHelperV1d0.Ui.UCDiningTableInfoSetupV1d0();
            this.SuspendLayout();
            // 
            // ucDiningTableInfoSetupV1d03
            // 
            this.ucDiningTableInfoSetupV1d03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucDiningTableInfoSetupV1d03.Location = new System.Drawing.Point(435, 12);
            this.ucDiningTableInfoSetupV1d03.Name = "ucDiningTableInfoSetupV1d03";
            this.ucDiningTableInfoSetupV1d03.Size = new System.Drawing.Size(596, 567);
            this.ucDiningTableInfoSetupV1d03.TabIndex = 0;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1052, 638);
            this.Controls.Add(this.ucDiningTableInfoSetupV1d03);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private QueueHelperV1d0.Ui.UCDiningTableInfoSetupV1d0 ucDiningTableInfoSetupV1d01;
        private QueueHelperV1d0.Ui.UCDiningTableInfoSetupV1d0 ucDiningTableInfoSetupV1d02;
        private QueueHelperV1d0.Ui.UCDiningTableInfoSetupV1d0 ucDiningTableInfoSetupV1d03;
    }
}

