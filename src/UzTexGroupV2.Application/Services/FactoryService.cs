﻿using Microsoft.EntityFrameworkCore;
using System.Data;
using UzTexGroupV2.Application.EntitiesDto;
using UzTexGroupV2.Application.EntitiesDto.Factory;
using UzTexGroupV2.Application.MappingProfiles;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.DbContexts;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Application.Services;

public class FactoryService
{
    private readonly LocalizedUnitOfWork localizedUnitOfWork;
    private readonly AddressService addressService;
    private readonly UzTexGroupDbContext uzTexGroupDbContext;

    public FactoryService(
        LocalizedUnitOfWork localizedUnitOfWork,
        AddressService addressService,
        UzTexGroupDbContext uzTexGroupDbContext)
    {
        this.localizedUnitOfWork = localizedUnitOfWork;
        this.addressService = addressService;
        this.uzTexGroupDbContext = uzTexGroupDbContext;
    }
    public async ValueTask<FactoryDto> CreateFactoryAsync(CreateFactoryDto createFactoryDto)
    {
        var storageFactory = new Factory();
        var executionStrategy = uzTexGroupDbContext.Database.CreateExecutionStrategy();

        await executionStrategy.ExecuteAsync(async () =>
        {
            using (var transaction = uzTexGroupDbContext.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    var factory = FactoryMap.MapToFactory(createFactoryDto);

                    var storedAddress = await this.addressService
                        .CreateAddressAsync(createFactoryDto.createAddressDto);

                    factory.AddressId = storedAddress.id;
                    storageFactory = await this.localizedUnitOfWork
                        .FactoryRepository.CreateAsync(factory);

                    await this.localizedUnitOfWork.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        });
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
        var modifiedFactory = new Factory();
        var executionStrategy = uzTexGroupDbContext.Database.CreateExecutionStrategy();

        await executionStrategy.ExecuteAsync(async () =>
        {
            using (var transaction = uzTexGroupDbContext.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    var storageFactory = await GetByExpressionAsync(modifyFactoryDto.id);

                    FactoryMap.MapToFactory(
                        factory: storageFactory,
                        modifyFactoryDto: modifyFactoryDto);

                    if (modifyFactoryDto.modifyAddressDto is not null)
                        await this.addressService.ModifyAddressAsync(modifyFactoryDto.modifyAddressDto);

                    modifiedFactory = await this.localizedUnitOfWork.FactoryRepository
                        .UpdateAsync(entity: storageFactory);

                    await this.localizedUnitOfWork.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        });
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
           .GetByExpression(
            expression => expression.Id == id,
            new string[] { "Address", "Company"});

        var factory = await factories.FirstOrDefaultAsync();

        Validations.ValidateObjectForNullable(factory);

        return factory;

    }
}
