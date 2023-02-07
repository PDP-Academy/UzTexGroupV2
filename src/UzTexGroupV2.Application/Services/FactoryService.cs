using Microsoft.EntityFrameworkCore;
using UzTexGroupV2.Application.EntitiesDto.Factory;
using UzTexGroupV2.Application.MappingProfiles;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Application.Services;

public class FactoryService
{
    private readonly LocalizedUnitOfWork localizedUnitOfWork;
    private readonly UnitOfWork unitOfWork;
    private readonly AddressService addressService;

    public FactoryService(LocalizedUnitOfWork localizedUnitOfWork, UnitOfWork unitOfWork, AddressService addressService)
    {
        this.localizedUnitOfWork = localizedUnitOfWork;
        this.unitOfWork = unitOfWork;
        this.addressService = addressService;
    }
    public async ValueTask<FactoryDto> CreateFactoryAsync(CreateFactoryDto createFactoryDto)
    {
        var factory = FactoryMap.MapToFactory(createFactoryDto);
        
        var storedAddress = await this.addressService
            .CreateAddressAsync(createFactoryDto.createAddressDto);
        
        factory.AddressId = storedAddress.id;
        factory.LanguageCode = this.localizedUnitOfWork.FactoryRepository.Language.Code;
        
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
        var factories = await this.localizedUnitOfWork.FactoryRepository
            .GetByExpression(expression: factory => factory.Id == id);

        return FactoryMap.MapToFactoryDto(storageFactory);
    }

    public async ValueTask<FactoryDto> ModifyFactoryAsync(ModifyFactoryDto modifyFactoryDto)
    {
        var factories = await this.localizedUnitOfWork.FactoryRepository
            .GetByExpression(expression: factory => factory.Id == modifyFactoryDto.id);

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
    public async ValueTask<FactoryDto> DeleteEntityAsync(Guid id)
    {
        var factories = await this.localizedUnitOfWork.FactoryRepository
           .GetByExpression(expression: factory => factory.Id == id);

        var deletedFactory = await this.localizedUnitOfWork.FactoryRepository
            .DeleteAsync(entity: storageFactory);

        await this.localizedUnitOfWork.SaveChangesAsync();

        return FactoryMap.MapToFactoryDto(factory : deletedFactory);
    }
}
