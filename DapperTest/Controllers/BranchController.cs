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
    public class BranchController : Controller
    {
        IBranch _branch = new impBranch();
        // GET: Branch
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateBranch()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateBranch(dBranch branch)
        {
            string status = await _branch.AddBranch(branch);


            return View();
        }

        [HttpGet]
        public ActionResult CreateBranch1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBranch1(dBranch branch)
        {
            string status = _branch.AddBranch1(branch);

            return RedirectToAction("ViewBranch", "Branch");

            //return View();
        }


        [HttpGet]
        //View Branch details without JQuery DataTable
        public ActionResult ViewBranch()
        {

            return View(_branch.BranchList());
        }

        [HttpGet]
        //View Branch details without JQuery DataTable
        public ActionResult EditBranch(int? id)
        {
            dBranch branch = _branch.BranchDeatils((int)id);
            return View(branch);
        }

        [HttpPost]
        public ActionResult EditBranch(dBranch branch)
        {
            _branch.EditBranch(branch);
            return RedirectToAction("ViewBranch", "Branch");



        }
    }
}