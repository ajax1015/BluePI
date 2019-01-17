using System.Runtime.Serialization;

namespace BluePI.Entity.CommEntity
{
    /// <summary>
    /// 查询基类
    /// </summary>
    [DataContract(IsReference = true)]
    public class QueryParam
    {

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int StartIndex
        {
            get
            {
                return (this.Page - 1) * this.Rows;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember]
        public int Page
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember]
        public int Rows
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember]
        public string Sord
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember]
        public string Sidx
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string OrderString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.Sidx))
                {
                    this.Sidx = "Id";
                }
                return string.Format("{0} {1}", this.Sidx, this.Sord);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected QueryParam()
        {
            this.Rows = 10;
            this.Page = 1;
            this.Sord = "asc";
        }
    }
}