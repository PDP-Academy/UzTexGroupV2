using Microsoft.EntityFrameworkCore;
using System.Net;
using UzTexGroupV2.Application.EntitiesDto;
using UzTexGroupV2.Application.EntitiesDto.Addresses;
using UzTexGroupV2.Application.MappingProfiles;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Application.Services;

public class AddressService : IServiceBase<CreateAddressDto, AddressDto, ModifyAddressDto> 
{
    private readonly UnitOfWork unitOfWork;

    public AddressService(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public async ValueTask<AddressDto> CreateEntityAsync(
        CreateAddressDto createAddressDto)
    {
        var address = AddressMap.MapToAddress(createAddressDto, Guid.NewGuid());
        var storedAddress = await unitOfWork
            .AddressRepository.CreateAsync(address);

        await unitOfWork
            .SaveChangesAsync();

        return AddressMap.MapToAddressDto(address);
    }

    public async ValueTask<AddressDto> DeleteEntityAsync(Guid Id)
    {
        var addresses = await this.unitOfWork
            .AddressRepository
            .GetByExpression(expression: address =>
            address.Id == Id);

        var storedAddress = await addresses.FirstOrDefaultAsync();

        var deletedAddress = await this.unitOfWork
            .AddressRepository.DeleteAsync(storedAddress);

        return AddressMap.MapToAddressDto(deletedAddress);
    }

    public async ValueTask<AddressDto> ModifyEntityAsync(ModifyAddressDto modifyAddressDto)
    {
        var addresses = await this.unitOfWork
            .AddressRepository
            .GetByExpression(expression: address =>
            address.Id == modifyAddressDto.addressId);

        var address = await addresses.FirstOrDefaultAsync();

        AddressMap.MapToAddress(modifyAddressDto, address);

        var modifiedAddress = await this.unitOfWork
            .AddressRepository.UpdateAsync(address);

        await this.unitOfWork.SaveChangesAsync();

        return AddressMap.MapToAddressDto(address);
    }

    public async ValueTask<IQueryable<AddressDto>> RetrieveAllEntitiesAsync()
    {
        var addresses = await this.unitOfWork
            .AddressRepository.GetAllAsync();

        return addresses.Select(address => AddressMap.MapToAddressDto(address));
    }

    public async ValueTask<AddressDto> RetrieveByIdEntityAsync(Guid Id)
    {
        var addresses = await this.unitOfWork
            .AddressRepository
            .GetByExpression(expression: address =>
            address.Id == Id);

        var storedAddress = await addresses.FirstOrDefaultAsync();

        return AddressMap.MapToAddressDto(storedAddress);
    }
}
