﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QueueHelperV1d0.Entity;
using ZhangLogSysV1d0;
using QueueHelperV1d0.Service;
using System.IO;

namespace QueueHelperV1d0.Ui
{
    public partial class UCDiningTableInfoSetupV1d0 : UserControl
    {
        public UCDiningTableInfoSetupV1d0()
        {
            InitializeComponent();
            DiningTableInfoSet = new DiningTableInfoSetV1d0();
            Init();
        }
        private DiningTableInfoSetV1d0 DiningTableInfoSet { get; set; }
        public void Init()
        {
            InitDataGridViewInfoSet();
        }
        /// <summary>
        /// 初始化桌台信息集表格
        /// </summary>
        public void InitDataGridViewInfoSet()
        {
            try
            {
                var typeList = DiningTableInfoSet.DiningTableTypeList;
                int rowCount = typeList.Count();

                gridInfoSet.AutoRedraw = false;  // 禁止刷新表格
                gridInfoSet.Refresh();
                gridInfoSet.Cols = 6;
                gridInfoSet.Rows = rowCount + 1;
                gridInfoSet.Cell(0, 1).Text = "桌台类型";
                gridInfoSet.Cell(0, 2).Text = "类型前缀";
                gridInfoSet.Cell(0, 3).Text = "座位数下限";
                gridInfoSet.Cell(0, 4).Text = "座位数上限";
                gridInfoSet.Cell(0, 5).Text = "桌台个数";
                gridInfoSet.Column(1).CellType = FlexCell.CellTypeEnum.TextBox;
                gridInfoSet.Column(2).CellType = FlexCell.CellTypeEnum.TextBox;
                gridInfoSet.Column(3).CellType = FlexCell.CellTypeEnum.TextBox;
                gridInfoSet.Column(4).CellType = FlexCell.CellTypeEnum.TextBox;
                gridInfoSet.Column(5).CellType = FlexCell.CellTypeEnum.TextBox;

                for (int i = 0; i < rowCount; i++)
                {
                    gridInfoSet.Cell(i + 1, 1).Text = typeList[i].Type;
                    gridInfoSet.Cell(i + 1, 2).Text = typeList[i].TypePrefix;
                    gridInfoSet.Cell(i + 1, 3).Text = typeList[i].SeatCountMin.ToString();
                    gridInfoSet.Cell(i + 1, 4).Text = typeList[i].SeatCountMax.ToString();
                    gridInfoSet.Cell(i + 1, 5).Text = DiningTableInfoSet.DiningTableInfoList.FindAll(x => x.Type == typeList[i].Type).Count().ToString();
                }
                gridInfoSet.AutoRedraw = true;
                gridInfoSet.Refresh();
                if(rowCount>0) gridInfoSet.Cell(1, 1).SetFocus();
            }
            catch(Exception ex)
            {
                SimpleLoger.Instance.Error(ex);
            }
        }
        /// <summary>
        /// 初始化桌台明细表格
        /// </summary>
        /// <param name="tableType"></param>
        public void InitDataGridViewInfo(string tableType)
        {
            try
            {
                var infoList = DiningTableInfoSet.DiningTableInfoList.FindAll(x => x.Type == tableType);
                int rowCount = infoList.Count();
                gridInfo.AutoRedraw = false;  // 禁止刷新表格
                gridInfo.Refresh();
                gridInfo.Cols = 5;
                gridInfo.Rows = rowCount + 1;
                gridInfo.Cell(0, 1).Text = "编号";
                gridInfo.Cell(0, 2).Text = "位置";
                gridInfo.Cell(0, 3).Text = "状态";
                gridInfo.Cell(0, 4).Text = "备注";
                gridInfo.Column(1).CellType = FlexCell.CellTypeEnum.TextBox;
                gridInfo.Column(2).CellType = FlexCell.CellTypeEnum.TextBox;
                gridInfo.Column(3).CellType = FlexCell.CellTypeEnum.ComboBox;
                gridInfo.Column(4).CellType = FlexCell.CellTypeEnum.TextBox;
                for (int i = 0; i < infoList.Count; i++)
                {
                    gridInfo.Cell(i + 1, 1).Text = infoList[i].No;
                    gridInfo.Cell(i + 1, 2).Text = infoList[i].Place;
                    gridInfo.Cell(i + 1, 3).Text = infoList[i].Status;
                    gridInfo.Cell(i + 1, 4).Text = infoList[i].Comment;
                }
                //设置combobox
                FlexCell.ComboBox cb = gridInfo.ComboBox(3);
                cb.DropDownFont = new Font("Courier New", 9);
                cb.Items.Clear();
                cb.Items.Add("Empty");
                cb.Items.Add("Occupied");
                cb.Items.Add("Reserved");
                gridInfo.AutoRedraw = true;
                gridInfo.Refresh();
            }
            catch (Exception ex)
            {
                SimpleLoger.Instance.Error(ex);
            }
        }
        public DiningTableInfoSetV1d0 GetData()
        {
            DiningTableInfoSetV1d0 diningTableInfoSet = new DiningTableInfoSetV1d0();
            diningTableInfoSet = DiningTableInfoSetV1d0.GetExampleData();
            return diningTableInfoSet;
        }       

        private void gridInfoSet_Click(object Sender, EventArgs e)
        {

        }

        private void gridInfoSet_RowColChange(object Sender, FlexCell.Grid.RowColChangeEventArgs e)
        {
            string tableType = gridInfoSet.Cell(e.Row, 1).Text;
            {
                InitDataGridViewInfo(tableType);
            }
        }

        private void UCDiningTableInfoSetupV1d0_Load(object sender, EventArgs e)
        {
            DiningTableInfoSet = GetData();
            Init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gridInfoSet.Rows = gridInfoSet.Rows + 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            gridInfo.Rows = gridInfo.Rows + 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveGridInfoSetData();
        }
        /// <summary>
        /// 保存桌台信息集数据
        /// </summary>
        private void SaveGridInfoSetData()
        {
            try
            {
                DiningTableInfoSet.DiningTableTypeList.Clear();
                for (int i = 0; i < gridInfoSet.Rows; i++)
                {
                    string type = gridInfoSet.Cell(i + 1, 1) == null ? "" : gridInfoSet.Cell(i + 1, 1).Text;
                    int seatMin = gridInfoSet.Cell(i + 1, 2) == null ? 0 : gridInfoSet.Cell(i + 1, 2).IntegerValue;
                    int seatMax = gridInfoSet.Cell(i + 1, 3) == null ? 0 : gridInfoSet.Cell(i + 1, 3).IntegerValue;
                    if (!string.IsNullOrEmpty(type) && seatMin > 0 && seatMax > 0)
                    {
                        DiningTableInfoSet.DiningTableTypeList.Add(new DiningTableTypeV1d0(type, seatMin, seatMax));
                    }
                }
                SaveToXmlFile();
            }
            catch (Exception ex)
            {
                SimpleLoger.Instance.Error(ex);
            }
        }
        private void SaveToXmlFile()
        {
            string appPath = Application.StartupPath;
            string xmlPath = appPath + @"\parameter\";
            if (!Directory.Exists(xmlPath)) Directory.CreateDirectory(xmlPath);
            HotchPotchV1d0.SaveToXmFile<DiningTableInfoSetV1d0>(DiningTableInfoSet, xmlPath + "DiningTableInfoSet.xml");

        }
        private void button5_Click(object sender, EventArgs e)
        {
            SaveGridInfoData();
        }
        /// <summary>
        /// 保存桌台明细数据
        /// </summary>
        private void SaveGridInfoData()
        {
            try
            {
                string tableType = gridInfoSet.Cell(gridInfoSet.Selection.FirstRow, 1).Text;
                int seatMin = gridInfoSet.Cell(gridInfoSet.Selection.FirstRow, 2).IntegerValue;
                int seatMax = gridInfoSet.Cell(gridInfoSet.Selection.FirstRow, 3).IntegerValue;
                //string tableType= gridInfo.Cell(1, 1) == null ? "" : gridInfo.Cell(1, 1).Text;
                if (!string.IsNullOrEmpty(tableType))
                {
                    //删除原数据
                    DiningTableInfoSet.DiningTableInfoList.RemoveAll(x => x.Type == tableType);
                    for (int i = 0; i < gridInfo.Rows - 1; i++)
                    {
                        var cel = gridInfo.Cell(i + 1, 1).DisplayText;
                        string no = gridInfo.Cell(i + 1, 1) == null ? "" : gridInfo.Cell(i + 1, 1).Text;
                        string place = gridInfo.Cell(i + 1, 2) == null ? "" : gridInfo.Cell(i + 1, 2).Text;
                        string status = gridInfo.Cell(i + 1, 3) == null ? "" : gridInfo.Cell(i + 1, 3).Text;
                        string comment = gridInfo.Cell(i + 1, 4) == null ? "" : gridInfo.Cell(i + 1, 4).Text;
                        if (!string.IsNullOrEmpty(no) && !string.IsNullOrEmpty(status))
                        {
                            DiningTableInfoSet.DiningTableInfoList.Add(new DiningTableInfoV1d0(no, place, tableType, seatMin, seatMax, status, comment));
                        }
                    }
                    SaveToXmlFile();
                }
            }
            catch (Exception ex)
            {
                SimpleLoger.Instance.Error(ex);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string tableType = gridInfoSet.Cell(gridInfoSet.Selection.FirstRow, 1).Text;
            DiningTableInfoSet.DiningTableInfoList.RemoveAll(x => x.Type == tableType);
            DiningTableInfoSet.DiningTableTypeList.RemoveAll(x => x.Type == tableType);
            InitDataGridViewInfoSet();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tableNo = gridInfoSet.Cell(gridInfo.Selection.FirstRow, 1).Text;
            DiningTableInfoSet.DiningTableInfoList.RemoveAll(x => x.No == tableNo);
            InitDataGridViewInfoSet();
        }
    }
}
