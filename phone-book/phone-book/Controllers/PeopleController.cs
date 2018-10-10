using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity.Owin;
using System.Net;
using System.Web;
using System.Web.Mvc;
using phone_book;
using Microsoft.AspNet.Identity;

namespace phone_book.Controllers
{
    public class PeopleController : Controller
    {
        private PhoneBookDbEntities db = new PhoneBookDbEntities();

        // GET: People
        public ActionResult Index()
        {
            var people = db.People.Include(p => p.AspNetUser);
            return View(people.ToList());
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            ViewBag.AddedBy = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]



       public ActionResult Create([Bind(Include = "PersonId,FirstName,MiddleName,LastName,DateOfBirth,AddedOn,AddedBy,HomeAddress,HomeCity,FaceBookAccountId,LinkedInId,UpdateOn,ImagePath,TwitterId,EmailId")] Person person)
        {
            person.UpdateOn = DateTime.Now.Date;
            person.AddedOn = DateTime.Now.Date;
    

            if (ModelState.IsValid)
            {
                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddedBy = new SelectList(db.AspNetUsers, "Id", "Email", person.AddedBy);
            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddedBy = new SelectList(db.AspNetUsers, "Id", "Email", person.AddedBy);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,FirstName,MiddleName,LastName,DateOfBirth,AddedOn,AddedBy,HomeAddress,HomeCity,FaceBookAccountId,LinkedInId,UpdateOn,ImagePath,TwitterId,EmailId")] Person person)
        {
            person.UpdateOn = DateTime.Now.Date;
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddedBy = new SelectList(db.AspNetUsers, "Id", "Email", person.AddedBy);
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.People.Find(id);
            db.People.Remove(person);
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
