using System;
using System.Collections.Generic;
using BluePI.Entity; 
using BluePI.IService;
using BluePI.Entity.CommEntity;

namespace BluePI.Service
{

    public abstract class BaseService<TEntity,TRepository> : IBaseService<TEntity> 
    { 
      
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="status"></param>
        public void Create(TEntity entity, out OperateStatus status)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        public void Delete(Guid id, out OperateStatus status)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity GetById(Guid id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public IList<TEntity> GetByValues(IList<Guid> values)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="status"></param>
        public void Update(TEntity entity, out OperateStatus status)
        {
            throw new NotImplementedException();
        }
    }

}