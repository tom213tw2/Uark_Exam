using System;
using Comman.Data.Dapper;
using Comman.Data.Dapper.Interface;

namespace Uark_Exam.Repository.Repository
{
    public class UsersRepository:DapperRepository<UsersRepository,Guid>
    {
        public UsersRepository(IRepositoryContext context) : base(context)
        {
        }
    }
}