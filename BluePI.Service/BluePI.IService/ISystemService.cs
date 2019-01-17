namespace BluePI.IService
{
    public interface ISystemService
    {
        /// <summary>
        /// 创建实体
        /// </summary>
        /// <returns></returns>
         bool CreateEntity(string entityName,string path);
    }
}