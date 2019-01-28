using BluePI.Entity.CommEntity;

namespace BluePI.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class UserQueryParam : AllInOneQueryParam
    {
        /// <summary>
        /// 登陆名称
        /// </summary>
        /// <value></value>
        public string LogoName { get; set; }
       /// <summary>
       /// 密码
       /// </summary>
       /// <value></value>
        public string  Password{get;set;} 
       
    }
}