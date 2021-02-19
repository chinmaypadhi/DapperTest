using Dapper;
using DapperTest.Models.Domain;
using DapperTest.Models.IRepository;
using MyMCE.Models.ConnectionFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DapperTest.Models.Repository
{
    public class impStudent : IStudent
    {
        public Task<string> AddStudent(dStudent student)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "STUDINS");
            param.Add("@P_intBranchID", student.intBranchID);
            param.Add("@P_vchStudentName", student.vchStudentName);
            param.Add("@P_vchAddress", student.vchAddress);

            
            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDMLAsync("SP_Student_DML", param, "@P_VCHMSGOUT");
        }
    }
}