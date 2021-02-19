using DapperTest.Models.Domain;
using DapperTest.Models.IRepository;
using DapperTest.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DapperTest.Controllers
{
    public class StudentController : Controller
    {
        IBranch _branch = new impBranch();
        IStudent _student = new impStudent();

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateStudent()
        {
            ViewBag.branchList = _branch.BranchForDD().ToList();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateStudent(dStudent student)
        {
            string status = await _student.AddStudent(student);
            ViewBag.branchList = _branch.BranchForDD().ToList();
            return View();
        }



    }
}