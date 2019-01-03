using CCWin.SkinClass;
using CCWin.SkinControl;
using QueueHelperV1d0.Entity;
using QueueHelperV1d0.Ui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZhangLogSysV1d0;

namespace WindowsFormsApplication2
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            CurrWaitInfoList = new List<WaitInfoV1d0>();
        }
        private List<WaitInfoV1d0> CurrWaitInfoList { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_LeftToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            (sender as SkinButton).ControlState = ControlState.Pressed;

        }

        private void skinButton6_Click(object sender, EventArgs e)
        {

        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
        }

        private void skinButton3_Click(object sender, EventArgs e)
        {

        }
        public void FillWaitInfoListIntoTabelLayoutPanel(TableLayoutPanel layoutPanel,List<WaitInfoV1d0> waitInfoList)
        {
            int waitInfoCount = waitInfoList.Count;
            layoutPanel.GetType().GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(layoutPanel,true, null);
            layoutPanel.SuspendLayout();
            if(layoutPanel.RowCount!= waitInfoCount)
            {
                layoutPanel.Height = waitInfoCount * 100;
                layoutPanel.RowCount = waitInfoCount;
                layoutPanel.RowStyles.Clear();
                for(int i=0; i < waitInfoCount; i++)
                {
                    if (i < (waitInfoCount - 1)) layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100));
                    else layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                }
            }
            layoutPanel.Controls.Clear();
            for (int i = 0; i < waitInfoCount; i++)
            {
                QueueInfoDisplayBarV1d0 displayBar = new QueueInfoDisplayBarV1d0(waitInfoList[i]);
                displayBar.Dock = DockStyle.Fill;
                layoutPanel.Controls.Add(displayBar, 1, i);                
            }
            layoutPanel.ResumeLayout();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FillPanelControls(panelDisplayBar.Controls, 200);
            //List<WaitInfoV1d0> waitInfoList = new List<WaitInfoV1d0>();
            //waitInfoList.Add(new WaitInfoV1d0());
            //waitInfoList.Add(new WaitInfoV1d0());
            //waitInfoList.Add(new WaitInfoV1d0());
            //panelDisplayBar.Controls.Clear();
            //for (int i=0;i< waitInfoList.Count;i++)
            //{
            //    panelDisplayBar.Controls.RemoveAt()

            //    var displayBar = new QueueInfoDisplayBarV1d0(waitInfoList[i]);
            //    displayBar.Location = new Point(5, 5 + 105 * i);
            //    displayBar.tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            //    displayBar.tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            //    //displayBar.sh
            //    panelDisplayBar.Controls.Add(displayBar);
            //}

            //FillWaitInfoListIntoTabelLayoutPanel(tableLayoutPanelQueueInfoDisplayBar, waitInfoList);
        }
        public  void FillPanelControls(Control.ControlCollection panelControls,int barCount)
        {
            try
            {
                int controlsCount = panelControls.Count;
                if (barCount > controlsCount)
                {
                    for (int i = controlsCount; i < barCount; i++)
                    {
                        var displayBar = new QueueInfoDisplayBarV1d0();
                        displayBar.Location = new Point(5, 5 + 102 * i);
                        displayBar.tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                        displayBar.tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                        displayBar.DisplayIndex = i;
                        panelControls.Add(displayBar);
                    }
                }
                else if (barCount < controlsCount)
                {
                    List<Control> deleteList = new List<Control>();
                    foreach (Control item in panelControls)
                    {
                        if ((item is QueueInfoDisplayBarV1d0) && ((item as QueueInfoDisplayBarV1d0).DisplayIndex >= barCount))
                        {
                            deleteList.Add(item);
                        }
                    }
                    foreach( var item in deleteList)
                    {
                        panelControls.Remove(item);
                    }
                }
            }
            catch(Exception ex)
            {
                SimpleLoger.Instance.Error(ex);
            }

          
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FillPanelControls(panelDisplayBar.Controls, 9);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FillPanelControls(panelDisplayBar.Controls, 5);

        }
        ///// <summary>
        ///// 防止界面闪烁
        ///// </summary>
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        var parms = base.CreateParams;
        //        parms.Style &= ~0x02000000; // Turn off WS_CLIPCHILDREN 
        //        return parms;
        //    }
        //}
    }
}
