using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DapperTest.Models.Domain
{
    public class dBranch
    {
        public int intID { get; set; }

        [DisplayName("Branch Name")]
        [Required(ErrorMessage = "Enter Branch Name")]
        [StringLength(50, ErrorMessage = "Only 50 character are allowed")]
        public string vchBranchName { get; set; }

        [DisplayName("Branch Description")]
        [Required(ErrorMessage = "Enter Branch Description")]
        [StringLength(50, ErrorMessage = "Only 100 character are allowed")]
        public string vchBranchDesc { get; set; }
       
    }

    public class Branch_DDL
    {
        public int intID { get; set; }
        public string vchBranchName { get; set; }
    }
}