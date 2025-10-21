using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private int GetCurrentUserId()
        {
            return Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Purchases()
        {
            //var isLoggedIn = this.HttpContext.User.Identity.IsAuthenticated;
            //if (!isLoggedIn)
            //{
            //    return RedirectToAction("Login", "Account");
            //}
            //else {
            //    var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            //}
            // Get purchased movies by userId and pass to the view
            var userId = GetCurrentUserId();
            return View();
        }
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Favorites()
        {
            var userId = GetCurrentUserId();
            return View();
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Reviews()
        {
            var userId = GetCurrentUserId();
            return View();
        }
    }
}
