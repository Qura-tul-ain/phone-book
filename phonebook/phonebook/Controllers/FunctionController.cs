using phonebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace phonebook.Controllers
{
    public class FunctionController : Controller
    {
        // GET: Function
        public ActionResult Index(string id)
        {

            var d = new details();
            var total = new List<details>();
            int count = 0;
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            Person obj = new Person();
            var list = db.AspNetUsers.ToList();
            foreach (var i in list)
            {
                if (i.Id == id)
                {
                    var l = db.People.ToList();
                    foreach (var a in l)
                    {
                        if (a.AddedBy == i.Id)
                        {
                            count++;
                        }
                    }
                }
            }
            d.PersonAdded = count;

            // for next 10 dayss
            AspNetUser u = db.AspNetUsers.Find(id);
            //Person bdp = db.People.Find(id);
            var plist = db.People.ToList();
            DateTime date = DateTime.Today.AddDays(3);
            DateTime date1 = DateTime.Today.AddDays(7);
            DateTime date2 = DateTime.Today.AddDays(1);
            DateTime date3 = DateTime.Today.AddDays(2);
            DateTime date4 = DateTime.Today.AddDays(4);
            DateTime date5 = DateTime.Today.AddDays(5);
            DateTime date6 = DateTime.Today.AddDays(6);
            DateTime date7 = DateTime.Today.AddDays(7);
            DateTime date8 = DateTime.Today.AddDays(8);
            DateTime date9 = DateTime.Today.AddDays(9);
            d.totalname = new List<lists>();
           
            foreach (var i in plist)
            {
                if (i.AddedBy == u.Id)
                {

                    DateTime dob = Convert.ToDateTime(i.DateOfBirth);// dob=date of birth
                    if (dob.Day == date.Day && dob.Month == date.Month || dob.Day == date1.Day && dob.Month == date1.Month || dob.Day == date2.Day && dob.Month == date2.Month || dob.Day == date3.Day && dob.Month == date3.Month
                        || dob.Day == date4.Day && dob.Month == date4.Month || dob.Day == date5.Day && dob.Month == date5.Month || dob.Day == date6.Day && dob.Month == date6.Month || dob.Day == date7.Day && dob.Month == date7.Month
                        || dob.Day == date8.Day && dob.Month == date8.Month || dob.Day == date9.Day && dob.Month == date9.Month)
                  {

                        d.totalname.Add(new lists() { name1 = i.FirstName});
                        

                  }

                }

            }


            // for prevoius 7 days..

            DateTime date11 = DateTime.Today.AddDays(-1);
            DateTime date12 = DateTime.Today.AddDays(-2);
            DateTime date13 = DateTime.Today.AddDays(-3);
            DateTime date14 = DateTime.Today.AddDays(-4);
            DateTime date15= DateTime.Today.AddDays(-5);
            DateTime date16 = DateTime.Today.AddDays(-6);
            DateTime date17 = DateTime.Today.AddDays(-7);
            d.totalpersons = new List<listsofpersons>();

            foreach (var i in plist)
            {
                if (i.AddedBy == u.Id)
                {
                    DateTime dou = Convert.ToDateTime(i.UpdateOn);// dou =date of update
                    if(dou.Day == date11.Day && dou.Month == date11.Month || dou.Day == date12.Day && dou.Month == date12.Month || dou.Day == date13.Day && dou.Month == date13.Month || dou.Day == date14.Day && dou.Month == date14.Month ||
                        dou.Day == date15.Day && dou.Month == date15.Month || dou.Day == date16.Day && dou.Month == date16.Month || dou.Day == date17.Day && dou.Month == date17.Month )
                    {
                        d.totalpersons.Add(new listsofpersons() { name3 = i.FirstName });
                    }


                }
            }



                    return View(d);
        
    }

        // GET: Function/Details/5
        public ActionResult Details(int id)
        {


            return View();
        }

        // GET: Function/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Function/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Function/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Function/Edit/5
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

        // GET: Function/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Function/Delete/5
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
