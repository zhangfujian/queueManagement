using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace QueueHelperV1d0.Ui
{
    public partial class ButtonExV1d0 : UserControl
    {
        /// <summary>
        /// 点击后，保持点击状态一段时间
        /// </summary>
        public ButtonExV1d0()
        {
            InitializeComponent();
        }
        private bool IsClicked { get; set; }
        /// <summary>
        /// 是否锁定单击状态
        /// </summary>
        [Description("是否锁定单击状态")]
        public bool IsLockClickStatus { get; set; }
        /// <summary>
        /// 控件的文字显示
        /// </summary>
        private string textEX = "测试测试";
        [Description("显示的文字")]
        public string TextEX
        {
            get { return textEX; }
            set
            {
                textEX = value;
                labelText.Text = textEX;
            }
        }
        /// <summary>
          /// 文字的颜色
          /// </summary>
          private Color textColor = Color.Black;
          [Description("文字的颜色")]
        public Color TextColor
        {
            get { return textColor; }
            set
            {
                textColor = value;
                labelText.ForeColor = textColor;
            }
        }
        private Color borderColor = Color.Red;
        [Description("点击后边框的颜色")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        private Color backColor = Color.FromName("LightGray");
        [Description("背景色")]
        public Color BackColorEx
        {
            get { return backColor; }
            set { backColor = value; labelText.BackColor = backColor; }
        }
        private Color clickColor = Color.FromName("DodgerBlue");
        [Description("背景色")]
        public Color ClickColorEx
        {
            get { return clickColor; }
            set { clickColor = value; }
        }
        /// <summary>
        /// 鼠标单击事件
        /// </summary>
        public event EventHandler ButtonClick;
        /// 鼠标单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label_Click(object sender, EventArgs e)
        {
            var buttonExParent = this.Parent;
            bool isClickedLast = IsClicked;
            //锁定单击状态,更新同组内buttonex的对应状态
            if ((buttonExParent is TableLayoutPanel)&& IsLockClickStatus)
            {
                foreach(var item in buttonExParent.Controls)
                {
                    if(item is ButtonExV1d0)
                    {
                        (item as ButtonExV1d0).IsClicked = false;
                        buttonExParent.Refresh();
                    }
                }
            }
            //不锁定单击状态
            if (!IsLockClickStatus)
            {
                //设置线程池
                ThreadPool.SetMinThreads(2, 1);
                ThreadPool.SetMaxThreads(4, 2);
                //将延时回复按钮颜色的方法放入线程池执行
                ThreadPool.QueueUserWorkItem(RestoreClickedStatus, sender);
            }
            if (!IsLockClickStatus)
            {
                if (ButtonClick != null)
                {
                    ButtonClick(sender, e);
                }
            }
            else
            {
                if (ButtonClick != null&& !isClickedLast)
                {
                    ButtonClick(sender, e);
                }
            }
            IsClicked = !isClickedLast;
            labelText.Refresh();
        }

        private void labelText_Paint(object sender, PaintEventArgs e)
        {
            if (IsClicked)
            {
                Rectangle borderRectangle = labelText.ClientRectangle;
                ControlPaint.DrawBorder(e.Graphics, borderRectangle,
                BorderColor, 2, ButtonBorderStyle.Solid, //左边
                BorderColor, 2, ButtonBorderStyle.Solid, //上边
                BorderColor, 2, ButtonBorderStyle.Solid, //右边
                BorderColor, 2, ButtonBorderStyle.Solid);//底边
                labelText.BackColor = ClickColorEx;
            }
            else labelText.BackColor = BackColorEx;
        }
        /// <summary>
        /// 延时回复按钮颜色
        /// </summary>
        /// <param name="item"></param>
        private void RestoreClickedStatus(object item)
        {
            Thread.Sleep(400);
            BeginInvoke(new Action(() => { IsClicked = false; this.Invalidate(true); this.Update(); }));
        }
    }
}
