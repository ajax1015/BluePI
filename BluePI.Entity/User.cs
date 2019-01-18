using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace BluePI.Entity
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("user")]
    public partial class User
    {
        /// <summary>
        /// 
        /// </summary>
        public User()
        {


        }
        /// <summary>
        /// Desc:Id
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int Id { get; set; }
        /// <summary>
        /// Desc:联系方式（手机，QQ,微信等）
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Contact { get; set; }

        /// <summary>
        /// Desc:邮箱
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Email { get; set; }

        /// <summary>
        /// Desc:头像
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string HeadPic { get; set; }

        /// <summary>
        /// Desc:登陆名称
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string LogoName { get; set; }

        /// <summary>
        /// Desc:真实姓名
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Name { get; set; }

        /// <summary>
        /// Desc:昵称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string NickName { get; set; }

        /// <summary>
        /// Desc:住址
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Address { get; set; }

        /// <summary>
        /// Desc:登陆密码
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Password { get; set; }

        /// <summary>
        /// Desc:年龄
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? Age { get; set; }

        /// <summary>
        /// Desc:性别
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? Sex { get; set; }

    }
}
