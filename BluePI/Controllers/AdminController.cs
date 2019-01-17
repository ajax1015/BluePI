using BluePI.Entity;
using BluePI.IService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BluePI.Controllers
{
    /// <summary>
    /// Admin
    /// </summary>
    [Produces("application/json")]
    [Route("api/Admin")]
    [EnableCors("Any")]
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
        public JsonResult Register(User user)
        {
            var result = userService.Register(user);
            return Json(result);
        }      
    }
}