

using BluePI.Entity;
using BluePI.Entity.CommEntity;

namespace BluePI.IService
{
    public interface IUserService : IBaseService<User>
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        OperateStatus Register(User user);
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        OperateStatus LogOn(User user);

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="user"></param>       
        /// <returns></returns>
        User GetUser(UserQueryParam queryParam);
    }
}