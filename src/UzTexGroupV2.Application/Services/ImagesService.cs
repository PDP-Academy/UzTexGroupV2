/*using Microsoft.AspNetCore.Http;

namespace UzTexGroupV2.Application.Services;

public class ImagesService
{
    public async Task<string> Upload(IFormFile file)
    {
        string uploads = Path.Combine(_hostingEnvironment.ContentRootPath, "uploads");

        string filePath = "";

        if (file.Length > 0)
        {
            filePath = Path.Combine(uploads, file.FileName);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
        }

        return filePath;
    }
}
*/