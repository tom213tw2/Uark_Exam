using System;
using System.ComponentModel;
using Dapper;

namespace Uark_Exam.Repository.Madal.DB
{
    [Table("Users", Schema = "dbo")]
    public class Users
    {
        [Key]
        [Required]
        [Column("Id")]
        [DisplayName("Id")]
        [IgnoreInsert]
        public Guid Id { get; set; }

        [Required]
        [Column("org_id")]
        [DisplayName("單位編號")]
        public Guid OrgId { get; set; }

        [Required]
        [Column("name")]
        [DisplayName("姓名")]
        public string Name { get; set; }
        
        

        [Column("birthday")]
        [DisplayName("生日")]
        public DateTime? Birthday { get; set; }
    
        [Required]
        [Column("email")]
        [DisplayName("信箱")]
        public string Email { get; set; }
    
        [Required]
        [Column("account")]
        [DisplayName("帳號")]
        public string Account { get; set; }

        [Required]
        [Column("password")]
        [DisplayName("密碼")]
        public string Password { get; set; }

        [Column("status")]
        [DisplayName("狀態")]
        public string Status { get; set; }

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