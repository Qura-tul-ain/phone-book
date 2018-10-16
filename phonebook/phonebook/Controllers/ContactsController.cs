using phonebook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace phonebook.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contacts
        public ActionResult Index(int? id)
        {
           PhoneBookDbEntities db = new PhoneBookDbEntities();
            List<ContactsViewModel> list = new List<ContactsViewModel>();
            var c = db.People.ToList();
            foreach (var g in c)
            {
                if (g.PersonId == id)
                {
                    var contact = db.Contacts.ToList();
                    foreach (var i in contact)
                    {
                        if (i.PersonId == g.PersonId)
                        {
                            ContactsViewModel cont = new ContactsViewModel();
                            cont.ContactId = i.ContactId;
                            cont.ContactNumber = i.ContactNumber;
                            cont.PersonId = i.PersonId;
                            cont.Type = i.Type;
                            list.Add(cont);
                        }
                    }
                }
            }
            return View(list);
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            ContactsViewModel c = new ContactsViewModel();
            Contact obj = db.Contacts.Find(id);
            c.ContactId = obj.ContactId;
            c.ContactNumber = obj.ContactNumber;
            c.Type = obj.Type;
            c.PersonId = obj.PersonId;
            return View(c);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        public ActionResult Create(int id,ContactsViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                Contact c = new Contact();
                c.ContactId = collection.ContactId;
                c.ContactNumber = collection.ContactNumber;
                c.Type = collection.Type;
                c.PersonId = id;
                db.Contacts.Add(c);
                db.SaveChanges();
                ViewBag.id = c.PersonId;// sendng id , to use for create page 
                return RedirectToAction("Index",new { id =c.PersonId});
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int id)
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();

            ContactsViewModel c = new ContactsViewModel();
            Contact cont = db.Contacts.Find(id);
            c.ContactId = cont.ContactId;
            c.ContactNumber = cont.ContactNumber;
            c.Type = cont.Type;
            c.PersonId = cont.PersonId;
            return View(c);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ContactsViewModel cont)
        {
           
             // TODO: Add update logic here
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                if (ModelState.IsValid)
                {
                    Contact c = db.Contacts.Find(id);
                    c.ContactId = cont.ContactId;
                    c.ContactNumber = cont.ContactNumber;
                    c.Type = cont.Type;
                    c.PersonId = cont.PersonId;
                    db.Entry(c).State = EntityState.Modified;
                    db.SaveChanges();
                return RedirectToAction("Index", new { id = c.PersonId });
              
                }
           // ViewBag.AddedBy = new SelectList(db.AspNetUsers, "Id", "Email", cont.AddedBy);
            return View(cont);
        
           
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            ContactsViewModel c = new ContactsViewModel();
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            Contact collection = db.Contacts.Find(id);
            c.ContactId = collection.ContactId;
            c.ContactNumber = collection.ContactNumber;
            c.Type = collection.Type;
            c.PersonId = collection.PersonId;
            return View(c);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Deleteconfirmed(int id)
        { //id=contactId
            try
            {
                // TODO: Add delete logic here
                ContactsViewModel c = new ContactsViewModel();
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                Contact collection = db.Contacts.Find(id);
                c.ContactId = collection.ContactId;
                c.ContactNumber = collection.ContactNumber;
                c.Type = collection.Type;
                c.PersonId = collection.PersonId;
                db.Contacts.Remove(collection);
                db.SaveChanges();

                return RedirectToAction("Index",new { id=collection.PersonId});
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
