using CCWin.SkinClass;
using CCWin.SkinControl;
using QueueHelperV1d0.Entity;
using QueueHelperV1d0.Singleton;
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
            GetWaitInfoList();
            DisplayBarPanel.LoadData(CurrWaitInfoList);


        }
        private List<WaitInfoV1d0> CurrWaitInfoList { get; set; }
        private void GetWaitInfoList()
        {
            CurrWaitInfoList.Add(new WaitInfoV1d0(1, 2, "13488888888", DateTime.Now));
            CurrWaitInfoList.Add(new WaitInfoV1d0(2, 3, "13588888888", DateTime.Now));
            CurrWaitInfoList.Add(new WaitInfoV1d0(3, 4, "13688888888", DateTime.Now));
            CurrWaitInfoList.Add(new WaitInfoV1d0(4, 5, "13788888888", DateTime.Now));
            CurrWaitInfoList.Add(new WaitInfoV1d0(5, 6, "13888888888", DateTime.Now));
            CurrWaitInfoList.Add(new WaitInfoV1d0(6, 7, "13988888888", DateTime.Now));
            CurrWaitInfoList.Add(new WaitInfoV1d0(7, 8, "15188888888", DateTime.Now));
            CurrWaitInfoList.Add(new WaitInfoV1d0(8, 9, "15288888888", DateTime.Now));
            CurrWaitInfoList.Add(new WaitInfoV1d0(9, 8, "15388888888", DateTime.Now));
            CurrWaitInfoList.Add(new WaitInfoV1d0(10, 7, "15488888888", DateTime.Now));
            CurrWaitInfoList.Add(new WaitInfoV1d0(11, 6, "15588888888", DateTime.Now));
            CurrWaitInfoList.Add(new WaitInfoV1d0(12, 5, "15688888888", DateTime.Now));
            CurrWaitInfoList.Add(new WaitInfoV1d0(13, 4, "15788888888", DateTime.Now));
            CurrWaitInfoList.Add(new WaitInfoV1d0(14, 3, "15888888888", DateTime.Now));
            CurrWaitInfoList.Add(new WaitInfoV1d0(15, 2, "15988888888", DateTime.Now));
            CurrWaitInfoList.Add(new WaitInfoV1d0(16, 3, "17188888888", DateTime.Now));
            CurrWaitInfoList.Add(new WaitInfoV1d0(17, 4, "17288888888", DateTime.Now));
            CurrWaitInfoList.Add(new WaitInfoV1d0(18, 5, "17388888888", DateTime.Now));
            CurrWaitInfoList.Add(new WaitInfoV1d0(19, 6, "17488888888", DateTime.Now));
            CurrWaitInfoList.Add(new WaitInfoV1d0(20, 7, "17588888888", DateTime.Now));
            CurrWaitInfoList.Add(new WaitInfoV1d0(21, 8, "17688888888", DateTime.Now));

            UpdatePanelFilterButton();
        }
        private void UpdatePanelFilterButton()
        {
            foreach(var item in tableLayoutPanelFilterButton.Controls)
            {
                var buttonEx = item as ButtonExV1d0;
                string[] minMax = buttonEx.Tag.ToString().Split('-');
                int seatMin = Convert.ToInt32(minMax[0]);
                int seatMax = Convert.ToInt32(minMax[1]);
                List<WaitInfoV1d0> DisplayWaitInfo = CurrWaitInfoList.FindAll(x => x.NumberOfMeals >= seatMin && x.NumberOfMeals <= seatMax);
                if(seatMax!=99) buttonEx.TextEX = buttonEx.Tag.ToString() + "("+ DisplayWaitInfo.Count+ ")";
                else buttonEx.TextEX = "所有" + "(" + DisplayWaitInfo.Count + ")";

            }
        }
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
        private void FilterButton_Click(object sender, EventArgs e)
        {
            if(sender is ButtonExV1d0)
            {
                var buttonEx = sender as ButtonExV1d0;
                string[] minMax = buttonEx.Tag.ToString().Split('-');
                int seatMin = Convert.ToInt32(minMax[0]);
                int seatMax= Convert.ToInt32(minMax[1]);
                List<WaitInfoV1d0> DisplayWaitInfo = CurrWaitInfoList.FindAll(x => x.NumberOfMeals >= seatMin && x.NumberOfMeals <= seatMax);
                DisplayBarPanel.LoadData(DisplayWaitInfo);
            }
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
            

            DisplayBarPanel.LoadData(CurrWaitInfoList);
            DisplayBarPanel.UpdatePageDisplay(1);


            //FillPanelControls(panelDisplayBar.Controls, 200);
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
            //FillPanelControls(panelDisplayBar.Controls, 9);
            //DisplayBarPanel.UpdatePageDisplay(2);
            var xyz=DiningTableInfoSetSingletonV1d0.Instance.GetDiningTableType(4);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //FillPanelControls(panelDisplayBar.Controls, 5);
            DisplayBarPanel.UpdatePageDisplay(3);

        }

        private void DisplayBarPanel_CallEvent(object sender, WaitInfoV1d0 e)
        {
            MessageBox.Show("Call");
        }

        private void DisplayBarPanel_CallConfirmEvent(object sender, WaitInfoV1d0 e)
        {
            MessageBox.Show("CallConfirm");

        }

        private void DisplayBarPanel_CallPassEvent(object sender, WaitInfoV1d0 e)
        {
            MessageBox.Show("CallPass");

        }

        private void buttonExV1d02_Load(object sender, EventArgs e)
        {

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
