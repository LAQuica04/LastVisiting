using Microsoft.AspNetCore.Mvc;
using System;

namespace LastVisitTrackingApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Прочитане на бисквитката "LastVisit"
            string lastVisit = Request.Cookies["LastVisit"];
            if (!string.IsNullOrEmpty(lastVisit))
            {
                ViewBag.LastVisit = $"Последно посещение: {lastVisit}";
            }
            else
            {
                ViewBag.LastVisit = "Това е първото ви посещение!";
            }

            // Запазване на текущата дата и час в бисквитка
            string currentDateTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            Response.Cookies.Append("LastVisit", currentDateTime, new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = DateTime.Now.AddDays(30) // Бисквитката ще бъде валидна 30 дни
            });

            return View();
        }
    }
}
