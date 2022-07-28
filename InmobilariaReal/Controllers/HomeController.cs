using InmobilariaReal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace InmobilariaReal.Controllers
{
    public class HomeController : Controller
    {
        private readonly CasarealContext _DBContext;

        public HomeController(CasarealContext dBContext)
        {
            _DBContext = dBContext;
        }

        public IActionResult Index()
        {
            return View();
        }

       
    }
}