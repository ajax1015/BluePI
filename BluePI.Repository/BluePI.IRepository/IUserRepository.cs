using BluePI.Entity;
using BluePI.Entity.CommEntity;

namespace BluePI.IRepository
{
    public interface IUserRepository
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        OperateStatus Register(User user);
    }
}