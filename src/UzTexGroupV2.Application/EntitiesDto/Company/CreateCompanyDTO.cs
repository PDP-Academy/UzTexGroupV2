using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace UzTexGroupV2.Application.EntitiesDto.Company;

public record CreateCompanyDTO: LocalizedDTO
{
    [Required(ErrorMessage = $"{nameof(CreateCompanyDTO.Name)}  berilishi majburiy")]
    [StringLength(15, ErrorMessage = "Ism 15 ta belgida oshmasligi kerak")]
    public string Name { get; set; }
}
