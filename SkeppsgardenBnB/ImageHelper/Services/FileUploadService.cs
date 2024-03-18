using System.Drawing;
using Microsoft.AspNetCore.Http;

namespace ImageHelper.Services;

public class FileUploadService : IFileUploadService
{
    public async Task<string> UploadFile(IFormFile file)
    {
        // Validate the file
        var imageValidator = new ValidateFileIsImage();
        if (!imageValidator.Validate(file))
        {
            return string.Empty;
        }

        // Generate a unique file name
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

        // Build the local file path
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "events", fileName);

        // Resize the image
        Bitmap newImage = SaveFileLocal.ResizeImage(file);
        SaveFileLocal.SaveAsync(filePath, newImage);

        // Get the URL of the file to be uploaded
        var url = $"~/images/events/{fileName}";

        return url;
    }
}