using Microsoft.EntityFrameworkCore;
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

        return AddressMap.MapToAddressDto(storedAddress);
    }

    public async ValueTask<AddressDto> DeleteEntityAsync(Guid id)
    {
        var storedAddress = await GetByExpressionAsync(id);

        var deletedAddress = await this.unitOfWork
            .AddressRepository.DeleteAsync(storedAddress);

        return AddressMap.MapToAddressDto(deletedAddress);
    }

    public async ValueTask<AddressDto> ModifyEntityAsync(ModifyAddressDto modifyAddressDto)
    {
        var address = await GetByExpressionAsync(modifyAddressDto.addressId);


        AddressMap.MapToAddress(modifyAddressDto, address);

        var modifiedAddress = await this.unitOfWork
            .AddressRepository.UpdateAsync(address);

        await this.unitOfWork.SaveChangesAsync();

        return AddressMap.MapToAddressDto(modifiedAddress);
    }

    public async ValueTask<IQueryable<AddressDto>> RetrieveAllEntitiesAsync()
    {
        var addresses = await this.unitOfWork
            .AddressRepository.GetAllAsync();

        return addresses.Select(address => AddressMap.MapToAddressDto(address));
    }

    public async ValueTask<AddressDto> RetrieveByIdEntityAsync(Guid id)
    {
        var storedAddress = await GetByExpressionAsync(id);

        return AddressMap.MapToAddressDto(storedAddress);
    }
    private async ValueTask<Address> GetByExpressionAsync(Guid id)
    {
        var addresses = await this.unitOfWork.AddressRepository
           .GetByExpression(expression => expression.Id == id);

        return await addresses.FirstOrDefaultAsync();
    }
}
