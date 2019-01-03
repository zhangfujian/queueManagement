using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QueueHelperV1d0.Entity;

namespace QueueHelperV1d0.Ui
{
    public partial class QueueInfoDisplayBarV1d0 : UserControl
    {
        public QueueInfoDisplayBarV1d0()
        {
            InitializeComponent();
            WaitInfo = new WaitInfoV1d0();
            DisplayIndex = 0;
        }
        public QueueInfoDisplayBarV1d0(WaitInfoV1d0 waitInfo)
        {
            InitializeComponent();
            WaitInfo = waitInfo;
            DisplayIndex = 0;
        }
        public WaitInfoV1d0 WaitInfo { get; set; }
        public int DisplayIndex { get; set; }
        private void QueueInfoDisplayBarV1d0_Load(object sender, EventArgs e)
        {
            Init();
        }
        public event EventHandler<WaitInfoV1d0> CallEvent;
        public event EventHandler<WaitInfoV1d0> CallConfirmEvent;
        public event EventHandler<WaitInfoV1d0> CallPassEvent;
        private void Init()
        {
            if (WaitInfo != null)
            {
                labelCallNo.Text = WaitInfo.CallNo;
                labelTelephone.Text = WaitInfo.CustomerTelephone;
                labelNumberOfMeals.Text = WaitInfo.NumberOfMeals.ToString();
                TimeSpan tSpan = DateTime.Now.Subtract(WaitInfo.TakeTime);
                labelWaitMinute.Text = tSpan.Minutes.ToString();
            }
        }


        private void buttonCall_ButtonClick(object sender, EventArgs e)
        {
            if (CallEvent != null) CallEvent(this, WaitInfo);

        }

        private void buttonCallConfirm_ButtonClick(object sender, EventArgs e)
        {
            if (CallConfirmEvent != null) CallConfirmEvent(this, WaitInfo);

        }

        private void buttonCallPass_ButtonClick(object sender, EventArgs e)
        {
            if (CallPassEvent != null) CallPassEvent(this, WaitInfo);
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