using projectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace projectMVC.Controllers
{
    public class AdminCoffieController : Controller
    {
        private projectDbContext con = new projectDbContext();
        private Admin AdminOfCoffie;
        // GET: AdminCoffie
        public ActionResult Index()
        {
            if(Session["UserNameAdmin"]==null || Session["PasswordAdmin"] == null || Session["CodeAdmin"]==null)
            {
                return RedirectToAction("LoginAdmin", "HomePage");
            }

       
   
            return View();
        }
        public ActionResult Employ()
        {
          return  RedirectToAction("Index","Employ");
        }
        public ActionResult Drinks()
        {
            return RedirectToAction("Index", "Drink");

        }
        public ActionResult Foods()
        {
            return RedirectToAction("Index", "Food");

        }
        public ActionResult Casher()
        {
            return RedirectToAction("Index", "Casher");

        }




    }
}