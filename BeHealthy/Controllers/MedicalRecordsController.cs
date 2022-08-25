using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeHealthy.Models;

namespace BeHealthy.Controllers
{
    public class MedicalRecordsController : Controller
    {
        private BeHealthyEntities1 db = new BeHealthyEntities1();

        // GET: MedicalRecords
        public ActionResult Index()
        {
            Members member = Session["member"] as Members;
            ViewBag.MemberID = member.MemberID;
            ViewBag.MemberName = member.MemberName;
            //var medicalRecord = db.MedicalRecord.Include(m => m.Disorder).Include(m => m.Medecine).Include(m => m.Members);
            if (member.MemberID == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }  
            else {
                var medicalRecord = db.MedicalRecord.Where(m=>m.MemberID== member.MemberID).ToList();
                return View(medicalRecord);
            }
                
        }

        // GET: MedicalRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalRecord medicalRecord = db.MedicalRecord.Find(id);
            if (medicalRecord == null)
            {
                return HttpNotFound();
            }
            return View(medicalRecord);
        }

        // GET: MedicalRecords/Create
        public ActionResult Create()
        {
            ViewBag.DisorderID = new SelectList(db.Disorder, "DisorderID", "DietarySupplementID");
            ViewBag.MedecineID = new SelectList(db.Medecine, "MedecineID", "DisorderID");
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName");
            return View();
        }

        // POST: MedicalRecords/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedicalRecordID,MedecineID,DisorderID,MemberID,MedicalRecordDATE,DoctorID")] MedicalRecord medicalRecord)
        {
            if (ModelState.IsValid)
            {
                db.MedicalRecord.Add(medicalRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DisorderID = new SelectList(db.Disorder, "DisorderID", "DietarySupplementID", medicalRecord.DisorderID);
            ViewBag.MedecineID = new SelectList(db.Medecine, "MedecineID", "DisorderID", medicalRecord.MedecineID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", medicalRecord.MemberID);
            return View(medicalRecord);
        }

        // GET: MedicalRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalRecord medicalRecord = db.MedicalRecord.Find(id);
            if (medicalRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.DisorderID = new SelectList(db.Disorder, "DisorderID", "DietarySupplementID", medicalRecord.DisorderID);
            ViewBag.MedecineID = new SelectList(db.Medecine, "MedecineID", "DisorderID", medicalRecord.MedecineID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", medicalRecord.MemberID);
            return View(medicalRecord);
        }

        // POST: MedicalRecords/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedicalRecordID,MedecineID,DisorderID,MemberID,MedicalRecordDATE,DoctorID")] MedicalRecord medicalRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicalRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DisorderID = new SelectList(db.Disorder, "DisorderID", "DietarySupplementID", medicalRecord.DisorderID);
            ViewBag.MedecineID = new SelectList(db.Medecine, "MedecineID", "DisorderID", medicalRecord.MedecineID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", medicalRecord.MemberID);
            return View(medicalRecord);
        }

        // GET: MedicalRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalRecord medicalRecord = db.MedicalRecord.Find(id);
            if (medicalRecord == null)
            {
                return HttpNotFound();
            }
            return View(medicalRecord);
        }

        // POST: MedicalRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicalRecord medicalRecord = db.MedicalRecord.Find(id);
            db.MedicalRecord.Remove(medicalRecord);
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
