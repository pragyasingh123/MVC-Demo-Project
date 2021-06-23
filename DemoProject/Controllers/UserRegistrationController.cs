using DemoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace DemoProject.Controllers
{
    public class UserRegistrationController : Controller
    {
        // GET: UserRegistration
        public ActionResult Index()
        {
            return View();
        }


       
        public ActionResult UserRegistration() {
            return View();
        }


        [HttpPost]
        public ActionResult UserRegistration(RegisteredUser userData) {

            Guid newId = Guid.NewGuid();
            userData.Id = newId;
          
          
            if (ModelState.IsValid) {

                ShoppingEntities shopping = new ShoppingEntities();
                shopping.RegisteredUsers.Add(userData);
                shopping.SaveChanges();
                Session["UserID"] = newId;

            }
            return RedirectToAction("UserRegistration");
        }

      
        [HttpPost]
        public JsonResult UserRegistrationFromAngular(RegisteredUser userData)
        {

            Guid newId = Guid.NewGuid();
            userData.Id = newId;


            if (ModelState.IsValid)
            {

                ShoppingEntities shopping = new ShoppingEntities();
                shopping.RegisteredUsers.Add(userData);
                shopping.SaveChanges();
                

            }
            return Json(new { data = "Ok" }, JsonRequestBehavior.AllowGet);
        }



        public ActionResult UserLoging() {

            return View();
        }

        [HttpPost]
        public ActionResult UserLoging(UserData data)
        {
            if (ModelState.IsValid) {

                using (ShoppingEntities entity = new ShoppingEntities()) {
                   var obj= entity.RegisteredUsers.Where(a => a.FirstName.Equals(data.UserName) && a.Password.Equals(data.UserPassword)).FirstOrDefault();
                    if (obj != null) {
                        Session["UserName"] = data.UserName;
                        ViewBag.UserDataID = obj.Id;
                        return RedirectToAction("UserDashboard");
                    }


                }

                Session["InvalidCredentials"] = true;
                return RedirectToAction("UserLoging");

            }

            return View();
        }


        public ActionResult UserDashboard() {

            ViewBag.UserName = ViewBag.UserDataID;
            return View();
            
        }


        
        public ActionResult ForgetPassword() {

            return View();

        }

        [HttpPost]
        public ActionResult ForgetPassword(ForgetPassword data)
        {
            if (data != null) {
                using (ShoppingEntities entity = new ShoppingEntities()) {
                  var obj=  entity.RegisteredUsers.Where(a => a.EmailId.Equals(data.UserEmailID)).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.Password = data.UserPassword;
                        entity.SaveChanges();
                        ViewBag.Message = true;
                    }
                    else {

                        ViewBag.ErrorMessage = true;
                    }
                }


            }
            return View();

        }


    }
}