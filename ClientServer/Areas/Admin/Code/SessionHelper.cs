﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServer.Areas.Admin.Code
{
    public class SessionHelper
    {
        //public static void SetSession(UserSession session)
        //{
        //    HttpContext.Current.Session["loginSession"] = session;
        //}
        //public static UserSession GetSession()
        //{
        //    var session = HttpContext.Current.Session["loginSession"];
        //    if (session == null)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        return session as UserSession;
        //    }
        //}
        public static string USER_SESSION = "USER_SESSION";
        public static string SESSION_CREDENTIALS = "SESSION_CREDENTIALS";
        public static string CartSession = "CartSession";
        public static string MEMBER_GROUP = "MEMBER";
        public static string ADMIN_GROUP = "ADMIN";
        public static string MOD_GROUP = "MOD";
    }
}