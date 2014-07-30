using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebScheduler.Models;
using WebScheduler.Filters;

namespace WebScheduler.Controllers
{
    [InitializeLocaleManager]
    public class ContactsController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Contacts/

        public ActionResult Index()
        {
            var contacts = db.Contacts.Include(c => c.UserData).Include(c => c.NotRegisteredContacts);
            return View(contacts.ToList());
        }

        //
        // GET: /Contacts/Details/5

        public ActionResult Details(int id = 0)
        {
            Contacts contacts = db.Contacts.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }

        //
        // GET: /Contacts/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserData, "UserId", "Name");
            ViewBag.Id = new SelectList(db.NotRegisteredContacts, "Id", "Name");
            return View();
        }

        //
        // POST: /Contacts/Create

        [HttpPost]
        public ActionResult Create(Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contacts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserData, "UserId", "Name", contacts.UserId);
            ViewBag.Id = new SelectList(db.NotRegisteredContacts, "Id", "Name", contacts.Id);
            return View(contacts);
        }

        //
        // GET: /Contacts/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Contacts contacts = db.Contacts.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserData, "UserId", "Name", contacts.UserId);
            ViewBag.Id = new SelectList(db.NotRegisteredContacts, "Id", "Name", contacts.Id);
            return View(contacts);
        }

        //
        // POST: /Contacts/Edit/5

        [HttpPost]
        public ActionResult Edit(Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contacts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserData, "UserId", "Name", contacts.UserId);
            ViewBag.Id = new SelectList(db.NotRegisteredContacts, "Id", "Name", contacts.Id);
            return View(contacts);
        }

        //
        // GET: /Contacts/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Contacts contacts = db.Contacts.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }

        //
        // POST: /Contacts/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Contacts contacts = db.Contacts.Find(id);
            db.Contacts.Remove(contacts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}