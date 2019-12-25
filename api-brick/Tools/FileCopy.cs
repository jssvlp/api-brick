using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Tools
{
    public class FileCopy
    {
        protected IHostingEnvironment _environment;
        public FileCopy(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<FileCopyResponse> CopyFileToAssetsFolderAsync(IFormFile filesData, string folder)
        {

            var uploadFilesPath = Path.Combine(_environment.ContentRootPath, "uploads");

            uploadFilesPath = Path.Combine(uploadFilesPath, folder);

            if (!Directory.Exists(uploadFilesPath))
                Directory.CreateDirectory(uploadFilesPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(filesData.FileName);

            var filePath = Path.Combine(uploadFilesPath, fileName);
            FileCopyResponse response = new FileCopyResponse();
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await filesData.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {

                response.Message = ex.Message.ToString();
                response.Success = false;

                return response;
                
            }
            response.Success  = true;
            response.Message  = "File upluaded success";
            response.FileName = fileName;

            return response;
        }
    }

    public class FileCopyResponse
    {

        public bool Success { get; set; }
        public string Message { get; set; }
        public string FileName { get; set; }
    }
}
