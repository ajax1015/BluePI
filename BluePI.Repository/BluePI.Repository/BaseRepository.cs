using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using BluePI.Helper;
using BluePI.Model.ReturnModel;
using SqlSugar;

namespace BluePI.Repository
{
    /// <summary>
    /// 服务层基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseRepository<T> where T : class, new()
    {
        public BaseRepository()
        {


            db = SqlSugarHelper.GetClient();
            sdb = db.GetSimpleClient();
        }
        public SqlSugarClient db;
        public SimpleClient sdb;

        #region CRUD
        public TableModel<T> GetPageList(int pageIndex, int pageSize)
        {
            PageModel p = new PageModel() { PageIndex = pageIndex, PageSize = pageSize };
            Expression<Func<T, bool>> ex = (it => 1 == 1);
            List<T> data = sdb.GetPageList(ex, p);
            var t = new TableModel<T>
            {
                Code = 0,
                Count = p.PageCount,
                Data = data,
                Msg = "成功"
            };
            return t;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(long id)
        {
            return sdb.GetById<T>(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Add(T entity)
        {
            return sdb.Insert(entity);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            return sdb.Update(entity);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool Dels(dynamic[] ids)
        {
            return sdb.DeleteByIds<T>(ids);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <typeparam name="T"></typeparam>

    #endregion
}
}
