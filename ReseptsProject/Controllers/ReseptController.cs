using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReseptsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using XAct.Library.Settings;

namespace ReseptsProject.Controllers
{
    public class ReseptController : Controller
    {
        MyReseptsDBContext db = new MyReseptsDBContext();

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult GetResepts()
        {
            var resepts = db.Resepts.Include(c => c.Category).Where(r => r.Deleted == false).ToList();

            return View(resepts);
        }

        public IActionResult ReseptDetails(int id, Category category)
        {
            var resept = db.Resepts.Include(c=>c.Category).Where(r => r.ReseptId == id && r.Deleted == false).First();

            
            return View(resept);
        }

        private IEnumerable<object> Include()
        {
            throw new NotImplementedException();
        }
    }
}
