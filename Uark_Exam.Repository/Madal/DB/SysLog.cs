using System;
using System.ComponentModel;
using Dapper;

namespace Uark_Exam.Repository.Madal.DB
{
    [Table("Syslog", Schema = "dbo")]
    public class SysLog
    {
        [Key]
        [Required]
        [Column("seq_no")]
        [DisplayName("SeqNo")]
        public Guid SeqNo { get; set; } 
    
        [Required]
        [Column("account")]
        [DisplayName("帳號")]
        public string Account { get; set; } 
    
        [Required]
        [Column("account")]
        [DisplayName("帳號")]
        public string IpAddress { get; set; }
    
        [Required]
        [Column("login_at")]
        [DisplayName("登入日期")]
        public DateTime LoginDateTime { get; set; }
    
        [Required]
        [Column("created_at")]
        [DisplayName("建立日期")]
        public DateTime CreatedDatTime { get; set; } 
    }
}