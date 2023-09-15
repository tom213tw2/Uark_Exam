namespace Uark_Exam.ViewModal
{
    public class BaseModal
    {
        public string ErrorMessage { get; set; }

        public bool IsSuccess=>string.IsNullOrEmpty(ErrorMessage);
    }
}