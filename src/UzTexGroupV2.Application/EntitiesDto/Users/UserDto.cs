using System.ComponentModel.DataAnnotations;
using UzTexGroupV2.Domain.Enums;

namespace UzTexGroupV2.Application.EntitiesDto;

public record UserDto(
    [Required(ErrorMessage =$"{nameof(UserDto.id)} berilishi kerak")]
    Guid id,

    [Required(ErrorMessage =$"{nameof(UserDto.firstName)} berilishi majburiy ")]
    [MaxLength(15,ErrorMessage =$"Ismning uzunligi 15 tabelgidan kam bo'lishi kerak")]
    string firstName,

    [Required(ErrorMessage =$"{nameof(UserDto.lastName)} berilishi majburiy ")]
    [MaxLength(15,ErrorMessage =$"Familiyaning uzunligi 15 tabelgidan kam bo'lishi kerak")]
    string lastName,

    [Required(ErrorMessage =$"{nameof(UserDto.email)} berilishi majburiy ")]
    [EmailAddress(ErrorMessage =$"Email noto'g'ri kiritildi")]
    string email,

    [Required(ErrorMessage ="role berish majburiy")]
    Role role);