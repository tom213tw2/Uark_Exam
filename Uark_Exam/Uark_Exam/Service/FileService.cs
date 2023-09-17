using System.Web;
using Uark_Exam.Interface;

namespace Uark_Exam.Service
{
    public class FileService: IFileService
    {
        public void UploadFile()
        {
            var httpPostedFile = HttpContext.Current.Request.Files[0];
            throw new System.NotImplementedException();
        }
        public void DownloadFile()
        {
            throw new System.NotImplementedException();
        }
    }
}