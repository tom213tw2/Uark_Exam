using System;
using System.Configuration;
using System.IO;
using System.Web;
using NLog;
using Uark_Exam.Interface;
using Uark_Exam.Repository;
using Uark_Exam.Repository.Repository;

namespace Uark_Exam.Service
{
    public class FileService: IFileService
    {
        private readonly string _filePath;
        public FileService()
        {
            _filePath=ConfigurationManager.AppSettings["FilePath"];
        }
        public string UploadFile(Guid id)
        {
            var httpPostedFile = HttpContext.Current.Request.Files[0];
            if (httpPostedFile == null) return null; 
            if (!System.IO.Directory.Exists(_filePath))
            {
                System.IO.Directory.CreateDirectory(_filePath);
            }
            var extension = System.IO.Path.GetExtension(httpPostedFile.FileName);
            var fileName = id+extension;
            var filePath = _filePath + fileName;
            httpPostedFile.SaveAs(filePath);
            return filePath;
        }
        public void DownloadFile(string filePath)
        {
            if (!File.Exists(filePath)) return;
            try
            {
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                HttpContext.Current.Response.TransmitFile(filePath);
                HttpContext.Current.Response.End();
            }
            catch(Exception ex)
            {
                var logger = LogManager.GetCurrentClassLogger();
                logger.Error(ex.Message);
                logger.Error(ex.StackTrace);
            }
          

        }
    }
}