using Microsoft.AspNetCore.Mvc;
using System;

namespace LastVisitTrackingApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // ��������� �� ����������� "LastVisit"
            string lastVisit = Request.Cookies["LastVisit"];
            if (!string.IsNullOrEmpty(lastVisit))
            {
                ViewBag.LastVisit = $"�������� ���������: {lastVisit}";
            }
            else
            {
                ViewBag.LastVisit = "���� � ������� �� ���������!";
            }

            // ��������� �� �������� ���� � ��� � ���������
            string currentDateTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            Response.Cookies.Append("LastVisit", currentDateTime, new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = DateTime.Now.AddDays(30) // ����������� �� ���� ������� 30 ���
            });

            return View();
        }
    }
}
