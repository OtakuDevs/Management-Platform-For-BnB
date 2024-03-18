using Microsoft.AspNetCore.Http;

namespace ImageHelper.Services;

public interface IFileUploadService
{
    Task<string> UploadFile(IFormFile file);
}