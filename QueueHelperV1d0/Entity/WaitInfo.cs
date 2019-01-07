using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueHelperV1d0.Entity
{
    /// <summary>
    /// 排队信息
    /// </summary>
    public class WaitInfoV1d0
    {
        public Guid Id { get; set; }
        public int CallSn{get;set;}
        public string CallNo { get; set; }// 叫號
        /// <summary>
        /// 排在前面的个数
        /// </summary>
        public int CountWaitedAhead { get; set; }
        /// <summary>
        /// 顾客id
        /// </summary>
        public Guid CustomerId { get; set; }
        /// <summary>
        /// 用户电话
        /// </summary>
        public String CustomerTelephone { get; set; }
        /// <summary>
        /// 取號時間
        /// </summary>
        public DateTime TakeTime { get; set; }
        /// <summary>
        /// 就餐人数
        /// </summary>
        public int NumberOfMeals { get; set; }
        /// <summary>
        /// 狀態   0 正在輪候   1 已安排   2 過號   ﹣1 取消
        /// </summary>
        public int Status { get; set; }
        public WaitInfoV1d0()
        {
            Id = Guid.NewGuid();
            NumberOfMeals = 6;
            CallSn = 0;
            CallNo = "000";
            CustomerId= Guid.NewGuid();
            CustomerTelephone = "13500000000";
            TakeTime = DateTime.Now;
            Status = 0;
            CountWaitedAhead = 0;
        }
        public WaitInfoV1d0(int callSn,int numberOfMeals,string customerTelephone,DateTime takeTime)
        {
            CallSn = 0;
            Id = Guid.NewGuid();
            NumberOfMeals = numberOfMeals;
            CallNo = callSn.ToString("#000");
            CustomerId = Guid.NewGuid();
            CustomerTelephone = customerTelephone;
            TakeTime = takeTime;
            Status = 0;
            CountWaitedAhead = 0;
        }
    }
}
