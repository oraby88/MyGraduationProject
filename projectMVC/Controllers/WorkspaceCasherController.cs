using projectMVC.Models;
using projectMVC.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectMVC.Controllers
{
    public class WorkspaceCasherController : Controller
    {
        // GET: WorkspaceCasher
        private projectDbContext con = new projectDbContext();
        public ActionResult Index()
        {
            //Session["UserNameCasher"] = data.CasherUserName;
            //Session["PasswordCasher"] = data.CasherPassword;

            //Session["Code"] = owner.Code;
            var code = Session["Code"].ToString();
            //  var data = con.Admines.Include(a => a.foodies).Include(a => a.Drinkies).Where(a => a.Code == code).ToList();
            var seets = con.Seets.Where(s => s.Code == code).ToList();
            var drinks = con.Drinkies.Where(d => d.Code == code).ToList();

            DrinksAndSeetCasher casherdata = new DrinksAndSeetCasher
            {
                Seets = seets,
                drinks = drinks
            };
            return View(casherdata);
        }
    }
}