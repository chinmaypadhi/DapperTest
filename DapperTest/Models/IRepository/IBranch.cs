using DapperTest.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTest.Models.IRepository
{
    interface IBranch
    {
        //Add new Subject
        Task<string> AddBranch(dBranch branch);

        Task<string> EditBranch(dBranch branch);

        string AddBranch1(dBranch branch);

        //To get All Subject List for View
        IEnumerable<dBranch> BranchList();

        dBranch BranchDeatils(int intBranchID);


        IEnumerable<Branch_DDL> BranchForDD();

    }
}
