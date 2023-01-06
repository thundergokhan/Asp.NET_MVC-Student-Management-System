using Student_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication44.Controllers
{
    public class LoginController : Controller
    {

        Student_Management_SystemEntities db = new Student_Management_SystemEntities();


        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user objchk)
        {


            if (ModelState.IsValid)
            {
                using (Student_Management_SystemEntities db = new Student_Management_SystemEntities())
                {

                    var obj = db.users.Where(a => a.username.Equals(objchk.username) && a.password.Equals(objchk.password)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["UserID"] = obj.id.ToString();
                        Session["UserName"] = obj.username.ToString();
                        return RedirectToAction("Index", "Home");


                    }

                    else
                    {

                        ModelState.AddModelError("", "The UserName or Password Incorrect");



                    }


                }


            }

            return View(objchk);
        }


        public ActionResult Logout()
        {

            Session.Clear();
            return RedirectToAction("Index", "Login");



        }











    }
}