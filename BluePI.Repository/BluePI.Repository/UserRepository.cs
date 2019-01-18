
using BluePI.Entity;
using BluePI.Entity.CommEntity;
using BluePI.Helper;
using BluePI.IRepository;

namespace BluePI.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public OperateStatus LogOn(User user)
        {
            var status = new OperateStatus()
            {
                MessageKey = "登录失败！用户名或密码错误",
                ResultSign = ResultSign.Error
            };
            var userEntity = this.Get((long)user.Id);
            ////使用不可逆的方式加密密码
            var encryptionPwd = PwdHelper.Get32MD5Two(user.Password);
            //登录名和密码匹配登录成功
            if (userEntity != null && (userEntity.LogoName == user.LogoName && userEntity.Password == encryptionPwd))
            {
                status.MessageKey = "登录成功！";
                status.ResultSign = ResultSign.Successful;

            }
            return status;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public OperateStatus Register(User user)
        {
            //使用不可逆的方式加密密码
            user.Password = PwdHelper.Get32MD5Two(user.Password);
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