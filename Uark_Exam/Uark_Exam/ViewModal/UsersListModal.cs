using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uark_Exam.ViewModal
{
    public class UsersListModal
    {
        [Key]
        [Required]
        [DisplayName("Id")]
        public Guid Id { get; set; }
        
        [Required]
        [DisplayName("Apply File Id")]
        public Guid AfId { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Account")]
        public string Account { get; set; }

        [Required]
        [DisplayName("Status")]
        public string Status { get; set; }

        [Required]
        [DisplayName("OrgNo")]
        public int OrgNo { get; set; }

        [Required]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Ipaddress")]
        public string Ipaddress { get; set; }
        
        [Required]
        [DisplayName("LoginDateTime")]
        public DateTime? LoginDateTime { get; set; }
        
        [Required]
        [DisplayName("CreateDate")]
        public DateTime? CreateDateTime { get; set; }
    }
}