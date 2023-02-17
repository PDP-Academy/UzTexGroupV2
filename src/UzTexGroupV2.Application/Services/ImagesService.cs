using Microsoft.AspNetCore.Http;

namespace UzTexGroupV2.Application.Services;

public static class ImagesService
{
    private static readonly string folderPath = $"{Directory.GetCurrentDirectory()}\\uploads";
    public static string SaveImage(IFormFile formFile, string newsGuid, string langCode)
    {
        string filePath = "";

        if (formFile.Length > 0)
        {
            string[] extension = formFile.FileName.Split('.');

            filePath = Path.Combine(folderPath,
                newsGuid + langCode + $".{extension[extension.Length - 1]}");

            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                formFile.CopyToAsync(fileStream);
            }
        }
        return filePath;
    }
}
