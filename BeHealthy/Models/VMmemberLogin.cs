using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeHealthy.Models
{
    public class VMmemberLogin
    {
        [Key]
        [DisplayName("會員帳號")]
        [Required]
        public string MemberID { get; set; }

        [DisplayName("會員密碼")]
        [Required]
        [DataType(DataType.Password)]
        public string MemberPASSWORD { get; set; }

    }
}