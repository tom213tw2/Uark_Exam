using System;
using System.ComponentModel;
using Dapper;

namespace Uark_Exam.Repository.Madal.DB
{
    [Table("Orgs", Schema = "dbo")]
    public class Orgs
    {
        
        [Key]
        [Required]
        [Column("Id")]
        [DisplayName("Id")]
        [IgnoreInsert]
        public Guid Id { get; set; }

        [Required]
        [Column("title")]
        [DisplayName("單位名稱")]
        public string Title { get; set; }

        [Required]
        [Column("org_no")]
        [DisplayName("單位編號")]
        public int OrgNo { get; set; }

        [Column("created_at")]
        [DisplayName("建立時間")]
        [IgnoreInsert]
        public DateTime CreatedDateTime { get; set; }

        [Column("updated_at")]
        [DisplayName("異動時間")]
        [IgnoreInsert]
        public DateTime UpdatedDateTime { get; set; }
    }
}