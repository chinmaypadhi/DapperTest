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
    public class impBranch : IBranch
    {
        public Task<string> AddBranch(dBranch branch)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_CHRACTION", "SUBINS");
            param.Add("@P_vchBranchName", branch.vchBranchName);
            param.Add("@p_vchBranchDesc", branch.vchBranchDesc);
            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDMLAsync("SP_Branch_DML", param, "@P_VCHMSGOUT");
        }

        public string AddBranch1(dBranch branch)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_CHRACTION", "SUBINS");
            param.Add("@P_vchBranchName", branch.vchBranchName);
            param.Add("@p_vchBranchDesc", branch.vchBranchDesc);
            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_Branch_DML", param, "@P_VCHMSGOUT");
        }

        public IEnumerable<dBranch> BranchList()
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_CHRACTION", "BALL");
            return DapperORM.ReturnList<dBranch>("SP_Branch_Report", param);
        }

        public dBranch BranchDeatils(int intBranchID)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "BDTL");
            param.Add("@P_intID", intBranchID);
            return DapperORM.ReturnDetails<dBranch>("SP_Branch_Report", param);
        }

        public Task<string> EditBranch(dBranch branch)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_CHRACTION", "SUBEDIT");
            param.Add("@P_intID", branch.intID);
            
            param.Add("@P_vchBranchName", branch.vchBranchName);
            param.Add("@p_vchBranchDesc", branch.vchBranchDesc);
            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDMLAsync("SP_Branch_DML", param, "@P_VCHMSGOUT");
        }

        public IEnumerable<Branch_DDL> BranchForDD()
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_CHRACTION", "BDTLDD");
            return DapperORM.ReturnList<Branch_DDL>("SP_Branch_Report", param);
        }
    }
}