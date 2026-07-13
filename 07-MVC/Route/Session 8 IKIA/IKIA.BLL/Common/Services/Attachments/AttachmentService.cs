using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKIA.BLL.Common.Services.Attachments
{
    public class AttachmentService : IAttachmentService
    {
        private List<string> _allowedExtensions = new List<string>() {".png",".jpg",".jpeg"};
        private const int _allowedMaxSize = 2_097_152;
        public async Task<string?> UploadAsync(IFormFile file, string folderName)
        {
            var extension = Path.GetExtension(file.FileName);     // will be ex: .png (with the dot)
            
            if (! _allowedExtensions.Contains(extension))
                return null;
            
            if(file.Length > _allowedMaxSize)
                return null;

            // Bad Way
            // var folderPath = $"C:\\Users\\lenovo\\Desktop\\New folder (2)\\6 - MVC [NEW C42]\\MVC - Session 7 IKIA\\IKIA.PL\\wwwroot\\files\\{folderName}";

            // Better Way 
            // var folderPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\files\\images\\{folderName}";

            // Best Way 
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", folderName);


            // File name will be unique
            var fileName = $"{Guid.NewGuid()}{extension}";



            // File Path : File location 
            var filePath = Path.Combine(folderPath, fileName);


            // incase we create a folder in each request for example .... 
            if(!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);


            // Streaming : Data per Time
            using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            // or
            // using var fileStream = File.Create(filePath);

            // FileMode.Create : overriden if exists
            // FileMode.CreateNew : exception if exists
            // search on others ... 

            return fileName;

        }
        public bool Delete(string filename)
        {
            if (File.Exists($"{Directory.GetCurrentDirectory()}\\wwwroot\\files\\images\\{filename}"))
            {
                File.Delete($"{Directory.GetCurrentDirectory()}\\wwwroot\\files\\images\\{filename}");
                return true;
            }
            return false;
        }

    }
}
