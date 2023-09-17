using System;
using Dapper;

namespace Uark_Exam.Repository.Madal.DB
{
    [Table("vUsers", Schema = "dbo")]
    public class vUsers
    {
        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; }
        
        [Required]
        [Column("af_Id")]
        public Guid AfId { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("account")]
        public string Account { get; set; }

        [Required]
        [Column("status")]
        public string Status { get; set; }

        [Required]
        [Column("org_no")]
        public int OrgNo { get; set; }

        [Required]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [Column("ipaddress")]
        public string Ipaddress { get; set; }
        
        [Required]
        [Column("login_at")]
        public DateTime? LoginDateTime { get; set; }
        
        [Required]
        [Column("created_at")]
        public DateTime? CreateDateTime { get; set; }
        
        
    }
}