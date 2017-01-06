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
    public class NewsPostsController : Controller
    {
        public NewsContext db = new NewsContext();

        // GET: NewsPosts
        public ActionResult Index()
        {
            return View(db.NewsPosts.ToList());
        }

        // GET: NewsPosts/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsPost newsPost = db.NewsPosts.Find(id);
            if (newsPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserName = User.Identity.Name;
            return View(newsPost);
        }

        [HttpPost] //, ActionName("Details)")
        public ActionResult detailsPost([Bind(Include = "ID,NewsPostID,Title,Text,Author")] Comment cmt)
        {
            //Comment _cmt = new Comment();
            //db.ID = default(int);
            if (ModelState.IsValid)
            {
                cmt.Author = User.Identity.Name;
                cmt.PublishDate = DateTime.Now;
                db.Comments.Add(cmt);
                db.SaveChanges();
                return RedirectToAction("Details", "NewsPosts", new { id = cmt.NewsPostID });
            }
            else
            {
                // Error page here
                return View("Details");
            }
        }

        // GET: NewsPosts/Create
        public ActionResult Create()
        {
            ViewBag.UserName = User.Identity.Name;
            return View();
        }

        // POST: NewsPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Text,Author")] NewsPost newsPost)
        {
            if (ModelState.IsValid)
            {
                newsPost.Author = User.Identity.Name;
                newsPost.PublishDate = DateTime.Now;
                db.NewsPosts.Add(newsPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsPost);
        }

        // GET: NewsPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsPost newsPost = db.NewsPosts.Find(id);
            if (newsPost == null)
            {
                return HttpNotFound();
            }
            return View(newsPost);
        }

        // POST: NewsPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Text,PublishDate,Author")] NewsPost newsPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsPost);
        }

        // GET: NewsPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsPost newsPost = db.NewsPosts.Find(id);
            if (newsPost == null)
            {
                return HttpNotFound();
            }
            return View(newsPost);
        }

        // POST: NewsPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsPost newsPost = db.NewsPosts.Find(id);
            db.NewsPosts.Remove(newsPost);
            db.SaveChanges();
            return RedirectToAction("Index");
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
