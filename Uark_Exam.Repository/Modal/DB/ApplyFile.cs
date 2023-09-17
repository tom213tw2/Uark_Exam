using System;
using System.ComponentModel;
using Dapper;

namespace Uark_Exam.Repository.Madal.DB
{
    [Table("Apply_File", Schema = "dbo")]
    public class ApplyFile
    {
        [Key]
        [Required]
        [Column("Id")]
        [DisplayName("Id")]
        public Guid Id { get; set; }
    
        [Required]
        [Column("user_id")]
        [DisplayName("UserId")]
        public Guid UserId { get; set; }
    
        [Column("file_path")]
        [DisplayName("檔案路徑")]
        public string FilePath { get; set; }
    
        [Column("created_at")]
        [DisplayName("建立日期")]
        [IgnoreInsert]
        public DateTime CreatedDateTime { get; set; }
    
        [Column("updated_at")]
        [DisplayName("異動日期")]
        [IgnoreInsert]
        public DateTime UpdatedDateTime { get; set; }
    }
}