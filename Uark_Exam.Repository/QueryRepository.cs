using System.Configuration;
using Comman.Data.Dapper;
using Comman.Data.Dapper.Interface;

namespace Uark_Exam.Repository
{
    public class QueryRepository
    {
        public static IRepositoryContext Default => new DapperContext(GetConnStr("Default"));
        private static string GetConnStr(string connStr)
        {
            return ConfigurationManager.ConnectionStrings[connStr].ConnectionString;
        }
    }
}