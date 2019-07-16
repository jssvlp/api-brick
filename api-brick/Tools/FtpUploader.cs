using CoreFtp;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace api_brick.Tools
{
    public class FtpUploader
    {
        private readonly IConfiguration _configuration;

        public FtpUploader(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void UploadFile(string path, string filePath, string fileName )
        {
            var tempFile = new FileInfo("C:\\test.png");

            System.Net.FtpWebResponse ftp_web_response = null;
            string ftpAddress = _configuration["FTP_SERVER"];
            string ftpUName = _configuration["FTP_USER"];
            string ftpPWord = _configuration["FTP_PWD"];

            string destinyPath = ftpAddress + "/" + path + "/" + fileName;

          
            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential(ftpUName, ftpPWord);
                client.UploadFile(destinyPath, WebRequestMethods.Ftp.UploadFile, filePath);
               
            }
            //ftp_web_response = (FtpWebResponse)client.();
            //string ftp_response = ftp_web_response.StatusDescription;
            //string status_code = Convert.ToString(ftp_web_response.StatusCode);
            //ftp_web_response.Close();


        }

    }
}
