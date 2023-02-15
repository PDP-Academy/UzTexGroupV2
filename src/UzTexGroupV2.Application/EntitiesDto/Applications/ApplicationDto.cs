using System.ComponentModel.DataAnnotations;
using UzTexGroupV2.Application.EntitiesDto.Addresses;

namespace UzTexGroupV2.Application.EntitiesDto;

public record ApplicationDto(
       
    [Required(ErrorMessage =$"{ nameof(ApplicationDto.id)}  berilishi majburiy")]
    Guid id,

    [Required(ErrorMessage =$"{ nameof(ApplicationDto.firstName)}  berilishi majburiy")]
    [StringLength(15,ErrorMessage ="Ism 15 ta belgida oshmasligi kerak")]
    string firstName,

    [StringLength(15,ErrorMessage ="Familiya 15 ta belgida oshmasligi kerak")]
    string? lastName,

    string phoneNumber,

    [Required(ErrorMessage =$"{nameof(ApplicationDto.applicationMassage)} berilishi majburiy")]
    string applicationMassage,

    [Required(ErrorMessage =$"{nameof(ApplicationDto.email)} berilishi majburiy")]
    [EmailAddress(ErrorMessage ="noto'g'ri email berildi ")]
    string email,


    JobDto? job,

    //[Required(ErrorMessage =$"{nameof(ApplicationDto.addressDto)} berilishi majburiy")]
    AddressDto addressDto);