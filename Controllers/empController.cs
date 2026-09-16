using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppMVCEntityF;

namespace WebAppMVCEntityF.Controllers
{
    public class empController : Controller
    {
        private EnMVC_DBEntities db = new EnMVC_DBEntities();

        // GET: emp
        public ActionResult Index()
        {
            return View(db.UserRegs.ToList());
        }

        // GET: emp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserReg userReg = db.UserRegs.Find(id);
            if (userReg == null)
            {
                return HttpNotFound();
            }
            return View(userReg);
        }

        // GET: emp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: emp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Age,Address,Email,Phone")] UserReg userReg)
        {
            if (ModelState.IsValid)
            {
                db.UserRegs.Add(userReg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userReg);
        }

        // GET: emp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserReg userReg = db.UserRegs.Find(id);
            if (userReg == null)
            {
                return HttpNotFound();
            }
            return View(userReg);
        }

        // POST: emp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Age,Address,Email,Phone")] UserReg userReg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userReg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userReg);
        }

        // GET: emp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserReg userReg = db.UserRegs.Find(id);
            if (userReg == null)
            {
                return HttpNotFound();
            }
            return View(userReg);
        }

        // POST: emp/Delete/5
        [HttpPost, ActionName("Delete")]//this is the main
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserReg userReg = db.UserRegs.Find(id);
            db.UserRegs.Remove(userReg);
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
