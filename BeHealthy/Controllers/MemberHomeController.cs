using BeHealthy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeHealthy.Controllers
{
    public class MemberHomeController : Controller
    {
        BeHealthyEntities1 db = new BeHealthyEntities1();
        // GET: MemberHome
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]    //這是用來確認傳入的資料對不對
        public ActionResult Login(VMmemberLogin vMmemberLogin)
        {
            //select * from Employee where account=@account and password=@password
            var user = db.Members.Where(m => m.MemberID == vMmemberLogin.MemberID && m.MemberPASSWORD == vMmemberLogin.MemberPASSWORD).FirstOrDefault();
            //如果比對錯誤，就是會傳null值
            if (user == null)
            {
                ViewBag.ErrMsg = "帳號或密碼有錯!!";
                return View(vMmemberLogin);
            }
            Session["member"] = user;
            return RedirectToAction("Index", "MemberHome");  //如果登入資料無誤，就會轉去同一個controller的index，因為是同一個controller所以不用特別寫出cotroller名字


        }

        [LoginCheck] //寫在這代表要做這個Action前須先執行LoginCheck
        public ActionResult Logout()
        {

            Session["member"] = null;  //因為登出了，所以要把null指定給session
            return RedirectToAction("Index", "Home");
        }
    }
}