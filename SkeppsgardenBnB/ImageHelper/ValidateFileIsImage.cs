namespace ImageHelper;
using Microsoft.AspNetCore.Http;

public class ValidateFileIsImage
{
    public bool Validate(IFormFile file)
    {
        // Check if the file is an image
        var allowedContentTypes = new[] { "image/jpeg", "image/png", "image/gif" };
        return allowedContentTypes.Contains(file.ContentType);
    }
}