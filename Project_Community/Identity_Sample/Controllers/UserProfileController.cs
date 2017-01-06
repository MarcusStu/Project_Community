using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Identity_Sample.Models;
using System.Net;
using System.Data.Entity;

namespace Identity_Sample.Controllers
{
    public class UserProfileController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();

        public UserProfileController()
        {
        }

        public UserProfileController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: UserProfile
        public ActionResult Index()
        {
            var Id = User.Identity.GetUserId();
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser appUser = db.Users.Find(Id);

            if (appUser == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UserInfo = db.Users.Find().Title;

            return View(appUser);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var Id = User.Identity.GetUserId();
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser appUserEdit = db.Users.Find(Id);
            if (appUserEdit == null)
            {
                return HttpNotFound();
            }
            return View("Edit", appUserEdit);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Firstname,Lastname,City,Country,Age,Email,MemberSince,PasswordHash")] ApplicationUser appUserEdit)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(appUserEdit).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(appUserEdit);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Firstname,Lastname,City,Country,Age,Email,MemberSince,PasswordHash,UserName")] ApplicationUser appUserEdit)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser u = UserManager.FindById(appUserEdit.Id);
                u.UserName = appUserEdit.UserName;
                u.Email = appUserEdit.Email;
                u.FirstName = appUserEdit.FirstName;
                u.LastName = appUserEdit.LastName;
                u.Age = appUserEdit.Age;
                u.City = appUserEdit.City;
                u.Country = appUserEdit.Country;
                UserManager.Update(u);
                db.SaveChanges();
                return RedirectToAction("Index");

                //db.Entry(appUserEdit).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return View(appUserEdit);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }
    }
}