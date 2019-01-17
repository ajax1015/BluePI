
using BluePI.Entity;
using BluePI.Entity.CommEntity;
using BluePI.Helper;
using BluePI.IRepository;

namespace BluePI.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public OperateStatus Register(User user)
        {            
             //使用不可逆的方式加密密码
            user.Password=  PwdHelper.Get32MD5Two(user.Password); 
            var status = new OperateStatus()
            {
                MessageKey = "注册失败！",
                ResultSign = ResultSign.Error
            };
            var isSucc = Add(user);
            if (isSucc)
            {
                status.ResultSign = ResultSign.Successful;
                status.MessageKey = "注册成功！";
            }

            return status;
        }
    }
}