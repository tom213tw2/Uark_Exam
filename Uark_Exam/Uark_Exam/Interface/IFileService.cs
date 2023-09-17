using System;

namespace Uark_Exam.Interface
{
    public interface IFileService
    {
        void DownloadFile(string filePath);
        string UploadFile(Guid id);
    }
}