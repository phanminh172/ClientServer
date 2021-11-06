using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DiaryModel
    {
        private ClientServerDBContext db = null;
        public DiaryModel()
        {
            db = new ClientServerDBContext();
        }
        public List<NhatKiSanLuongKhoan> ListAll()
        {
            var list = db.NhatKiSanLuongKhoans.ToList();
            return list;
        }
    }
}
