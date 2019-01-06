using PrintUsingPrinterDriverHelperV1d0.Entity;
using PrintUsingPrinterDriverHelperV1d0.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverPrintTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // 这里的printDocument对象可以通过将PrintDocument控件拖放到窗体上来实现，注意要设置该控件的PrintPage事件。
            printDocument = new PrintDocument();
            printerResolution = printDocument.DefaultPageSettings.PrinterResolution;
            printDocument.PrintPage += new PrintPageEventHandler(this.printDocument_PrintPage);
        }
        public PrintDocument printDocument;
        public PrinterResolution printerResolution;
        StringReader lineReader = null;
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            Graphics g = e.Graphics; //获得绘图对象
            float linesPerPage = 0; //页面的行号
            float yPosition = 0;   //绘制字符串的纵向位置
            int count = 0; //行计数器
            float leftMargin = 2;// e.MarginBounds.Left; //左边距
            float topMargin = 2;// e.MarginBounds.Top; //上边距
            string line = null; //行字符串
            Font printFont = this.richTextBox1.Font; //当前的打印字体
            SolidBrush myBrush = new SolidBrush(Color.Black);//刷子
            linesPerPage = e.MarginBounds.Height / printFont.GetHeight(g);//每页可打印的行数
                                                                          //逐行的循环打印一页
            StringReader lineReader = new StringReader(richTextBox1.Text);
            while (count < linesPerPage && ((line = lineReader.ReadLine()) != null))
            {
                //yPosition = topMargin + (count * printFont.GetHeight(g));
                //float lineSpace = printFont.GetHeight(g);
                //StringFormat fmt = new StringFormat();
                //fmt.LineAlignment = StringAlignment.Near;//左对齐
                //fmt.FormatFlags = StringFormatFlags.LineLimit;//自动换行
                //g.DrawString(line, printFont, myBrush, leftMargin, yPosition, fmt);
                ////g.DrawString(line, printFont, myBrush, new Rectangle((int)leftMargin, (int)topMargin, 300, 200), fmt);// leftMargin, yPosition, new StringFormat());
                //count++;
                StringFormat fmt = new StringFormat();
                fmt.LineAlignment = StringAlignment.Near;//左对齐
                fmt.FormatFlags = StringFormatFlags.LineLimit;//自动换行

                //设定文本打印区域 b是左上角坐标，Size是打印区域（矩形） float mmtopt = 2.835f;
                float mmtopt = printerResolution.X / 100;
                //Rectangle r = new Rectangle(new Point(2,2), new Size(Convert.ToInt32(400 * mmtopt), Convert.ToInt32(100 * mmtopt)));
                Rectangle r = new Rectangle(new Point(2,2), new Size(Convert.ToInt32(76* 2.835), Convert.ToInt32(200 * mmtopt)));
                r.Y = r.Y - Convert.ToInt32(2 * mmtopt);

                Font titleFont = new Font(new FontFamily("仿宋"), 13, GraphicsUnit.Point);
                g.DrawString(line, titleFont, new SolidBrush(Color.Black), r, fmt);
            }
            // 注意：使用本段代码前，要在该窗体的类中定义lineReader对象：
            //       StringReader lineReader = null;
            //如果本页打印完成而line不为空,说明还有没完成的页面,这将触发下一次的打印事件。在下一次的打印中lineReader会
            //自动读取上次没有打印完的内容，因为lineReader是这个打印方法外的类的成员，它可以记录当前读取的位置
            if (line != null)
                e.HasMorePages = true;
            else
            {
                e.HasMorePages = false;
                // 重新初始化lineReader对象，不然使用打印预览中的打印按钮打印出来是空白页
                lineReader = new StringReader(richTextBox1.Text); // textBox是你要打印的文本框的内容
            }
        }

        /// <summary>
        /// 打印设置，构造打印对话框 将对话框中设置的Document属性赋给printDocument这样会将用户的设置自动保存到printDocument
        /// 的PrinterSettings属性中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FileMenuItem_PrintSet_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            printDialog.ShowDialog();
        }
        /// <summary>
        /// 页面设置和打印预览与打印设置原理相同都是构造对话框将用户在对话框中的
        /// 设置保存到相应的类的属性中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FileMenuItem_PageSet_Click(object sender, EventArgs e)
        {
            PageSetupDialog pageSetupDialog = new PageSetupDialog();
            pageSetupDialog.Document = printDocument;
            pageSetupDialog.ShowDialog();
        }
        
        /// <summary>
        /// 打印预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FileMenuItem_PrintView_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            lineReader = new StringReader(richTextBox1.Text);
            try
            {
                printPreviewDialog.ShowDialog();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 打印就可以直接调用printDocument的Print()方法因为用户可能在打印之前还要再更改打印设置所以
        ///在这里再次显示打印设置对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FileMenuItem_Print_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            
            lineReader = new StringReader(richTextBox1.Text);
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDocument.Print();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    printDocument.PrintController.OnEndPrint(printDocument, new PrintEventArgs());
                }
            }
        }
        public void GetPrintResolution()
        {
            PrinterResolution syz = printDocument.DefaultPageSettings.PrinterResolution;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StringBuilder sw = new StringBuilder();
            sw.Append("       S0011234567892asdfghj");
            sw.Append("订单编号1：" );
            sw.Append("订单编号2：" );
            sw.Append("订单编号3：" );
            sw.Append("订单编号4：" );

            printDocument = new PrintDocument();
            string printerName = printDocument.PrinterSettings.PrinterName;
            var currPrinter = PrinterFactory.GetPrinter("printerName", PaperWidth.Paper76mm);
            currPrinter.PrintText("排队序号S001");
            currPrinter.NewRow();
            currPrinter.PrintText("序号：");
            currPrinter.NewRow();
            currPrinter.PrintText("前面还有00位");
            currPrinter.NewRow();
            currPrinter.PrintText("排队时间：" + DateTime.Now.ToString("yyyyMMdd hh:mm:ss"));
           // currPrinter.PrintLine();
            //currPrinter.Finish();
            currPrinter.Finish();
        }
    }
}
