using System.ComponentModel.DataAnnotations;
using UzTexGroupV2.Application.EntitiesDto.Company;

namespace UzTexGroupV2.Application.EntitiesDto;

public record LocalizedDTO
{
    [Required(ErrorMessage = $"{nameof(LocalizedDTO)}  berilishi majburiy")]
    [StringLength(5, ErrorMessage = "Language 5 ta belgida oshmasligi kerak")]
    public string LanguageCode { get; set; }
}
