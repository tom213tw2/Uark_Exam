using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Dapper;

namespace Uark_Exam.Repository.Madal.DB
{
    [Table("Users", Schema = "dbo")]
    public class Users
    {
        [Dapper.Key]
        [Dapper.Required]
        [Column("Id")]
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [Dapper.Required]
        [Column("org_id")]
        [DisplayName("單位編號")]
        public Guid OrgId { get; set; }

        [Dapper.Required]
        [Column("name")]
        [DisplayName("姓名")]
        public string Name { get; set; }
        
        

        [Column("birthday")]
        [DisplayName("生日")]
        public DateTime? Birthday { get; set; }
    
        [Dapper.Required]
        [Column("email")]
        [DisplayName("信箱")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }
    
        [Dapper.Required]
        [Column("account")]
        [DisplayName("帳號")]
        [StringLength(maximumLength:10,MinimumLength = 5)]
        public string Account { get; set; }

        [Dapper.Required]
        [Column("password")]
        [DisplayName("密碼")]
        public string Password { get; set; }

        [Column("status")]
        [DisplayName("狀態")]
        public string Status { get; set; }

        [Column("created_at")]
        [DisplayName("建立日期")]
        public DateTime CreatedDateTime { get; set; }

        [Column("updated_at")]
        [DisplayName("異動日期")]
        public DateTime UpdatedDateTime { get; set; }
    }
}