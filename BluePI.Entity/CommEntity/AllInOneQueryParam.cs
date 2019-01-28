using System.Runtime.Serialization;

namespace BluePI.Entity.CommEntity
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract(IsReference = true)]
    public class AllInOneQueryParam : QueryParam
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember]
        public string Value
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryParam"></param>
        public void CopyFromAllInOne(AllInOneQueryParam queryParam)
        {
            base.Page = queryParam.Page;
            base.Rows = queryParam.Rows;
            base.Sord = queryParam.Sord;
            base.Sidx = queryParam.Sidx;
            this.Value = queryParam.Value;
        }
    }
}