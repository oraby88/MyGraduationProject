﻿using projectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projectMVC.viewModel;
using System.Data.Entity;

namespace projectMVC.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        private projectDbContext con = new projectDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterAdmin rAdmin )
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            Admin Admin = new Admin
            {
                AdminUserName = rAdmin.AdminUserName,
                AdminPassword = rAdmin.AdminPassword,
                Code = rAdmin.Code,
                
                BussinesType =rAdmin.BussinesType
            };
            con.Admines.Add(Admin);
            con.SaveChanges();

            var adminFomDb = con.Admines.SingleOrDefault(a => a.AdminUserName == Admin.AdminUserName);
            Session["UserNameAdmin"] = adminFomDb.AdminUserName;
            Session["PasswordAdmin"] = adminFomDb.AdminPassword;
            Session["CodeAdmin"] = adminFomDb.Code;
            if (adminFomDb.BussinesType == enums.BussinessType.Coffie)
            {
                return RedirectToAction("Index", "AdminCoffie");
            }
            else if (adminFomDb.BussinesType == enums.BussinessType.WorkSpace)
            {
                return RedirectToAction("Index", "AdminWorkSpace");

            }
            else
            {
                return View();
            }


           // return Content($"{adminFomDb.AdminUserName } and {adminFomDb.AdminPassword} and {Admin.BussinesType} ");
        }
        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAdmin(LoginAdmin  ladmin)
        {

            if(!ModelState.IsValid)
            {
                return View();
            }
            var data = con.Admines.
                Where(x => x.AdminUserName == ladmin.AdminUserName && x.AdminPassword == ladmin.AdminPassword && x.Code == ladmin.Code).FirstOrDefault();
            if(data == null)
            {
                return View();
            }
            Session["UserNameAdmin"] = data.AdminUserName;
            Session["PasswordAdmin"] = data.AdminPassword;
            Session["CodeAdmin"] = data.Code;
            if (data.BussinesType == enums.BussinessType.Coffie)
            {
                return RedirectToAction("Index", "AdminCoffie");
            }
            else if(data.BussinesType == enums.BussinessType.WorkSpace)
            {
                return RedirectToAction("Index", "AdminWorkSpace");

            }
            else
            {
                return View();
            }
            // return Content($"{data.BussinesType} \n {data.AdminUserName } \n {data.CasherUserName}");
        }
        public ActionResult LoginUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginUser(LoginUser luser)
        {
           
                        if (!ModelState.IsValid)
                        {
                            return View();
                        }
            var data = con.Cashers
                .Where(c=> c.CasherUserName == luser.CasherUserName && c.CasherPassword == luser.CasherPassword).SingleOrDefault();

                            
                        if (data == null)
                        {
                            return View();
                        }
                         var owner = con.Admines.SingleOrDefault(a => a.Id == data.Admin_Id);
                        Session["UserNameCasher"] = data.CasherUserName;
                        Session["PasswordCasher"] = data.CasherPassword;

                        Session["Code"] = owner.Code;



            if (owner.BussinesType == enums.BussinessType.Coffie)
            {
                return RedirectToAction("Index", "CoffieCasher");
            }
            else if (owner.BussinesType == enums.BussinessType.WorkSpace)
            {
                return RedirectToAction("Index", "WorkspaceCasher");

            }
            else
            {
                return View();
            }


                  
         
        }     
    }
}