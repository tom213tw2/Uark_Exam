using System;
using Comman.Data.Dapper;
using Comman.Data.Dapper.Interface;
using Uark_Exam.Repository.Modal.DB;

namespace Uark_Exam.Repository.Repository
{
    public class SysLogRepository:DapperRepository<SysLog,Guid>
    {
        public SysLogRepository(IRepositoryContext context) : base(context)
        {
        }
    }
}