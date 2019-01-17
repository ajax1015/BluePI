

using BluePI.Entity;
using BluePI.Entity.CommEntity;

namespace BluePI.IService
{
    public interface IUserService
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
         OperateStatus Register(User user);
    }
}