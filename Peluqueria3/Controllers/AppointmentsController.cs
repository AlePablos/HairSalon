using System;
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
    public class AppointmentsController : Controller
    {
        private HairSalonDBContext db = new HairSalonDBContext();

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
            var workItems = from am in db.Appointments_WorkItems
                            where am.appointmentID == appointment.ID
                            select am.WorkItem;

            ViewBag.workItemList = workItems;
            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            ViewBag.userID = new SelectList(db.Users, "ID", "firstName");
            var appointment = new Appointment();
           //appointment.ID = db.Appointments.LastOrDefault().ID + 1;
            appointment.workItems = (from wi in db.WorkItems
                                    select wi).ToList();

            return View(appointment);
        }

        //// POST: Appointments/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,startTime,endTime,userID")] Appointment appointment)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Appointments.Add(appointment);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.userID = new SelectList(db.Users, "ID", "firstName", appointment.userID);
        //    return View(appointment);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,startTime,endTime,user,workItems")] AppointmentWithWorkItems appointmentWithWorkItem)
        {
            var appointment = new Appointment();
            if (ModelState.IsValid)
            {                
                appointment.startTime = appointmentWithWorkItem.startTime;
                
                //TODO calculate endtime and userID
                appointment.endTime = appointmentWithWorkItem.startTime.AddHours(3);
                appointment.userID = 3;

                appointment.workItems = new List<WorkItem>();
                foreach(var wid in appointmentWithWorkItem.workItems) {
                    appointment.workItems.Add(db.WorkItems.Find(wid));
                }

                //db.Appointments.Add(appointment);
                //db.SaveChanges();

                //var appointmentId = (from a in db.Appointments.OrderByDescending(x => x.ID)
                //                     select a.ID).FirstOrDefault();

                //Appointment_WorkItem appointment_WorkItem = new Appointment_WorkItem();

                //foreach (var item in appointmentWithWorkItem.workItems)
                //{
                //    appointment_WorkItem.appointmentID = appointmentId;
                //    appointment_WorkItem.workItemID = (int) item;
                //    appointment_WorkItem.Appointment = GetAppointmentById(appointmentId);
                //    appointment_WorkItem.WorkItem = GetWorkItemById((int)item);
                //    db.Appointments_WorkItems.Add(appointment_WorkItem);
                //}

                db.Appointments.Add(appointment);
                db.SaveChanges();
            }

            return View(appointment);
        }

        private WorkItem GetWorkItemById(int id)
        {
            var result = (from wi in db.WorkItems
                          where wi.ID == id
                          select wi).ToList().FirstOrDefault();

            return result;            
        }

        private Appointment GetAppointmentById(int id)
        {
            var result = (from a in db.Appointments
                          where a.ID == id
                          select a).ToList().FirstOrDefault();

            return result;
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
}
