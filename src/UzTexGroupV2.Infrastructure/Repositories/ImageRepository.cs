using Microsoft.AspNetCore.Http;

namespace UzTexGroupV2.Infrastructure.Repositories;

public class ImageRepository
{
    private string folderPath = "C:\\Users\\elchi\\OneDrive\\Desktop\\UzTexGroupV2\\src\\UzTexGroupV2";

    public async ValueTask<string> SaveImageAsync(IFormFile formFile)
    {
        string uploads = Path.Combine(folderPath, "uploads");

        string filePath = "";

        if (formFile.Length > 0)
        {
            filePath = Path.Combine(uploads, formFile.FileName);

            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(fileStream);
            }
        }
        return filePath;
    }
}
