using System.Threading.Tasks;
using BluePI.Entity;
using BluePI.Entity.CommEntity;
using BluePI.Helper;
using BluePI.IService;
using BluePI.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BluePI.Controllers
{
    /// <summary>
    /// Admin
    /// </summary>
    [Produces("application/json")]
    [Route("api/Admin")]
    [EnableCors("Limit")]
    //[Authorize]
    //[Authorize(Roles = "Admin")]
    //[Authorize(Policy = "RequireAdmin")]

    public class AdminController : Controller
    {
        private readonly IUserService userService;
        /// <summary>
        /// ctor
        /// </summary>
        public AdminController(IUserService _userService)
        {
            userService = _userService;
        } 

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        public JsonResult Register(UserModel userModel)
        {

            var userEntity = ConvertHelper.Convert<User>(userModel);
            var result = userService.Register(userEntity);
            return Json(result);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="queryParam"></param>
        /// <returns></returns>        
        [HttpPost]
        [Route("LogOn")]
        public JsonResult LogOn(UserQueryParam queryParam)
        {
            var status = new OperateStatus() { ResultSign = ResultSign.Error, MessageKey = "用户名或密码错误！" };
            if (string.IsNullOrEmpty(queryParam.LogoName) || string.IsNullOrEmpty(queryParam.Password))
            {
                status.MessageKey = "用户名密码不能为空";
                return Json(status);
            }

            var userInfo = userService.GetUser(queryParam);
            if (userInfo != null)
            {
                var tokenStr = JwtHelper.IssueJWT(new TokenModel()
                {
                    LogoName = userInfo.LogoName,
                    Id = userInfo.Id,
                    NickName = userInfo.NickName,
                    RoleId = userInfo.RoleId,
                    TokenType="Web"

                });
                status.FormatParams = tokenStr.Split(',');
                status.MessageKey = "成功";
                status.ResultSign = ResultSign.Successful;
            }
            return Json(status);
        }
        /// <summary>
        /// 获取用户信息test
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetUser")]
      //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public JsonResult GetUser()
        {
            // HttpContext.User.Identity.IsAuthenticated
            var data = userService.GetById(3);
            return Json(data);
        }
    }
}