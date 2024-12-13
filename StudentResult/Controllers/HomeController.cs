using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using StudentResult.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace StudentResult.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.NAME = TempData.Peek("NAME");
            ViewBag.total = TempData.Peek("total");
            ViewBag.Result = TempData.Peek("Result");
            ViewBag.Average = TempData.Peek("Average");
            ViewBag.Sub1 = TempData.Peek("Sub1");
            ViewBag.Sub2 = TempData.Peek("Sub2");
            ViewBag.Sub3 = TempData.Peek("Sub3");
            ViewBag.Sub4 = TempData.Peek("Sub4");
            ViewBag.Sub5 = TempData.Peek("Sub5");

            return View();
        }

        [HttpPost]
        public IActionResult Index(Studentresult re)
        {
            
            int sub1 = re.sub1;
            int sub2 = re.sub2;
            int sub3 = re.sub3;
            int sub4 = re.sub4;
            int sub5 = re.sub5;
            string Name = re.name;
            int count = 0;
            int Total = sub1 + sub2 + sub3 + sub4 + sub5;
            double average = Total / 5;
            string result = null;
            
            if(sub1 <= 35)
            {
                count = count + 1;
            }
            if (sub2 <= 35)
            {
                count = count + 1;
            }
            if (sub3 <= 35)
            {
                count = count + 1;
            }
            if (sub4 <= 35)
            {
                count = count + 1;
            }
            if (sub5 <= 35)
            {
                count = count + 1;
            }

            if (count > 3)
            {
                result = "Fail";
            }
            if (count <= 3)
            {
                result = "Atkt";
            }
           if (count == 0)
           {
               result = "Pass";
            }
                 
            TempData["total"] = Total.ToString();
            TempData["Average"] = average.ToString();
            TempData["Result"] = result;
            TempData["NAME"] = Name;
            TempData["Sub1"] = sub1.ToString();
            TempData["Sub2"] = sub2.ToString();
            TempData["Sub3"] = sub3.ToString();
            TempData["Sub4"] = sub4.ToString();
            TempData["Sub5"] = sub5.ToString();

            re.Insert(Name,sub1,sub2,sub3,sub4,sub5,Total,(int)average,result);
            
            return RedirectToAction();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
