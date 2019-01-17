using System;
using System.Collections.Generic;
using BluePI.Entity;
using BluePI.Entity.CommEntity;

namespace BluePI.IService
{
    public interface IBaseService<T>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="status"></param>
        void Create(T entity, out OperateStatus status);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="status"></param>
        void Update(T entity, out OperateStatus status);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        void Delete(Guid id, out OperateStatus status);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        IList<T> GetByValues(IList<Guid> values);

    }
}