using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
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
            var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            return View();
        }
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Favorites()
        {
            var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            return View();
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Reviews()
        {
            var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            return View();
        }
    }
}
