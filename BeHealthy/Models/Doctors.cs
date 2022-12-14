//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeHealthy.Models
{
    using System;
    using System.Collections.Generic;
    //額外using這兩個
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Doctors
    {
        [Key]
        [DisplayName("醫師編號")]
        [Required]
        public string DoctorID { get; set; }

        [DisplayName("醫師姓名")]
        [Required]
        public string DoctorNAME { get; set; }

        [DisplayName("醫師電話")]
        [Required]
        public string DoctorPHONE { get; set; }

        [DisplayName("醫師信箱")]
        public string DoctorEMAIL { get; set; }

        [DisplayName("醫師密碼")]
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "密碼長度最少八碼")]
        [MaxLength(12, ErrorMessage = "密碼長度最多12碼")]
        public string DoctorPASSWORD { get; set; }
    }
}
