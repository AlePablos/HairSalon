﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Peluqueria3.Models;

namespace Peluqueria3.Controllers
{
    public class AppointmentsController : BaseController
    {
        // GET: Appointments
        public ActionResult Index()
        {
            var appointments = db.Appointments.Include(a => a.User);
            return View(appointments.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            var appointment = new Appointment();
            appointment.workItems = (from wi in db.WorkItems select wi).ToList();

            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,startTime,endTime,user,workItems")] AppointmentWithWorkItems appointmentWithWorkItem)
        {
            var appointment = new Appointment();

            if (ModelState.IsValid)
            {                
                appointment.startTime = appointmentWithWorkItem.startTime;                
                appointment.userID = currentUser.ID;

                int time = 0;
                appointment.workItems = new List<WorkItem>();
                foreach(var wid in appointmentWithWorkItem.workItems) {
                    appointment.workItems.Add(db.WorkItems.Find(wid));
                    time += appointment.workItems.LastOrDefault().duration;
                }

                appointment.endTime = appointment.startTime.AddMinutes(time);
                appointment.status = Status.Waiting;

                db.Appointments.Add(appointment);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.userID = new SelectList(db.Users, "ID", "firstName", appointment.userID);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,startTime,endTime,userID")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userID = new SelectList(db.Users, "ID", "firstName", appointment.userID);
            return View(appointment);
        }

        public ActionResult Update(int? id, Status status)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }

            appointment.status = status;
            db.Entry(appointment).State = EntityState.Modified;
            db.SaveChanges();

            return this.Index();
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
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

    public class AppointmentWithWorkItems
    {
        public int id { get; set; }

        public DateTime startTime { get; set; }

        public DateTime endTime { get; set; }

        public int user { get; set; }

        public List<int?> workItems { get; set; }
    }
}
