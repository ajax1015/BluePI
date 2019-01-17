 using BluePI.Helper;
using BluePI.IService;
using BluePI.Model.ConfigModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BluePI.Controllers
{
    /// <summary>
    /// System
    /// </summary>
    [Produces("application/json")]
    [Route("api/System")]
    [EnableCors("Any")]
    public class SystemController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ISystemService _sysService;
        /// <summary>
        /// ctor
        /// </summary>
        public SystemController(ISystemService sysService)
        {
            _sysService = sysService;
        }

        #region 生成实体类
        /// <summary>
        /// 生成实体类
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Entity/Create")]
        public JsonResult CreateEntity(string entityName)
        {         

            return Json(_sysService.CreateEntity(entityName, BaseConfigModel.ContentRootPath));
        }
        #endregion

        #region Token
        /// <summary>
        /// 模拟登录，获取JWT
        /// </summary>
        /// <param name="tm"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Token")]
        public JsonResult GetJWTStr(TokenModel tm)
        {
            return Json(JwtHelper.IssueJWT(tm));
        }
        #endregion
    }
}