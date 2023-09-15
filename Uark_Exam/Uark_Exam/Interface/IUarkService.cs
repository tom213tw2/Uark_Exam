using Uark_Exam.ViewModal;

namespace Uark_Exam.Interface
{
    public interface IUarkService
    {
        LoginModal ValidateUser(LoginModal loginModal);
    }
}