using DapperTest.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTest.Models.IRepository
{
    interface IStudent
    {
        Task<string> AddStudent(dStudent branch);

       
    }
}
