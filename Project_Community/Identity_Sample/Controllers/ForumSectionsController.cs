using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Identity_Sample.Models;

namespace Identity_Sample.Controllers
{
    public class ForumSectionsController : Controller
    {
        private ForumContext db = new ForumContext();

        // GET: ForumSections
        public ActionResult Index()
        {
            return View(db.ForumSections.ToList());
        }

        // GET: ForumSections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumSection forumSection = db.ForumSections.Find(id);
            if (forumSection == null)
            {
                return HttpNotFound();
            }
            return View(forumSection);
        }

        // GET: ForumSections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ForumSections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,addedBy")] ForumSection forumSection)
        {
            if (ModelState.IsValid)
            {
                forumSection.addedBy = User.Identity.Name;
                db.ForumSections.Add(forumSection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(forumSection);
        }

        [HttpPost] //, ActionName("Details)")
        public ActionResult CreateThread([Bind(Include = "ID,ForumSectionID,Title,Text,Author")] ForumThread forumThread)
        {
            //Comment _cmt = new Comment();
            //db.ID = default(int);
            if (ModelState.IsValid)
            {
                forumThread.Author = User.Identity.Name;
                forumThread.PublishDate = DateTime.Now;
                db.ForumThreads.Add(forumThread);
                db.SaveChanges();
                return RedirectToAction("Details", "ForumSections", new { id = forumThread.ForumSectionID });
            }
            else
            {
                // Error page here
                return View("Details");
            }
        }

        // GET: ForumSections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumSection forumSection = db.ForumSections.Find(id);
            if (forumSection == null)
            {
                return HttpNotFound();
            }
            return View(forumSection);
        }

        // POST: ForumSections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,addedBy")] ForumSection forumSection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forumSection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "ForumSections");
            }
            return View(forumSection);
        }

        // GET: ForumSections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumSection forumSection = db.ForumSections.Find(id);
            if (forumSection == null)
            {
                return HttpNotFound();
            }
            return View(forumSection);
        }

        // POST: ForumSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ForumSection forumSection = db.ForumSections.Find(id);
            db.ForumSections.Remove(forumSection);
            db.SaveChanges();
            return RedirectToAction("Index", "ForumSections");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
