using Microsoft.EntityFrameworkCore;
using UzTexGroupV2.Application.EntitiesDto.Factory;
using UzTexGroupV2.Application.MappingProfiles;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Application.Services;

public class FactoryService : IServiceBase<CreateFactoryDto, FactoryDto, ModifyFactoryDto>
{
    private readonly LocalizedUnitOfWork localizedUnitOfWork;
    private readonly UnitOfWork unitOfWork;

    public FactoryService(LocalizedUnitOfWork localizedUnitOfWork, UnitOfWork unitOfWork)
    {
        this.localizedUnitOfWork = localizedUnitOfWork;
        this.unitOfWork = unitOfWork;
    }
    public async ValueTask<FactoryDto> CreateEntityAsync(CreateFactoryDto createFactoryDto)
    {
        var factory = FactoryMap.MapToFactory(createFactoryDto);

        var factoryAdress = AddressMap.MapToAddress(
            createFactoryDto.createAddressDto,
            factory.AddressId);

        var storageFactory = await this.localizedUnitOfWork
            .FactoryRepository.CreateAsync(factory);

        await this.unitOfWork.AddressRepository.CreateAsync(factoryAdress);

        await this.localizedUnitOfWork.SaveChangesAsync();
        await this.unitOfWork.SaveChangesAsync();

        return FactoryMap.MapToFactoryDto(storageFactory);
    }


    public async ValueTask<IQueryable<FactoryDto>> RetrieveAllEntitiesAsync()
    {
        var factories = await this.localizedUnitOfWork.FactoryRepository.GetAllAsync();

        return factories.Select(factory => FactoryMap.MapToFactoryDto(factory));    
    }

    public async ValueTask<FactoryDto> RetrieveByIdEntityAsync(Guid id)
    {
        var factories = await this.localizedUnitOfWork.FactoryRepository
            .GetByExpression(expression: factory => factory.Id == id);

        var storageFactory = await factories.FirstOrDefaultAsync();

        return FactoryMap.MapToFactoryDto(storageFactory);
    }

    public async ValueTask<FactoryDto> ModifyEntityAsync(ModifyFactoryDto modifyFactoryDto)
    {
        var factories = await this.localizedUnitOfWork.FactoryRepository
            .GetByExpression(expression: factory => factory.Id == modifyFactoryDto.id);

        var storageFactory = await factories.FirstOrDefaultAsync();

        FactoryMap.MapToFactory(
            factory : storageFactory,
            modifyFactoryDto : modifyFactoryDto);

        var modifiedFactory = await this.localizedUnitOfWork.FactoryRepository
            .UpdateAsync(entity: storageFactory);

        this.localizedUnitOfWork.SaveChangesAsync();

        return FactoryMap.MapToFactoryDto(modifiedFactory);
    }
    public async ValueTask<FactoryDto> DeleteEntityAsync(Guid id)
    {
        var factories = await this.localizedUnitOfWork.FactoryRepository
           .GetByExpression(expression: factory => factory.Id == id);

        var storageFactory = await factories.FirstOrDefaultAsync();

        var deletedFactory = await this.localizedUnitOfWork.FactoryRepository
            .DeleteAsync(entity: storageFactory);

        await this.localizedUnitOfWork.SaveChangesAsync();

        return FactoryMap.MapToFactoryDto(factory : deletedFactory);
    }
}
