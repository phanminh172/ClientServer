using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductModel
    {
        private ClientServerDBContext db = null;
        public ProductModel()
        {
            db = new ClientServerDBContext();
        }
        public List<ThongTinSanPham> ListAll ()
        {
            var list = db.ThongTinSanPhams.ToList();
            return list;
        }
    }
}
