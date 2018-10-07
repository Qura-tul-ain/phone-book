using phonebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace phonebook.Controllers
{
    public class personController : Controller
    {
        // GET: person
        public ActionResult Index()
        {
            return View();
        }

        // GET: person/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: person/Create
        [HttpPost]
        public ActionResult Create(PersonViewModel collection)
        {
            // try
            if (collection!=null)
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
                p.AddedBy = "cdd";
                p.HomeAddress = collection.HomeAddress;
                p.HomeCity = collection.HomeCity;
                p.FaceBookAccountId = collection.FaceBookAccountId;
                p.LinkedInId = collection.LinkedInId;
                p.TwitterId = collection.TwitterId;
                p.EmailId = collection.EmailId;

                db.People.Add(p);
                // db.SaveChanges();


                return RedirectToAction("Index");
            }
                // 

            //}
            
                return View(collection);
           
        



           // catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
           // {
           //     Exception raise = dbEx;
           //     foreach (var validationErrors in dbEx.EntityValidationErrors)
           //     {
           //         foreach (var validationError in validationErrors.ValidationErrors)
           //         {
           //             string message = string.Format("{0}:{1}",
           //                 validationErrors.Entry.Entity.ToString(),
           //                 validationError.ErrorMessage);
           //             // raise a new exception nesting  
           //             // the current instance as InnerException  
           //             raise = new InvalidOperationException(message, raise);
           //         }
           //     }
           //     throw raise;
              

           // }
           //// return View(PersonViewModel);

        }
        // GET: person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
