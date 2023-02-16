using Microsoft.AspNetCore.Http;

namespace UzTexGroupV2.Application.Services;

public static class ImagesService
{
    private const string folderPath = "C:\\Users\\elchi\\OneDrive\\Desktop\\UzTexGroupV2\\src\\UzTexGroupV2\\uploads";
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
