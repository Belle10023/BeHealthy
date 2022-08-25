using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeHealthy.Models
{
    public class VMLogin
    {

        [DisplayName("醫師編號")]
        [Required]
        public string DoctorID { get; set; }

        [DisplayName("醫師密碼")]
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "密碼長度最少八碼")]
        [MaxLength(12, ErrorMessage = "密碼長度最多12碼")]
        public string DoctorPASSWORD { get; set; }
    }
}