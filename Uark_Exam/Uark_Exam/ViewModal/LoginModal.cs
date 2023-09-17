using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uark_Exam.ViewModal
{
    public class LoginModal:BaseModal
    {
        [Key]
        [Required]
        [DisplayName("Id")]
        public Guid Id { get; set; }
       
        [DisplayName("OrgId")]
        public Guid OrgId { get; set; }

        [Required]
        [DisplayName("OrgName")]
        public string OrgName { get; set; }

        [Required]
        [Column("name")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Column("birthday")]
        [DisplayName("Birthday")]
        public DateTime? Birthday { get; set; }

        [Required]
        [PasswordPropertyText]
        [DisplayName("Password")]
        public string Password { get; set; }
    
        [Required]
        [Column("email")]
        [DisplayName("Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }
    
        [Required]
        [Column("account")]
        [DisplayName("Account")]
        public string Account { get; set; }

        [Column("status")] 
        [DisplayName("Status")] 
        public string Status { get; set; } = "Pending Approval";

        [Required]
        [DisplayName("File")] 
        public string File { get; set; }
    }
}