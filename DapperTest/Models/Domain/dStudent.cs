using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DapperTest.Models.Domain
{
    public class dStudent
    {
        public int intStudentID { get; set; }

        [DisplayName("Branch ")]
        [Required(ErrorMessage = "Select Branch")]
        public int intBranchID { get; set; }

        [DisplayName("Student Name")]
        [Required(ErrorMessage = "Enter Student Name")]
        [StringLength(50, ErrorMessage = "Only 50 character are allowed")]
        public string vchStudentName { get; set; }

        [DisplayName("Address")]
        [Required(ErrorMessage = "Enter Address")]
        [StringLength(50, ErrorMessage = "Only 100 character are allowed")]
        public string vchAddress { get; set; }
    }
}