using Microsoft.AspNet.Identity;
using phonebook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace phonebook.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index(string id)
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            //AspNetUser obj = new AspNetUser();
            List<PersonViewModel> list = new List<PersonViewModel>();
            var asp = db.AspNetUsers.ToList();
            foreach (var a in asp)
           {
              if (a.Id == id)
               {
                    var v = db.People.ToList();
                    foreach (var i in v)
                    {
                        if (a.Id == i.AddedBy)
                        {
                            PersonViewModel p = new PersonViewModel();
                            p.PersonId = i.PersonId;
                            p.FirstName = i.FirstName;
                            p.MiddleName = i.MiddleName;
                            p.LastName = i.LastName;
                            p.DateOfBirth = i.DateOfBirth;
                            p.AddedOn = i.AddedOn;
                            p.AddedBy = User.Identity.GetUserId();
                            p.HomeAddress = i.HomeAddress;
                            p.HomeCity = i.HomeCity;
                            p.FaceBookAccountId = i.FaceBookAccountId;
                            p.LinkedInId = i.LinkedInId;
                            p.UpdateOn = i.UpdateOn;
                            p.ImagePath = i.ImagePath;
                            p.TwitterId = i.TwitterId;
                            p.EmailId = i.EmailId;
                            list.Add(p);
                        }
                    }
              }
            }

            return View(list);
        }
        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            Person p = db.People.Find(id);
            PersonViewModel a = new PersonViewModel();
          //  a.PersonId = p.PersonId;
            a.FirstName = p.FirstName;
            a.MiddleName = p.MiddleName;
            a.LastName = p.LastName;
            a.DateOfBirth = p.DateOfBirth;
            a.AddedOn = p.AddedOn;
            a.AddedBy = p.AddedBy;
            a.HomeAddress = p.HomeAddress;
            a.HomeCity = p.HomeCity;
            a.FaceBookAccountId = p.FaceBookAccountId;
            a.TwitterId = p.TwitterId;
            a.UpdateOn = p.UpdateOn;
            a.ImagePath = p.ImagePath;
            a.LinkedInId = p.LinkedInId;
            a.EmailId = p.EmailId;

            return View(a);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(PersonViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                Person p = new Person();
                p.PersonId = collection.PersonId;
                p.FirstName = collection.FirstName;
                p.MiddleName = collection.MiddleName;
                p.LastName = collection.LastName;
                p.DateOfBirth = collection.DateOfBirth;
                p.AddedOn = DateTime.Now.Date;
                p.AddedBy = User.Identity.GetUserId();
                p.HomeAddress = collection.HomeAddress;
                p.HomeCity = collection.HomeCity;
                p.FaceBookAccountId = collection.FaceBookAccountId;
                p.LinkedInId = collection.LinkedInId;
                p.UpdateOn = DateTime.Now.Date;
                p.ImagePath = collection.ImagePath;
                p.TwitterId = collection.TwitterId;
                p.EmailId = collection.EmailId;
                db.People.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = User.Identity.GetUserId() });
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            PersonViewModel a = new PersonViewModel();
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            Person p = db.People.Find(id);
            a.PersonId = p.PersonId;
            a.FirstName = p.FirstName;
            a.MiddleName = p.MiddleName;
            a.LastName = p.LastName;
            a.DateOfBirth = p.DateOfBirth;
            a.AddedOn = p.AddedOn;
            a.AddedBy = p.AddedBy;
            a.HomeAddress = p.HomeAddress;
            a.HomeCity = p.HomeCity;
            a.FaceBookAccountId = p.FaceBookAccountId;
            a.TwitterId = p.TwitterId;
            a.UpdateOn = p.UpdateOn;
            a.ImagePath = p.ImagePath;
            a.LinkedInId = p.LinkedInId;
            a.EmailId = p.EmailId;


            return View(a);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PersonViewModel p)
        {
         PhoneBookDbEntities db = new PhoneBookDbEntities();
            if (ModelState.IsValid)
            {
                Person a = db.People.Find(id);
                a.PersonId = p.PersonId;
                a.FirstName = p.FirstName;
                a.MiddleName = p.MiddleName;
                a.LastName = p.LastName;
                a.DateOfBirth = p.DateOfBirth;
                a.AddedOn = p.AddedOn;
                a.AddedBy = p.AddedBy;
                a.HomeAddress = p.HomeAddress;
                a.HomeCity = p.HomeCity;
                a.FaceBookAccountId = p.FaceBookAccountId;
                a.TwitterId = p.TwitterId;
                a.UpdateOn = DateTime.Now.Date;
                a.ImagePath = p.ImagePath;
                a.LinkedInId = p.LinkedInId;
                a.EmailId = p.EmailId;

                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = User.Identity.GetUserId() });
            }
            ViewBag.AddedBy = new SelectList(db.AspNetUsers, "Id", "Email", p.AddedBy);
            return View(p);
        
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person p = db.People.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
           PersonViewModel a = new PersonViewModel();
            a.PersonId = p.PersonId;
            a.FirstName = p.FirstName;
            a.MiddleName = p.MiddleName;
            a.LastName = p.LastName;
            a.DateOfBirth = p.DateOfBirth;
            a.AddedOn = p.AddedOn;
            a.AddedBy = p.AddedBy;
            a.HomeAddress = p.HomeAddress;
            a.HomeCity = p.HomeCity;
            a.FaceBookAccountId = p.FaceBookAccountId;
            a.TwitterId = p.TwitterId;
            a.UpdateOn = p.UpdateOn;
            a.ImagePath = p.ImagePath;
            a.LinkedInId = p.LinkedInId;
            a.EmailId = p.EmailId;
            return View(a);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                Person p = db.People.Find(id);
                PersonViewModel a = new PersonViewModel();
                a.PersonId = p.PersonId;
                a.FirstName = p.FirstName;
                a.MiddleName = p.MiddleName;
                a.LastName = p.LastName;
                a.DateOfBirth = p.DateOfBirth;
                a.AddedOn = p.AddedOn;
                a.AddedBy = p.AddedBy;
                a.HomeAddress = p.HomeAddress;
                a.HomeCity = p.HomeCity;
                a.FaceBookAccountId = p.FaceBookAccountId;
                a.TwitterId = p.TwitterId;
                a.UpdateOn = p.UpdateOn;
                a.ImagePath = p.ImagePath;
                a.LinkedInId = p.LinkedInId;
                a.EmailId = p.EmailId;
                db.People.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = User.Identity.GetUserId() });
            }
            catch
            {
                return View();
            }
        }


       


    }
}
