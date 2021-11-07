using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServer.Areas.Admin.Code
{
    [Serializable]
    public class UserSession
    {
        public string UserName { set; get; }
        public int UserID { set; get; }
        public string GroupID { set; get; }
    }
}