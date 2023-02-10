using Microsoft.EntityFrameworkCore;
using UzTexGroupV2.Application.EntitiesDto.Addresses;
using UzTexGroupV2.Application.MappingProfiles;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Application.Services;

public class AddressService
{
    private readonly UnitOfWork unitOfWork;

    public AddressService(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public async ValueTask<AddressDto> CreateAddressAsync(
        CreateAddressDto createAddressDto)
    {
        var address = AddressMap.MapToAddress(createAddressDto);

        var storedAddress = await unitOfWork
            .AddressRepository.CreateAsync(address);

        await unitOfWork
            .SaveChangesAsync();

        return AddressMap.MapToAddressDto(storedAddress);
    }

    public async ValueTask<AddressDto> DeleteAddressAsync(Guid id)
    {

        var storedAddress = await GetByExpressionAsync(id);

        var deletedAddress = await this.unitOfWork
            .AddressRepository.DeleteAsync(storedAddress);

        await this.unitOfWork.SaveChangesAsync();

        return AddressMap.MapToAddressDto(deletedAddress);
    }

    public async ValueTask<AddressDto> ModifyAddressAsync(ModifyAddressDto modifyAddressDto)
    {
        var address = await GetByExpressionAsync(modifyAddressDto.addressId);
        
        AddressMap.MapToAddress(modifyAddressDto, address);

        var modifiedAddress = await this.unitOfWork
            .AddressRepository.UpdateAsync(address);

        await this.unitOfWork.SaveChangesAsync();

        return AddressMap.MapToAddressDto(modifiedAddress);
    }

    public async ValueTask<IQueryable<AddressDto>> RetrieveAllAdressesAsync()
    {
        var addresses = await this.unitOfWork
            .AddressRepository.GetAllAsync();

        return addresses.Select(address => AddressMap.MapToAddressDto(address));
    }

    public async ValueTask<AddressDto> RetrieveAddressByIdAsync(Guid id)
    {
        var storedAddress = await GetByExpressionAsync(id);

        return AddressMap.MapToAddressDto(storedAddress);
    }
    private async ValueTask<Address> GetByExpressionAsync(Guid id)
    {
        Validations.ValidateId(id);

        var addresses = await this.unitOfWork.AddressRepository.GetByExpression(
            expression => expression.Id == id,
            new string[] {});

        var address = await addresses.FirstOrDefaultAsync();

        Validations.ValidateObjectForNullable<Address>(address);

        return address;
    }
}
