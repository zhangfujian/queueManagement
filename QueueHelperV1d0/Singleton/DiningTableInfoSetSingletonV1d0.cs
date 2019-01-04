using QueueHelperV1d0.Entity;
using QueueHelperV1d0.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ZhangLogSysV1d0;

namespace QueueHelperV1d0.Singleton
{
    public class DiningTableInfoSetSingletonV1d0
    {
        private static DiningTableInfoSetSingletonV1d0 _instance = null;
        private DiningTableInfoSetV1d0 DiningTableInfoSet = new DiningTableInfoSetV1d0();
        private static readonly object syslock = new object();
        /// <summary>
        /// 单例模式
        /// </summary>
        public static DiningTableInfoSetSingletonV1d0 Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syslock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DiningTableInfoSetSingletonV1d0();
                        }
                    }
                }
                return _instance;
            }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        private DiningTableInfoSetSingletonV1d0()
        {
            LoadData();
        }
        /// <summary>
        /// 装载数据
        /// </summary>
        private void LoadData()
        {
            try
            {
                string currDir = System.IO.Directory.GetCurrentDirectory();
                string filename = currDir + @"\parameter\DiningTableInfoSet.xml";
                DiningTableInfoSet = HotchPotchV1d0.ReadFromXmlFile<DiningTableInfoSetV1d0>(filename);
            }
            catch(Exception ex)
            {
                SimpleLoger.Instance.Error(ex);
            }

        }
        /// <summary>
        /// 得到适合就餐人数的桌台类型
        /// </summary>
        /// <param name="numberOfMeals">就餐人数</param>
        /// <returns></returns>
        public DiningTableTypeV1d0 GetDiningTableType(int numberOfMeals)
        {
            DiningTableTypeV1d0 tableType = new DiningTableTypeV1d0();
            List<DiningTableTypeV1d0> filterSeatMin =
                DiningTableInfoSet.DiningTableTypeList.FindAll(x => x.SeatCountMin <= numberOfMeals&& numberOfMeals<=x.SeatCountMax);
            //升序
            tableType = filterSeatMin.OrderBy(x => x.SeatCountMax).First();
            return tableType;
        }
    }
}
