using System.ComponentModel.DataAnnotations;
using UzTexGroupV2.Application.EntitiesDto.Application;
using UzTexGroupV2.Application.EntitiesDto.Factory;

namespace UzTexGroupV2.Application.EntitiesDto;

public record JobDto(

    [Required(ErrorMessage = $"{nameof(JobDto.id)}  berilishi majburiy")]
    Guid id,

    [Required(ErrorMessage =$"{ nameof(JobDto.name)}  berilishi majburiy")]
    [StringLength(15,ErrorMessage ="Ism 15 ta belgida oshmasligi kerak")]
    string name,

    [Required(ErrorMessage =$"{ nameof(JobDto.description)}  berilishi majburiy")]
    string description,

    [Required(ErrorMessage =$"{ nameof(JobDto.workTime)}  berilishi majburiy")]
    string workTime,

    [Required(ErrorMessage =$"{ nameof(JobDto.salary)}  berilishi majburiy")]
    decimal salary,

    FactoryDto? factoryDto);
