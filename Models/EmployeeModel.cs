using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EmployeeModel
    {
        private ClientServerDBContext db = null;
        public EmployeeModel()
        {
            db = new ClientServerDBContext();
        }
        public List<ThongTinCongNhan> ListAll()
        {
            var list = db.ThongTinCongNhans.ToList();
            return list;
        }
    }
}
