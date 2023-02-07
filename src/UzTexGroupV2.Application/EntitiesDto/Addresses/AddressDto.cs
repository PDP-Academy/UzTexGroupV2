using System.ComponentModel.DataAnnotations;

namespace UzTexGroupV2.Application.EntitiesDto.Addresses;
public record AddressDto(
    [Required(ErrorMessage =$"{ nameof(AddressDto.id)}  berilishi majburiy")] 
     Guid id,

    [Required(ErrorMessage =$"{nameof(AddressDto.country)} Berilishi majburiy")]
    [StringLength(50,ErrorMessage =$"Davlat nomi uzunligi 50 ta belgidan oshmasligi kerak")]
    string country,

    [Required(ErrorMessage =$"{nameof(AddressDto.region)} berilishi majburiy")]
    [StringLength(100,ErrorMessage =$"Viloyat nomi uzunligi 100 ta belgidan oshmasligi kerak")]
    string region,

    [Required(ErrorMessage =$"{nameof(AddressDto.district)} berilishi majburiy")]
    [StringLength(100,ErrorMessage =$"Tuman nomi uzunligi 100 ta belgidan oshmasligi kerak")]
    string district,

    [Required(ErrorMessage =$"{nameof(AddressDto.street)} berilishi majburiy")]
    [StringLength(100,ErrorMessage =$"Kocha nomi uzunligi 100 ta belgidan oshmasligi kerak")]
    string street,

    [Required(ErrorMessage =$"{nameof(AddressDto.postalCode)} berilishi majburiy")]
    short postalCode);