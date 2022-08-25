using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeHealthy.Models;

namespace BeHealthy.Controllers
{
    public class HomeManagerController : Controller
    {
        BeHealthyEntities1 db = new BeHealthyEntities1();  //如果這個controller有要連接到資料庫就要寫這一行 ，名稱去資料庫的context.cc查

        //[LoginCheck] //寫在這代表要做這個Action前須先執行LoginCheck
        // GET: HomeManager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]    //這是用來確認傳入的資料對不對
        public ActionResult Login(VMLogin vMLogin)  
        {
            //select * from Employee where account=@account and password=@password
            var user = db.Doctors.Where(m => m.DoctorID == vMLogin.DoctorID && m.DoctorPASSWORD == vMLogin.DoctorPASSWORD).FirstOrDefault();
           
            //如果比對錯誤，就是會傳null值
            if (user == null)
            {   
                ViewBag.ErrMsg = "帳號或密碼有錯!!";
                return View(vMLogin);
            }
            //session是用來確認是否處於登入狀態，如果session有東西代表是登入狀態，[]中括號裡面的名稱是自己取的，session變數不用定義資料型別，userstate就是一個session的變數
            Session["doctor"] = user;  //把user指定給userstate這個變數，session不管寫在哪裡都是一個全域變數，只有瀏覽器被關掉才會不存在
            return RedirectToAction("Index","ChiefComplaints");  //如果登入資料無誤，就會轉去同一個controller的index，因為是同一個controller所以不用特別寫出cotroller名字

        }

        //[LoginCheck]
        public ActionResult Logout()
        {

            Session["doctor"] = null;  //因為登出了，所以要把null指定給session
            return RedirectToAction("Index", "Home");
        }
    }
}