using projectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projectMVC.viewModel;
using System.Data.Entity;

namespace projectMVC.Controllers
{
    public class CoffieCasherController : Controller
    {
        // GET: CoffieCasher

        private projectDbContext con = new projectDbContext();
        public ActionResult Index()
        {
            //Session["UserNameCasher"] = data.CasherUserName;
            //Session["PasswordCasher"] = data.CasherPassword;

            //Session["Code"] = owner.Code;
            var code = Session["Code"].ToString();
          //  var data = con.Admines.Include(a => a.foodies).Include(a => a.Drinkies).Where(a => a.Code == code).ToList();
            var foods = con.Foodies.Where(f => f.Code == code).ToList();
            var drinks = con.Drinkies.Where(d => d.Code == code).ToList();

            FoodAndDrinksCasher casherdata = new FoodAndDrinksCasher
            {
                foods = foods,
                drinks = drinks
            };
            return View(casherdata);
        }
    }
}