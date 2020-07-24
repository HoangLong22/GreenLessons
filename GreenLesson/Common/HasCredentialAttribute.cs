//using Common;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.Services.Description;

//namespace GreenLesson.Common
//{
//    public class HasCredentialAttribute : AuthorizeAttribute
//    {
//        public string RoleID { set; get; }
//        protected override bool AuthorizeCore(HttpContextBase httpContext)
//        {
//            var isAuthorized = base.AuthorizeCore(httpContext);
//            if(!isAuthorized)
//            {
//                return true;
//            }
//            var session = (UserLogin)HttpContext.Current.Session[CommonConstants, USER_SESSION];
//            return base.AuthorizeCore(httpContext);
//        }
//    }
//}