using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_Main.Models;

namespace Project_Main.Controllers
{
    public class ForumThreadsController : Controller
    {
        private ForumContext db = new ForumContext();

        // GET: ForumThreads
        public ActionResult Index()
        {
            return View(db.ForumThreads.ToList());
        }

        // GET: ForumThreads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumThread forumThread = db.ForumThreads.Find(id);
            if (forumThread == null)
            {
                return HttpNotFound();
            }

            ViewBag.SecTitle = db.ForumSections.Find(forumThread.ForumSectionID).Title;

            return View(forumThread);
        }

        // GET: ForumThreads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ForumThreads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ForumSectionID,Title,Text")] ForumThread forumThread)
        {
            if (ModelState.IsValid)
            {
                //forumThread.ForumSectionID = forumThread.ForumSectionID;
                forumThread.Author = User.Identity.Name;
                forumThread.PublishDate = DateTime.Now;
                db.ForumThreads.Add(forumThread);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(forumThread);
        }

        [HttpPost] //, ActionName("Details)")
        public ActionResult CreateThreadPost([Bind(Include = "ID,ForumThreadID,Text,Author")] ForumPost forumPost)
        {
            //Comment _cmt = new Comment();
            //db.ID = default(int);
            if (ModelState.IsValid)
            {
                forumPost.Author = User.Identity.Name;
                forumPost.PublishDate = DateTime.Now;
                db.ForumPosts.Add(forumPost);
                db.SaveChanges();
                return RedirectToAction("Details", "ForumThreads", new { id = forumPost.ForumThreadID });
            }
            else
            {
                // Error page here
                return View("Details");
            }
        }

        // GET: ForumThreads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumThread forumThread = db.ForumThreads.Find(id);
            if (forumThread == null)
            {
                return HttpNotFound();
            }
            return View(forumThread);
        }

        // POST: ForumThreads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ForumSectionID,Title,Text,PublishDate,Author")] ForumThread forumThread)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forumThread).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "ForumSections", new { id = forumThread.ForumSectionID });
            }
            return View(forumThread);
        }

        // GET: ForumThreads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumThread forumThread = db.ForumThreads.Find(id);
            if (forumThread == null)
            {
                return HttpNotFound();
            }
            return View(forumThread);
        }

        // POST: ForumThreads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ForumThread forumThread = db.ForumThreads.Find(id);
            db.ForumThreads.Remove(forumThread);
            db.SaveChanges();
            return RedirectToAction("Details", "ForumSections", new { id = forumThread.ForumSectionID });
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
