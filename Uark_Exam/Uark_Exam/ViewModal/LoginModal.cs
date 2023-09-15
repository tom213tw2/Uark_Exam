using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Uark_Exam.Repository.Madal.DB;

namespace Uark_Exam.ViewModal
{
    public class LoginModal:BaseModal
    {
        [Key]
        [Required]
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [Required]
        [Column("org_id")]
        [DisplayName("OrgId")]
        public Guid OrgId { get; set; }

        [Required]
        [Column("name")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Column("birthday")]
        [DisplayName("Birthday")]
        public DateTime? Birthday { get; set; }

        [Required]
        [PasswordPropertyText]
        [DisplayName("PassWord")]
        public string PassWord { get; set; }
    
        [Required]
        [Column("email")]
        [DisplayName("信箱")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }
    
        [Required]
        [Column("account")]
        [DisplayName("Account")]
        public string Account { get; set; }

        [Column("status")] 
        [DisplayName("狀態")] public string Status { get; set; } = "Pending Approval";

        
    }
}