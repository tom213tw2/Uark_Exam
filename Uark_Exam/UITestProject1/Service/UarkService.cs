using NSubstitute;
using NUnit.Framework;
using Uark_Exam.Interface;
using Uark_Exam.Repository.Repository;


namespace UITestProject1.Service
{
    public class UarkService
    {
        private IUarkService _uarkService;
        private UsersRepository _usersRepository;

        [SetUp]
        public void SetUp()
        {
            _uarkService = Substitute.For<IUarkService>();
            _usersRepository = Substitute.For<UsersRepository>();
        }
    }
}