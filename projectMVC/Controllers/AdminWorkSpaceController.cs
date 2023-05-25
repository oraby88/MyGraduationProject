using projectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectMVC.Controllers
{
    public class AdminWorkSpaceController : Controller
    {
        // GET: AdminWorkSpace
  
        private projectDbContext con = new projectDbContext();
        private Admin AdminOfCoffie;
        // GET: AdminCoffie
        public ActionResult Index()
        {
            if (Session["UserNameAdmin"] == null || Session["PasswordAdmin"] == null || Session["CodeAdmin"] == null)
            {
                return RedirectToAction("LoginAdmin", "HomePage");
            }
     
            //AdminOfCoffie = con.Admines.Where(a => a.AdminUserName == Session["UserNameAdmin"].ToString() && a.AdminPassword == Session["PasswordAdmin"].ToString() && a.Code == Session["CodeAdmin"].ToString()).First();
            return View();
        }
        public ActionResult Employ()
        {
            return RedirectToAction("Index", "Employ");
        }

        public ActionResult Drinks()
        {
            return RedirectToAction("Index", "Drink");

        }
        public ActionResult Casher()
        {
             return RedirectToAction("Index", "Casher");
        }
        public ActionResult Seet()
        {
            return RedirectToAction("Index", "Seet");

        }



    }
}