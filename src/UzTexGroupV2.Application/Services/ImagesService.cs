using Microsoft.AspNetCore.Http;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Application.Services;

public static class ImagesService
{
    private static readonly string folderPath = $"{Directory.GetCurrentDirectory()}\\uploads";
    public static string SaveImage(IFormFile formFile, string newsGuid, string langCode)
    {
        string filePath = "";

        if (formFile.Length > 0)
        {
            filePath = Path.Combine(folderPath, newsGuid + langCode + ".jpg");

            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                formFile.CopyToAsync(fileStream);
            }
        }
        return filePath;
    }
}
