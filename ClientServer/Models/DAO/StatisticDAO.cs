using ClientServer.Areas.Admin.Models;
using ClientServer.Models.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ClientServer.Models.DAO
{
    public class StatisticDAO
    {
        ClientServerDbContext context;
        public StatisticDAO()
        {
            context = new ClientServerDbContext();
        }

        public IEnumerable<DiaryModel> WeekDiary(int? sortOrder, string searchString, DateTime? date, int page, int pageSize)
        {
            if (searchString != null && sortOrder != null)
            {
                object[] parameters =
                {
                new SqlParameter("@maCN", searchString),
                new SqlParameter("@date", date.ToString())
                };
                if (searchString == "")
                {
                    switch (sortOrder)
                    {
                        case 1:
                            return context.Database
                                .SqlQuery<DiaryModel>("exec Sp_MonthDiaryAll")
                                .ToList()
                                .ToPagedList(page, pageSize);
                        case 2:
                            return context.Database
                                .SqlQuery<DiaryModel>("exec Sp_WeekDiaryAll @date", parameters)
                                .ToList()
                                .ToPagedList(page, pageSize);
                        case 3:
                            return context.Database
                                .SqlQuery<DiaryModel>("exec Sp_nkslkC3")
                                .ToList()
                                .ToPagedList(page, pageSize);
                        default:
                            return context.Database
                                .SqlQuery<DiaryModel>("exec Sp_DiaryAll")
                                .ToList()
                                .ToPagedList(page, pageSize);
                    }
                }
                switch (sortOrder)
                {
                    case 1:
                        return context.Database
                            .SqlQuery<DiaryModel>("exec Sp_MonthDiary @maCN", parameters)
                            .ToList()
                            .ToPagedList(page, pageSize);
                    case 2:
                        return context.Database
                            .SqlQuery<DiaryModel>("exec Sp_WeekDiary @maCN, @date", parameters)
                            .ToList()
                            .ToPagedList(page, pageSize);
                    default:
                        return context.Database
                            .SqlQuery<DiaryModel>("exec Sp_DiaryAll")
                            .ToList()
                            .ToPagedList(page, pageSize);
                }
            }
            return context.Database
              .SqlQuery<DiaryModel>("exec Sp_DiaryAll")
              .ToList()
              .ToPagedList(page, pageSize);

        }

        public IEnumerable<StatisticEmployeeModel> StatisticEmployee(int? sortOrder, int page, int pageSize)
        {
            if (sortOrder != null)
            {
                switch (sortOrder)
                {
                    case 1:
                        return context.Database
                            .SqlQuery<StatisticEmployeeModel>("exec Sp_Employee_Male")
                            .ToList()
                            .ToPagedList(page, pageSize);
                    case 2:
                        return context.Database
                            .SqlQuery<StatisticEmployeeModel>("exec Sp_Employee_Female")
                            .ToList()
                            .ToPagedList(page, pageSize);
                    default:
                        return context.Database
                              .SqlQuery<StatisticEmployeeModel>("exec Sp_Employee_ListAll")
                              .ToList()
                              .ToPagedList(page, pageSize);
                }
            }
            return context.Database
              .SqlQuery<StatisticEmployeeModel>("exec Sp_Employee_ListAllNonParam")
              .ToList()
              .ToPagedList(page, pageSize);

        }
        public IEnumerable<SalaryModel> StatisticSalary(int? sortOrder, DateTime? date, int page, int pageSize)
        {
            object[] parameters =
                {
                new SqlParameter("@dateNow", DateTime.Now.ToString()),
                new SqlParameter("@date", date.ToString())
                };
            if (sortOrder != null)
            {
                
                switch (sortOrder)
                {
                    case 1:
                        return context.Database
                            .SqlQuery<SalaryModel>("exec Sp_MaxSalary")
                            .ToList()
                            .ToPagedList(page, pageSize);
                    case 2:
                        return context.Database
                            .SqlQuery<SalaryModel>("exec Sp_MinSalary")
                            .ToList()
                            .ToPagedList(page, pageSize);
                    case 3:
                        return context.Database
                            .SqlQuery<SalaryModel>("exec Sp_MonthSalary @date",parameters)
                            .ToList()
                            .ToPagedList(page, pageSize);
                    case 4:
                        return context.Database
                            .SqlQuery<SalaryModel>("exec Sp_WeekSalary @date",parameters)
                            .ToList()
                            .ToPagedList(page, pageSize);
                    default:
                        return context.Database
                          .SqlQuery<SalaryModel>("exec Sp_MonthSalary @dateNow", parameters)
                          .ToList()
                          .ToPagedList(page, pageSize);
                }
            }
            return context.Database
                           .SqlQuery<SalaryModel>("exec Sp_MonthSalary @dateNow", parameters)
                           .ToList()
                           .ToPagedList(page, pageSize);

        }
        public IEnumerable<WorkingShiftModel> StatisticWorkingDay(DateTime? date, int page, int pageSize)
        {
            object[] parameters =
                {
                new SqlParameter("@dateNow", DateTime.Now.ToString()),
                new SqlParameter("@date", date.ToString())
                };
            if (date != null)
            {
                return context.Database
                           .SqlQuery<WorkingShiftModel>("exec Sp_ListWorkingDay @date", parameters)
                           .ToList()
                           .ToPagedList(page, pageSize);
            }
            return context.Database
                           .SqlQuery<WorkingShiftModel>("exec Sp_ListWorkingDay @dateNow", parameters)
                           .ToList()
                           .ToPagedList(page, pageSize);

        }
    }
}