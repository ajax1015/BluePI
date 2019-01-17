using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace BluePI.Entity.CommEntity
{
    /// <summary>
    /// 分页结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract(IsReference = true), KnownType(typeof(PagerInfo))]
        public class PagedResults<T>
    {
          /// <summary>
        /// 分页信息
        /// </summary>
        /// <value></value>
        [DataMember]
        public PagerInfo PagerInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 分页数据
        /// </summary>
        /// <value></value>
        [DataMember]
        public System.Collections.Generic.IList<T> Data
        {
            get;
            set;
        }
        /// <summary>
        /// ctor
        /// </summary>
        public PagedResults()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public PagedResults(QueryParam param)
        {
            this.PagerInfo = new PagerInfo(param);
            this.Data = new List<T>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="converter"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public PagedResults<TResult> ConvertTo<TResult>(Func<T, TResult> converter)
        {
            return new PagedResults<TResult>
            {
                PagerInfo = this.PagerInfo,
                Data = this.Data.Select(converter).ToArray<TResult>()
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagedResults"></param>
        /// <returns></returns>
        public static PagedResults<T> ConvertFrom(object pagedResults)
        {
            System.Type type = pagedResults.GetType();
            object value = type.GetProperty("PagerInfo").GetValue(pagedResults, null);
            object value2 = type.GetProperty("Data").GetValue(pagedResults, null);
            System.Reflection.MethodInfo method = typeof(Enumerable).GetMethod("Cast", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
            System.Collections.Generic.IEnumerable<T> source = (System.Collections.Generic.IEnumerable<T>)method.MakeGenericMethod(new System.Type[]
            {
                typeof(T)
            }).Invoke(null, new object[]
            {
                value2
            });
            return new PagedResults<T>
            {
                PagerInfo = (PagerInfo)value,
                Data = source.ToArray<T>()
            };
        }
    }
}