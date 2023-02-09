using System.ComponentModel.DataAnnotations;

namespace UzTexGroupV2.Application.EntitiesDto.Company;

public record ModifyCompanyDTO : LocalizedDTO
{
    [Required(ErrorMessage = $"{nameof(ModifyCompanyDTO.Id)}  berilishi majburiy")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = $"{nameof(ModifyCompanyDTO.Name)}  berilishi majburiy")]
    [StringLength(15, ErrorMessage = "Ism 15 ta belgida oshmasligi kerak")]
    public string? Name { get; set; }
}