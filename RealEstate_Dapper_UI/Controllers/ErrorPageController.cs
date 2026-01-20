using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Controllers
{
    public class ErrorPageController : Controller
    {
        // 1. ÖZEL KAPI: Sadece 500 Hataları İçin
        [Route("ErrorPage/ServerError")]
        public IActionResult ServerError()
        {
            ViewBag.Message = "Sunucuda işler karıştı, müdahale ediyoruz.";
            return View("Error500");
        }

        // 2. GENEL KAPI: 404, 403 vb. için
        [Route("ErrorPage/Index")]
        public IActionResult Index([FromQuery] int code)
        {
            ViewBag.Code = code;

            if (code == 404)
            {
                ViewBag.Message = "Aradığın sayfayı bulamadık ama bir oyun bulduk!";
                return View("Error404");
            }
            else if (code == 401 || code == 403)
            {
                ViewBag.Message = "Buraya girmek için yetkiniz yok!";
                return View("AccessDenied");
            }

            return View("DefaultError");
        }
    }
}