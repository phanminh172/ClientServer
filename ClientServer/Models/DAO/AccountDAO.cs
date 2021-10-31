using ClientServer.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ClientServer.Models.DAO
{
    public class AccountDAO
    {
        private ClientServerDbContext context = null;
        public AccountDAO()
        {
            context = new ClientServerDbContext();
        }
        public bool Login(string userName, string password)
        {
            object[] sqlParams =
            {
                new SqlParameter("@UserName",userName),
                new SqlParameter("@Password",password),
            };
            var res = context.Database.SqlQuery<bool>("Sp_Account_Login @UserName ,@Password", sqlParams).SingleOrDefault();
            return res;
        }
    }
}