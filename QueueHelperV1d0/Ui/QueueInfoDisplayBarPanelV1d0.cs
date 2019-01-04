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
    public partial class QueueInfoDisplayBarPanelV1d0 : UserControl
    {
        public QueueInfoDisplayBarPanelV1d0()
        {
            InitializeComponent();
            WaitInfoList = new List<WaitInfoV1d0>();
            PageNo = 0;
            PageSize = 5;
        }
        public event EventHandler<WaitInfoV1d0> CallEvent;
        public event EventHandler<WaitInfoV1d0> CallConfirmEvent;
        public event EventHandler<WaitInfoV1d0> CallPassEvent;
        private List<WaitInfoV1d0> WaitInfoList;
        private List<WaitInfoV1d0> UsingWaitInfoList;
        public int PageNo { get; set; }
        private int PageSize;
        public void LoadData(List<WaitInfoV1d0> waitInfoList)
        {
            //按叫号进行排序
            WaitInfoList = waitInfoList.OrderBy(x => x.CallNo).ToList();
            UpdatePageDisplay(0);
        }
        public void UpdatePageDisplay(int pageNo)
        {
            //得到对应页码的排队信息列表
            UsingWaitInfoList = WaitInfoList.Skip((pageNo) * PageSize).Take(PageSize).ToList();
            int currPageWaitInfoCount = UsingWaitInfoList.Count;
            for(int i=0;i< tableLayoutPanelLeft.Controls.Count;i++)
            {
                var displayBar = tableLayoutPanelLeft.Controls[i] as QueueInfoDisplayBarV1d0;
                if (i >= currPageWaitInfoCount) displayBar.Visible = false;
                else
                {
                    displayBar.DisplayIndex = i + 1 + pageNo * PageSize;
                    displayBar.Init(UsingWaitInfoList[i]);
                    displayBar.Visible = true;
                }
            }
        }

        private void queueInfoDisplayBarV1d04_Load(object sender, EventArgs e)
        {

        }

        private void buttonExPreviousPage_Load(object sender, EventArgs e)
        {

        }

        private void buttonExPreviousPage_ButtonClick(object sender, EventArgs e)
        {
            if (PageNo > 0) PageNo--;
            UpdatePageDisplay(PageNo);
        }

        private void buttonExNextPage_ButtonClick(object sender, EventArgs e)
        {
            int maxPageNo = WaitInfoList.Count / PageSize + 1;
            if (PageNo < (maxPageNo-1)) PageNo++;
            UpdatePageDisplay(PageNo);
        }

        private void SendCallConfirmEvent(object sender, WaitInfoV1d0 e)
        {
            if (CallConfirmEvent != null) CallConfirmEvent(sender, e);

        }
        private void SendCallPassEvent(object sender, WaitInfoV1d0 e)
        {
            if (CallPassEvent != null) CallPassEvent(sender, e);

        }
        private void SendCallEvent(object sender, WaitInfoV1d0 e)
        {
            if (CallEvent != null) CallEvent(sender, e);

        }
    }
}
