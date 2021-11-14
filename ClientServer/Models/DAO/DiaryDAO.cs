using ClientServer.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace ClientServer.Models.DAO
{
    public class DiaryDAO
    {
        private ClientServerDbContext context = null;

        private List<ThongTinCongNhan> employeeNameList = null;

        private List<DanhMucCongViec> workNameList = null;

        private List<ThongTinSanPham> productNameList = null;
        public DiaryDAO()
        {
            context = new ClientServerDbContext();
            employeeNameList = new List<ThongTinCongNhan>();
            workNameList = new List<DanhMucCongViec>();
            productNameList = new List<ThongTinSanPham>();
        }
        public List<NhatKiSanLuongKhoan> ListAll()
        {
            var list = context.NhatKiSanLuongKhoans.ToList();
            return list;
        }

        public ExpandoObject GetById(int id)
        {
            dynamic mymodel = new ExpandoObject();
            // lấy ra nhật ký theo id
            mymodel.Diary = context.NhatKiSanLuongKhoans.SingleOrDefault(x => x.MaNhatKi == id);

            // danh sách công nhân của nhật ký
            List<DanhMucCongNhanThucHienKhoan> employeeList =
                context.DanhMucCongNhanThucHienKhoans.Where(n => n.MaNhatKi == id).ToList();

            // danh sách tên công nhân của nhật ký
            foreach (DanhMucCongNhanThucHienKhoan e in employeeList)
            {
                var employeeDAO = new EmployeeDAO();
                ThongTinCongNhan employee = employeeDAO.GetById(e.MaCongNhan);
                employeeNameList.Add(employee);
            }

            // danh sách công việc của nhật ký
            List<DanhMucCongViecDaLam> workList = 
                context.DanhMucCongViecDaLams.Where(x => x.MaNhatKi == id).ToList();

            // danh sách tên công việc của nhật ký + tên sản phẩm công việc đó thực hiện
            foreach (DanhMucCongViecDaLam c in workList)
            {
                var workDAO = new WorkDAO();
                var productDAO = new ProductDAO();
                DanhMucCongViec employee = workDAO.GetById(c.MaCongViec);
                ThongTinSanPham product = productDAO.GetById(c.MaSanPham);
                workNameList.Add(employee);
                productNameList.Add(product);
            }

            mymodel.EmployeeList = employeeList;
            mymodel.EmployeeNameList = employeeNameList;
            mymodel.WorkList = workList;
            mymodel.WorkNameList = workNameList;
            mymodel.ProductNameList = productNameList;
            return mymodel;
        }
    }
}