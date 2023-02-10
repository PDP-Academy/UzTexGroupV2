using Microsoft.EntityFrameworkCore;
using UzTexGroupV2.Application.EntitiesDto.Factory;
using UzTexGroupV2.Application.MappingProfiles;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Application.Services;

public class FactoryService
{
    private readonly LocalizedUnitOfWork localizedUnitOfWork;
    private readonly AddressService addressService;

    public FactoryService(LocalizedUnitOfWork localizedUnitOfWork, AddressService addressService)
    {
        this.localizedUnitOfWork = localizedUnitOfWork;
        this.addressService = addressService;
    }
    public async ValueTask<FactoryDto> CreateFactoryAsync(CreateFactoryDto createFactoryDto)
    {
        
        var factory = FactoryMap.MapToFactory(createFactoryDto);
        
        var storedAddress = await this.addressService
            .CreateAddressAsync(createFactoryDto.createAddressDto);
        
        factory.AddressId = storedAddress.id;
        var storageFactory = await this.localizedUnitOfWork
            .FactoryRepository.CreateAsync(factory);

        await this.localizedUnitOfWork.SaveChangesAsync();

        return FactoryMap.MapToFactoryDto(storageFactory);
    }
    
    public async ValueTask<IQueryable<FactoryDto>> RetrieveAllFactoriesAsync()
    {
        var factories = await this.localizedUnitOfWork.FactoryRepository.GetAllAsync();

        return factories.Select(factory => FactoryMap.MapToFactoryDto(factory));    
    }

    public async ValueTask<FactoryDto> RetrieveFactoryByIdAsync(Guid id)
    {
        var storageFactory = await GetByExpressionAsync(id);

        return FactoryMap.MapToFactoryDto(storageFactory);
    }

    public async ValueTask<FactoryDto> ModifyFactoryAsync(ModifyFactoryDto modifyFactoryDto)
    {
        var storageFactory = await GetByExpressionAsync(modifyFactoryDto.id);

        FactoryMap.MapToFactory(
            factory : storageFactory,
            modifyFactoryDto : modifyFactoryDto);
        
        if (modifyFactoryDto.modifyAddressDto is not null)
            await this.addressService.ModifyAddressAsync(modifyFactoryDto.modifyAddressDto);
       
        var modifiedFactory = await this.localizedUnitOfWork.FactoryRepository
            .UpdateAsync(entity: storageFactory);
        
        await this.localizedUnitOfWork.SaveChangesAsync();

        return FactoryMap.MapToFactoryDto(modifiedFactory);
    }
    public async ValueTask<FactoryDto> DeleteFactoryAsync(Guid id)
    {
        var storageFactory = await GetByExpressionAsync(id);
        
        var deletedFactory = await this.localizedUnitOfWork.FactoryRepository
            .DeleteAsync(entity: storageFactory);

        await this.localizedUnitOfWork.SaveChangesAsync();

        return FactoryMap.MapToFactoryDto(factory : deletedFactory);
    }
    private async ValueTask<Factory> GetByExpressionAsync(Guid id)
    {
        Validations.ValidateId(id);

        var factories = await this.localizedUnitOfWork.FactoryRepository
           .GetByExpression(expression => expression.Id == id);

        Validations.ValidateObjectForNullable(factories);

        return await factories.FirstOrDefaultAsync();
    }
}
