using System.Runtime.Serialization;

namespace BluePI.Entity.CommEntity
{ /// <summary>
    ///操作状态返回类
    /// </summary>
    public class OperateStatus

    {
        /// <summary>
        ///  获取一个值，表示返回标记是否成功
        /// </summary>
        /// <value></value>
		public bool IsSuccessful
        {
            get
            {
                return this.ResultSign == ResultSign.Successful;
            }
        }
        /// <summary>
        /// 获取一个值，表示返回标记是否不成功
        /// </summary>
        /// <value></value>
        public bool IsNotSuccessful
        {
            get
            {
                return this.ResultSign != ResultSign.Successful;
            }
        }
        /// <summary>
        /// 返回标记
        /// </summary>
        /// <value></value>
        [DataMember]
        public ResultSign ResultSign
        {
            get;
            set;
        }
        /// <summary>
        /// 消息字符串key
        /// </summary>
        /// <value></value>
        [DataMember]
        public string MessageKey
        {
            get;
            set;
        }
        /// <summary>
        ///  消息的参数
        /// </summary>
        /// <value></value>
        [DataMember]
        public string[] FormatParams
        {
            get;
            set;
        }
        /// <summary>
        ///  构造函数
        /// </summary>
        public OperateStatus()
        {
            this.ResultSign = ResultSign.Successful;
            this.MessageKey = string.Empty;
        }
        /// <summary>
        /// 从操作状态构造
        /// </summary>
        /// <param name="status">  </param>
        public OperateStatus(OperateStatus status)
        {
            this.ResultSign = status.ResultSign;
            this.MessageKey = status.MessageKey;
            this.FormatParams = status.FormatParams;
        }
        /// <summary>
        ///  从操作状态复制
        /// </summary>
        /// <param name="status"></param>
        public void CopyFromStatus(OperateStatus status)
        {
            this.ResultSign = status.ResultSign;
            this.MessageKey = status.MessageKey;
            this.FormatParams = status.FormatParams;
        }
    }

     /// <summary>
    /// 操作状态枚举
    /// </summary>
    public enum ResultSign
    {

        /// <summary>
        /// 成功
        /// </summary>
        [EnumMember]
        Successful = 0,
        /// <summary>
        /// 警告
        /// </summary>
        [EnumMember]
        Warning = 1,
        /// <summary>
        /// 失败
        /// </summary>
        [EnumMember]
        Error = 2
    }
}