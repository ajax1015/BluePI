using BluePI.IRepository;
using BluePI.Model;
using SqlSugar;
using System;

namespace BluePI.Repository
{
    /// <summary>
    /// 实体操作服务
    /// </summary>
    public class SystemRepository : BaseRepository<object>, ISystemRepository
    {
        /// <summary>
        /// 生成实体类
        /// </summary>
        /// <param name="entityName">实体（表）名称</param>
        /// <param name="filePath">web路径</param>
        /// <returns></returns>
        public bool CreateEntity(string entityName, string filePath)
        {
            //处理entity所存放的路径
            string[] arr = filePath.Split('\\');
            string baseFileProvider = "";
            for (int i = 0; i < arr.Length - 1; i++)
            {
                baseFileProvider += arr[i];
                baseFileProvider += "\\";
            }
            filePath = baseFileProvider + "BluePI.Entity";
            try
            {
                db.DbFirst
                    .IsCreateAttribute()
                    .Where(entityName)
                    .CreateClassFile(filePath, "BluePI.Entity");//存放路径，命名空间
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
