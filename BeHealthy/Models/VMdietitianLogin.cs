using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeHealthy.Models
{
    public class VMdietitianLogin
    {
        [DisplayName("營養師師編號")]
        [Required]
        public string DietitianID { get; set; }

        [DisplayName("營養師密碼")]
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "密碼長度最少八碼")]
        [MaxLength(12, ErrorMessage = "密碼長度最多12碼")]
        public string DietitianPASSWORD { get; set; }
    }
}