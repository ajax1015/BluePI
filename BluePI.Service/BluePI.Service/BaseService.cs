using System;
using System.Collections.Generic;
using BluePI.Entity;
using BluePI.IService;
using BluePI.Entity.CommEntity;
using BluePI.IRepository;

namespace BluePI.Service
{

    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {

        private static IBaseRepository<TEntity> baseRepository;
        public BaseService(IBaseRepository<TEntity> baseRep)
        {
            baseRepository = baseRep;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="status"></param>
        public void Create(TEntity entity, out OperateStatus status)
        {
            status = new OperateStatus() { ResultSign = ResultSign.Error };
            var isSucc = baseRepository.Add(entity);
            if (isSucc)
            {
                status.ResultSign = ResultSign.Successful;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        public void Delete(int id, out OperateStatus status)
        {
            status = new OperateStatus() { ResultSign = ResultSign.Error };
            int[] ids = new int[] { id };
            var isSucc = baseRepository.Dels((dynamic)ids);
            if (isSucc)
            {
                status.ResultSign = ResultSign.Successful;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="status"></param>
        public void DeleteByIds(dynamic[] ids, out OperateStatus status)
        {
            status = new OperateStatus() { ResultSign = ResultSign.Error };
            var isSucc = baseRepository.Dels(ids);
            if (isSucc)
            {
                status.ResultSign = ResultSign.Successful;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity GetById(int id)
        {
            return baseRepository.Get((long)id);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="status"></param>
        public void Update(TEntity entity, out OperateStatus status)
        {
            status = new OperateStatus() { ResultSign = ResultSign.Error };
            var isSucc = baseRepository.Update(entity);
            if (isSucc)
            {
                status.ResultSign = ResultSign.Successful;
            }
        }
    }

}