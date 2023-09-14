using System;
using Comman.Data.Dapper;
using Comman.Data.Dapper.Interface;
using Uark_Exam.Repository.Modal.DB;

namespace Uark_Exam.Repository.Repository
{
    public class ApplyFileRepository:DapperRepository<ApplyFile,Guid>
    {
        public ApplyFileRepository(IRepositoryContext context) : base(context)
        {
        }
    }
}