using Microsoft.AspNetCore.Http;

namespace UzTexGroupV2.Application.Services;

public static class ImagesService
{
    private static readonly string folderPath = $"{Directory.GetCurrentDirectory()}\\uploads";
    public static string SaveImage(IFormFile formFile, string newsGuid)
    {
        string filePath = "";

        if (formFile.Length > 0)
        {
            filePath = Path.Combine(folderPath, newsGuid + ".jpg");

            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                formFile.CopyToAsync(fileStream);
            }
        }
        return filePath;
    }
}
