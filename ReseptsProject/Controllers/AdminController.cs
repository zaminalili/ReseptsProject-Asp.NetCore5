using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReseptsProject.Models;
using System;
using System.Linq;
using System.Text;
using XSystem.Security.Cryptography;

namespace ReseptsProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        MyReseptsDBContext db = new MyReseptsDBContext();
        public IActionResult Index()
        {
            return View();
        }

        

       

        public IActionResult Pages()
        {
            var pages = db.Pages.Where(p => p.Deleted == false).ToList();
            
            return View(pages);
        }

        public IActionResult AddPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPage(Page p)
        {
            p.Deleted = false;
            db.Pages.Add(p);
            db.SaveChanges();
            return RedirectToAction("Pages");
        }


        public IActionResult GetPage(int id)
        {
            var page = db.Pages.Where(p => p.PageId == id && p.Deleted == false).First();

            return View(page);
        }

        public IActionResult UpdatePage(Page newPage)
        {
            var page = db.Pages.Where(p => p.PageId == newPage.PageId && p.Deleted == false).First();
            page.Title = newPage.Title;
            page.Content = newPage.Content;
            page.Active = newPage.Active;
            db.SaveChanges();

            return RedirectToAction("Pages");
        }

        public IActionResult DeletePage(int id)
        {
            var page = db.Pages.Where(p => p.PageId == id && p.Deleted==false).First();
            //db.Pages.Remove(page);
            page.Deleted = true;
            db.SaveChanges();

            return RedirectToAction("Pages");
        }


        public IActionResult Categories()
        {
            var categories = db.Categories.Where(c => c.Deleted == false).ToList();

            return View(categories);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category c)
        {
            c.Deleted = false;
            db.Categories.Add(c);
            db.SaveChanges();
            return RedirectToAction("Categories");
        }


        public IActionResult GetCategory(int id)
        {
            var category = db.Categories.Where(c => c.CategoryId == id && c.Deleted == false).First();

            return View(category);
        }

        public IActionResult UpdateCategory(Category newCategory)
        {
            var category = db.Categories.Where(c => c.CategoryId == newCategory.CategoryId && c.Deleted == false).First();
            category.CategoryName = newCategory.CategoryName;
            category.Active = newCategory.Active;
            db.SaveChanges();

            return RedirectToAction("Categories");
        }



        public IActionResult DeleteCategory(int id)
        {
            var category = db.Categories.Where(c => c.CategoryId == id && c.Deleted == false).First();
            category.Deleted = true;
            db.SaveChanges();

            return RedirectToAction("Categories");
        }



        public IActionResult CategoryResepts(int id)
        {
            var resepts = db.Resepts.Where(r => r.CategoryId == id && r.Deleted == false).ToList();

            return View(resepts);
        }



        public IActionResult Resepts()
        {
            var resepts = db.Resepts.Include(c => c.Category).Where(r => r.Deleted == false).ToList();

            return View(resepts);
        }

        public IActionResult AddResept()
        {
            var categories =(from c in db.Categories.Where(c => c.Active==true && c.Deleted == false).ToList() 
            select new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.CategoryId.ToString()
            });
            ViewBag.Category = categories;

            return View();
        }

        [HttpPost]
        public IActionResult AddResept(Resept r)
        {
            r.Deleted = false;
            r.CreateDate = DateTime.Now;
            db.Resepts.Add(r);
            db.SaveChanges();

            return RedirectToAction("Resepts");
        }


        public IActionResult GetResept(int id)
        {
            var resept = db.Resepts.Where(r => r.ReseptId == id && r.Deleted == false).First();

            return View(resept);
        }

        public IActionResult UpdateResept(Resept newResept)
        {
            var resept = db.Resepts.Where(r => r.ReseptId == newResept.ReseptId && r.Deleted == false).First();
            resept.EatName = newResept.EatName;
            resept.Resept1 = newResept.Resept1;
            resept.Active = resept.Active;
            
            db.SaveChanges();

            return RedirectToAction("Resepts");
        }





        public IActionResult DeleteResept(int id)
        {
            var resept = db.Resepts.Where(r => r.ReseptId == id && r.Deleted == false).First();
            resept.Deleted = true;
            db.SaveChanges();

            return RedirectToAction("Resepts");
        }



        public IActionResult Comments()
        {
            var comments = db.Comments.Include(r=>r.ReseptNavigation).Include(u=>u.User).Where(c => c.Deleted == false).ToList();

            return View(comments);
        }

        [HttpPost]
        public IActionResult Comments(string typeofList)
        {
            var comments = db.Comments.Include(r => r.ReseptNavigation).Include(u => u.User).Where(c => c.Deleted == false && c.Active == true).ToList();

            switch (typeofList)
            {
                case "Hamısı": 
                    comments = db.Comments.Include(r => r.ReseptNavigation).Include(u => u.User).Where(c => c.Deleted == false).ToList();
                    break;
                case "Təsdiqlənmiş":
                    comments = db.Comments.Include(r => r.ReseptNavigation).Include(u => u.User).Where(c => c.Deleted == false && c.Active == true).ToList();
                    break;
                case "Təsdiqlənməmiş":
                    comments = db.Comments.Include(r => r.ReseptNavigation).Include(u => u.User).Where(c => c.Deleted == false && c.Active == false).ToList();
                    break;


            }

            

            return View(comments);
        }

        public IActionResult Confirm(int id)
        {
            var comment = db.Comments.Include(r => r.ReseptNavigation).Include(u => u.User).Where(c => c.Deleted == false && c.CommentId == id).First();
            comment.Active = true;
            db.SaveChanges();

            return RedirectToAction("Comments");
        }

        public IActionResult DeleteConfirm(int id)
        {
            var comment = db.Comments.Include(r => r.ReseptNavigation).Include(u => u.User).Where(c => c.Deleted == false && c.CommentId == id).First();
            comment.Active = false;
            db.SaveChanges();

            return RedirectToAction("Comments");
        }



        public IActionResult Users()
        {
            var users = db.Users.Where(u => u.Deleted == false && u.Active == true).ToList();

            return View(users);
        }


        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User u)
        {
            //string encryptedPassword = MD5Sifrele(u.Userpassword);
            //u.Userpassword = encryptedPassword;
            u.Deleted = false;
            db.Users.Add(u);
            db.SaveChanges();

            return RedirectToAction("Users");
        }

        public IActionResult GetUser(int id)
        {
            var user = db.Users.Where(u => u.UserId == id && u.Deleted == false).First();

            return View(user);
        }

        public IActionResult UpdateUser(User newUser)
        {
            var user = db.Users.Where(u => u.UserId == newUser.UserId && u.Deleted == false).First();
            user.Active = newUser.Active;
            user.Authority = newUser.Authority;
            db.SaveChanges();

            return RedirectToAction("Users");
        }




        public IActionResult Info()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            return View();
        }

        
        public IActionResult Test()
        {
            return View();
        }

    }
}

