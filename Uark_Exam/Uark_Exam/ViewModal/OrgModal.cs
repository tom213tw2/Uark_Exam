using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Uark_Exam.ViewModal
{
    public class OrgModal:BaseModal
    {
        [Key]
        [Required]
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("OrgNo")]
        public int OrgNo { get; set; }

       
        [DisplayName("CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; }

      
        [DisplayName("UpdatedDateTime")]
        public DateTime UpdatedDateTime { get; set; }
    }
}