using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKIA.BLL.Common.Services.Attachments
{
    public interface IAttachmentService
    {
        // Update doc 
        // Delete doc
        // Download Doc will be discussed later


        // Upload a Doc : 
        Task<string?> UploadAsync(IFormFile file, string folderName);   // IFormFile because this will be a file from HTML Form 
        
        bool Delete(string filePath);
    }
}
