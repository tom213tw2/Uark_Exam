namespace Uark_Exam.Interface
{
    public interface IMailService
    {
        void SendMail(string email, string subject, string body);
    }
}