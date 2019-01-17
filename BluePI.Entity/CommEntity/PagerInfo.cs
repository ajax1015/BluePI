using System.Runtime.Serialization;

namespace BluePI.Entity.CommEntity
{

 
    /// <summary>
    /// 分页信息
    /// </summary>
    [DataContract]
    public class PagerInfo
    {
          /// <summary>
        /// 记录总条数
        /// </summary>
        /// <value></value>
        [DataMember]
        public int TotalRowCount
        {
            get;
            set;
        }
        /// <summary>
        /// 页数
        /// </summary>
        /// <value></value>
        [DataMember]
        public int PageSize
        {
            get;
            set;
        }
        /// <summary>
        /// 开始索引
        /// </summary>
        /// <value></value>
        [DataMember]
        public int StartIndex
        {
            get;
            set;
        }
        /// <summary>
        /// 页码
        /// </summary>
        /// <value></value>
        public int PageIndex
        {
            get
            {
                return PagerInfo.ComputePageIndex(this.StartIndex + 1, this.PageSize);
            }
        }
        /// <summary>
        /// 总页数
        /// </summary>
        /// <value></value>
        public int TotalPageCount
        {
            get
            {
                return PagerInfo.ComputePageIndex(this.TotalRowCount, this.PageSize);
            }
        }
        /// <summary>
        /// 查询参数赋值
        /// </summary>
        /// <param name="queryParam"></param>
        public PagerInfo(QueryParam queryParam)
        {
            this.PageSize = queryParam.Rows;
            this.StartIndex = queryParam.StartIndex;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="total"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private static int ComputePageIndex(int total, int pageSize)
        {
            int num2;
            int num = System.Math.DivRem(total, pageSize, out num2);
            if (num2 > 0)
            {
                num++;
            }
            return num;
        }
    }
}