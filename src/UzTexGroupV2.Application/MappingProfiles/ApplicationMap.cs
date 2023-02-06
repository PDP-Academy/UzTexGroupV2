using UzTexGroupV2.Application.EntitiesDto.Application;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Application.MappingProfiles;

internal static class ApplicationMap
{
    internal static Applications MapToApplication(CreateApplicationDto createApplicationDto)
    {
        return new Applications
        {
            Id = Guid.NewGuid(),
            FirstName = createApplicationDto.firstName,
            LastName = createApplicationDto.lastName,
            Email = createApplicationDto.email,
            PhoneNumber = createApplicationDto.phoneNumber,
            ApplicationMessage = createApplicationDto.applicationMassage,
            AddressId = Guid.NewGuid(),
            JobId = createApplicationDto.jobId
        };
    }
    internal static ApplicationDto MapToApplicationDto(Applications applications)
    {
        return new ApplicationDto
        (
            id: applications.Id,
            firstName: applications.FirstName,
            lastName: applications.LastName,
            email: applications.Email,
            applicationMassage: applications.ApplicationMessage,
            phoneNumber: applications.PhoneNumber,
            job: JobMap.MapToJobDto(applications.Job),
            addressDto : 
       ); 
    }
}
