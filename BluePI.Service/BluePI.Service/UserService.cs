using BluePI.Entity;
using BluePI.IService;
using BluePI.IRepository;
using BluePI.Entity.CommEntity;

namespace BluePI.Service
{
    /// <summary>
    /// 用户管理服务
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IUserRepository userRepository;
        /// <summary>
        /// ctor
        /// </summary>
        public UserService(IUserRepository _userRepository)
        {

            userRepository = _userRepository;
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public OperateStatus LogOn(User user)
        {
             return userRepository.LogOn(user);
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public OperateStatus Register(User user)
        {
            return userRepository.Register(user);
        }
    }
}