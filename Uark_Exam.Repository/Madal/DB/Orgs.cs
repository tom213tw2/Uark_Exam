using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Dapper;

namespace Uark_Exam.Repository.Madal.DB
{
    [Table("Orgs", Schema = "dbo")]
    public class Orgs
    {
        
        [Dapper.Key]
        [Dapper.Required]
        [Column("Id")]
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [Dapper.Required]
        [Column("title")]
        [DisplayName("單位名稱")]
        public string Title { get; set; }

        [Dapper.Required]
        [Column("org_no")]
        [DisplayName("單位編號")]
        public int OrgNo { get; set; }

        [Column("created_at")]
        [DisplayName("建立時間")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}",ConvertEmptyStringToNull = true)]
        public DateTime CreatedDateTime { get; set; }

        [Column("updated_at")]
        [DisplayName("異動時間")]
        public DateTime UpdatedDateTime { get; set; }
    }
}