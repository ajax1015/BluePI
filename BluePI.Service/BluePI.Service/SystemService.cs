
using BluePI.IRepository;
using BluePI.IService;

namespace BluePI.Service
{
    public class SystemService :ISystemService
    {

        /// <summary>
        /// 
        /// </summary>
        private readonly ISystemRepository _sysRep;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="sysRep"></param>
        public SystemService(ISystemRepository sysRep)
        {
            _sysRep = sysRep;
        }
         /// <summary>
         /// 创建实体
         /// </summary>
         /// <param name="entityName"></param>
         /// <param name="path"></param>
         /// <returns></returns>
        public bool CreateEntity(string entityName,string path)
        {
           return _sysRep.CreateEntity(entityName,path);
        }
    }
}