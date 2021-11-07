using ClientServer.Areas.Admin.Code;
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
        //public bool Login(string userName, string password)
        //{
        //    object[] sqlParams =
        //    {
        //        new SqlParameter("@UserName",userName),
        //        new SqlParameter("@Password",password),
        //    };
        //    var res = context.Database.SqlQuery<bool>("Sp_Account_Login @UserName ,@Password", sqlParams).SingleOrDefault();
        //    return res;
        //}
        public int Login(string userName, string passWord, bool isLoginAdmin = false)
        {
            var result = context.Accounts.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.GroupID == SessionHelper.ADMIN_GROUP || result.GroupID == SessionHelper.MOD_GROUP)
                    {
                        if (result.Status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.Password == passWord)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.Password == passWord)
                            return 1;
                        else
                            return -2;
                    }
                }
            }
        }
        public long Insert(Account entity)
        {
            context.Accounts.Add(entity);
            context.SaveChanges();
            return entity.ID;
        }
        public bool ChangeStatus(long id)
        {
            var user = context.Accounts.Find(id);
            user.Status = !user.Status;
            context.SaveChanges();
            return user.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var user = context.Accounts.Find(id);
                context.Accounts.Remove(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public Account GetById(string userName)
        {
            return context.Accounts.SingleOrDefault(x => x.UserName == userName);
        }
        public Account ViewDetail(int id)
        {
            return context.Accounts.Find(id);
        }
    }
}