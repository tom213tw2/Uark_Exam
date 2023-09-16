using System;
using Comman.Data.Dapper;
using Comman.Data.Dapper.Interface;
using Uark_Exam.Repository.Madal.DB;

namespace Uark_Exam.Repository.Repository
{
    public class vUsersRepository:DapperRepository<vUsers,Guid>
    {
        public vUsersRepository(IRepositoryContext context) : base(context)
        {
        }
    }
}