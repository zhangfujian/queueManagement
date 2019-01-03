using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QueueHelperV1d0.Entity
{
    /// <summary>
    /// 桌台信息集
    /// </summary>
    [XmlRoot("餐桌基本信息")]
    [Serializable]
    public class DiningTableInfoSetV1d0
    {
        /// <summary>
        /// 桌台信息集名称
        /// </summary>
        [XmlElement("名称")]
        public string  Name { get; set; }
        /// <summary>
        /// 桌台信息列表
        /// </summary>
        [XmlArray("桌台类型集"),XmlArrayItem("桌台类型")]
        public List<DiningTableTypeV1d0> DiningTableTypeList { get; set; }
        [XmlArray("基本信息集"),XmlArrayItem("桌台信息")]
        public List<DiningTableInfoV1d0> DiningTableInfoList { get; set; }
        public DiningTableInfoSetV1d0()
        {
            Name = "通用";
            DiningTableTypeList = new List<DiningTableTypeV1d0>();
            DiningTableInfoList = new List<DiningTableInfoV1d0>();
        }
        /// <summary>
        /// 范例数据
        /// </summary>
        /// <returns></returns>
        public static DiningTableInfoSetV1d0 GetExampleData()
        {
            DiningTableInfoSetV1d0 diningTableInfoSet = new DiningTableInfoSetV1d0();
            diningTableInfoSet.Name = "测试";
            diningTableInfoSet.DiningTableTypeList.Add(new DiningTableTypeV1d0("Small", 1, 2));
            diningTableInfoSet.DiningTableTypeList.Add(new DiningTableTypeV1d0("Middle", 3, 8));
            diningTableInfoSet.DiningTableTypeList.Add(new DiningTableTypeV1d0("Big", 9, 12));
            diningTableInfoSet.DiningTableTypeList.Add(new DiningTableTypeV1d0("Huge", 13, 20));
            diningTableInfoSet.DiningTableTypeList.Add(new DiningTableTypeV1d0("Custom", 15, 25));
            //
            diningTableInfoSet.DiningTableInfoList.Add(new DiningTableInfoV1d0("S001", "hall", "Small", 1, 2, "Empty", "Empty"));
            diningTableInfoSet.DiningTableInfoList.Add(new DiningTableInfoV1d0("S002", "hall", "Small", 1, 2, "Empty", "Empty"));
            diningTableInfoSet.DiningTableInfoList.Add(new DiningTableInfoV1d0("S003", "hall", "Small", 1, 2, "Empty", "Empty"));
            diningTableInfoSet.DiningTableInfoList.Add(new DiningTableInfoV1d0("M001", "hall", "Middle", 3, 8, "Empty", "Empty"));
            diningTableInfoSet.DiningTableInfoList.Add(new DiningTableInfoV1d0("M002", "hall", "Middle", 3, 8, "Empty", "Empty"));
            diningTableInfoSet.DiningTableInfoList.Add(new DiningTableInfoV1d0("M003", "hall", "Middle", 3, 8, "Empty", "Empty"));
            diningTableInfoSet.DiningTableInfoList.Add(new DiningTableInfoV1d0("B001", "hall", "Big", 9, 12, "Empty", "Empty"));
            diningTableInfoSet.DiningTableInfoList.Add(new DiningTableInfoV1d0("B002", "hall", "Big", 9, 12, "Empty", "Empty"));
            diningTableInfoSet.DiningTableInfoList.Add(new DiningTableInfoV1d0("B003", "hall", "Big", 9, 12, "Empty", "Empty"));
            diningTableInfoSet.DiningTableInfoList.Add(new DiningTableInfoV1d0("B004", "hall", "Big", 9, 12, "Empty", "Empty"));
            diningTableInfoSet.DiningTableInfoList.Add(new DiningTableInfoV1d0("H001", "hall", "Huge", 13, 20, "Empty", "Empty"));
            diningTableInfoSet.DiningTableInfoList.Add(new DiningTableInfoV1d0("H002", "hall", "Huge", 13, 20, "Empty", "Empty"));
            diningTableInfoSet.DiningTableInfoList.Add(new DiningTableInfoV1d0("H003", "hall", "Huge", 13, 20, "Empty", "Empty"));
            diningTableInfoSet.DiningTableInfoList.Add(new DiningTableInfoV1d0("C001", "hall", "Cusmtom", 15, 25, "Empty", "Empty"));

            return diningTableInfoSet;
        }
    }
    /// <summary>
    /// 桌台信息
    /// </summary>
    [XmlRoot("餐桌信息")]
    [Serializable]
    public class DiningTableInfoV1d0
    {
        [XmlElement(ElementName = "Id", Type = typeof(Guid))]
        public Guid Id { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        [XmlAttribute("编号")]
        public string No { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        [XmlAttribute("位置")]
        public string Place { get; set; }
        /// <summary>
        /// 类型"Huge 13-20",“Big 9-12","Middle 3-8","Small 1-2"
        /// </summary>
        [XmlAttribute("类型")]
        public string Type { get; set; }
        /// <summary>
        /// 最多座位
        /// </summary>
        [XmlAttribute("最多座位数")]
        public int SeatCountMax { get; set; }
        /// <summary>
        /// 最少座位
        /// </summary>
        [XmlAttribute("最小座位数")]
        public int SeatCountMin { get; set; }
        /// <summary>
        /// 状态 "Empty","Occupied","Reserved"
        /// 空，占用，保留
        /// </summary>
        [XmlAttribute("状态")]
        public string Status { get; set; }
        [XmlAttribute("备注")]
        public string Comment { get; set; }
        public DiningTableInfoV1d0()
        {
            No = "001";
            Place = "";
            Type = "Small";
            SeatCountMax = 2;
            SeatCountMin = 1;
            Status = "Empty";
            Comment = "Empty";
            Id = Guid.NewGuid();
        }
        public DiningTableInfoV1d0(string no,string place,string type, int seatMin, int seatMax,string status,string remark)
        {
            Id = Guid.NewGuid();
            No = no;
            Place = place;
            Type = type;
            SeatCountMax = seatMax;
            SeatCountMin = seatMin;
            Status = status;
            Comment = remark;
        }
    }
    /// <summary>
    /// 桌台类型
    /// </summary>
    [XmlRoot("桌台类型")]
    [Serializable]
    public class DiningTableTypeV1d0
    {
        [XmlElement(ElementName = "Id", Type = typeof(Guid))]
        public Guid Id { get; set; }
        [XmlAttribute("类型")]
        public string Type { get; set; }
        /// <summary>
        /// 最多座位
        /// </summary>
        [XmlAttribute("最多座位数")]
        public int SeatCountMax { get; set; }
        /// <summary>
        /// 最少座位
        /// </summary>
        [XmlAttribute("最小座位数")]
        public int SeatCountMin { get; set; }
        public DiningTableTypeV1d0()
        {
            Type = "Small";
            SeatCountMax = 1;
            SeatCountMin = 1;
            Id = Guid.NewGuid();
        }
        public DiningTableTypeV1d0(string type,int seatCountMin,int seatCountMax)
        {
            Id = Guid.NewGuid();
            Type = type;
            SeatCountMin = seatCountMin;
            SeatCountMax = seatCountMax;
        }
    }
}
