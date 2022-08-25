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
    public class ChiefComplaintsController : Controller
    {
        private BeHealthyEntities1 db = new BeHealthyEntities1();

        // GET: ChiefComplaints
        public ActionResult MemberChiefComplaintsIndex()
        {
            Members member = Session["member"] as Members;
            ViewBag.MemberID = member.MemberID;
            ViewBag.MemberName = member.MemberName;
            //var medicalRecord = db.MedicalRecord.Include(m => m.Disorder).Include(m => m.Medecine).Include(m => m.Members);
            if (member.MemberID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var chiefComplaints = db.ChiefComplaints.Where(m => m.MemberID == member.MemberID).ToList();
                return View(chiefComplaints);
            }
        }

        public ActionResult Index()
        {
            Doctors doctor = Session["doctor"] as Doctors;
            ViewBag.DoctorID = doctor.DoctorID;
            ViewBag.DoctorName = doctor.DoctorNAME;
            if (doctor.DoctorID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                //List <ChiefComplaints> chiefComplaints = db.ChiefComplaints.Where(m => m.DoctorID == doctor.DoctorID).ToList();
               var chiefComplaints = db.ChiefComplaints.Where(m => m.DoctorID == doctor.DoctorID).ToList();  //上面那一行也可以這樣寫
                return View(chiefComplaints);
            }
            //return View(db.ChiefComplaints.ToList());

        }

        public ActionResult Reply()
        {
            Doctors doctor = Session["doctor"] as Doctors;
            ViewBag.DoctorID = doctor.DoctorID;
            ViewBag.DoctorName = doctor.DoctorNAME;
            if (doctor.DoctorID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                //List <ChiefComplaints> chiefComplaints = db.ChiefComplaints.Where(m => m.DoctorID == doctor.DoctorID).ToList();
                var chiefComplaints = db.ChiefComplaints.Where(m => m.DoctorID == doctor.DoctorID &&  m.Details==null).ToList();  //上面那一行也可以這樣寫
                return View(chiefComplaints);
            }
            //return View(db.ChiefComplaints.ToList());

        }

        // GET: ChiefComplaints/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiefComplaints chiefComplaints = db.ChiefComplaints.Find(id);
            if (chiefComplaints == null)
            {
                return HttpNotFound();
            }
            return View(chiefComplaints);
        }
            

        // GET: ChiefComplaints/Create
        public ActionResult Create()
        {
           Members member = Session["member"] as Members;  //因為在MemberHomeController中，一登入就有把use塞進session[member]
            //chiefComplaints.MemberID = member.MemberID;
            ViewBag.MemberID=member.MemberID;

            return View();
        }

        // POST: ChiefComplaints/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChiefComplaints chiefComplaints)
        //public ActionResult Create([Bind(Include = "MemberID,ChiefComplaintsID,SymptomID,ChiefComplaintsDATE,DoctorORDER,DoctorID,DietitianORDER,DietitianID,Details")] ChiefComplaints chiefComplaints)
        {
            Members member = Session["member"] as Members;
            var chief = chiefComplaints.ChiefComplaintsDATE;
            if (ModelState.IsValid)
            {
                
                db.ChiefComplaints.Add(chiefComplaints);
                db.SaveChanges();
                return RedirectToAction("Index","MedicalRecords");
            }
            ViewBag.MemberID = member.MemberID;
            return View(chiefComplaints);
        }

        // GET: ChiefComplaints/Edit/5
        public ActionResult Edit(int? id)
        {
           
            if ( id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiefComplaints chiefComplaints = db.ChiefComplaints.Find(id);
            //var chiefComplaints = db.ChiefComplaints.Where(m => m.DoctorID == doctor.DoctorID).ToList();
            if (chiefComplaints == null)
                {
                    return HttpNotFound();
                }
                return View(chiefComplaints);
                
 
            //return View(chiefComplaints);
        }



        // POST: ChiefComplaints/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( ChiefComplaints chiefComplaints)
        //public ActionResult Edit([Bind(Include = "ChiefComplaintsID,SymptomID,ChiefComplaintsDATE,DoctorORDER,DoctorID,DietitianORDER,DietitianID,Details")] ChiefComplaints chiefComplaints)
        {
            //Members member = Session["member"] as Members;
            //chiefComplaints.MemberID = member.MemberID;
            if (ModelState.IsValid)
            {
                db.Entry(chiefComplaints).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
                
            return View(chiefComplaints);
        }

        // GET: ChiefComplaints/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiefComplaints chiefComplaints = db.ChiefComplaints.Find(id);
            if (chiefComplaints == null)
            {
                return HttpNotFound();
            }
            return View(chiefComplaints);
        }

        // POST: ChiefComplaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiefComplaints chiefComplaints = db.ChiefComplaints.Find(id);
            db.ChiefComplaints.Remove(chiefComplaints);
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
