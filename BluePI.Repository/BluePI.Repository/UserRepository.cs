
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
            //使用不可逆的方式加密密码
            user.Password = PwdHelper.Get32MD5Two(user.Password);
            var userEntity = GetUser(new UserQueryParam() { LogoName = user.LogoName, Password = user.Password });
            //登录名和密码匹配登录成功
            if (userEntity != null && (userEntity.LogoName == user.LogoName && userEntity.Password == user.Password))
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
        /// <summary>
        /// 根据用户名密码获取用户信息
        /// </summary>
        /// <param name="user"></param>       
        /// <returns></returns>
        public User GetUser(UserQueryParam queryParam)
        {
            queryParam.Password = string.IsNullOrEmpty(queryParam.Password) ? string.Empty : PwdHelper.Get32MD5Two(queryParam.Password);
            return db.Queryable<User>().Where(f =>
            (string.IsNullOrEmpty(queryParam.Value) || f.LogoName == queryParam.Value || f.Contact == queryParam.Value || f.Email == queryParam.Value)
            && (string.IsNullOrEmpty(queryParam.LogoName) || f.LogoName == queryParam.LogoName)
            && (string.IsNullOrEmpty(queryParam.Password) || f.Password == queryParam.Password)
             ).First();
        }
    }
}