using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;  //因為要用到filter所以要using這個

namespace BeHealthy.Controllers
{
    public class LoginCheck : ActionFilterAttribute  //繼承ActionFilterAttribute這個類別
    {
        void LoginState(HttpContext context)  //因為Session只能在HTTPcontext下才可以使用，所以先在這個方法裡面丟入HTTPContext
        {
            if (context.Session["user"] == null)
            {
                context.Response.Redirect("/Home/Index");  //如果是null就導向HomeController的index的頁面
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)  //每一次要執行動作的時候就檢視
        {
            HttpContext context = HttpContext.Current;  //把HttpContext的Current狀態丟給context
            LoginState(context);
        }
    }
}