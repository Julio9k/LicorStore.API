using LiquorStore.Common.Dto;
using LiquorStore.Common.Responses;
using LiquorStore.Infrastructure.Entities;
using Mapster;

namespace LiquorStore.Infrastructure.Mapping;

public static class ProductMappings
{
    public static void Register(TypeAdapterConfig config)
    {
        // From Entity to DTO
        TypeAdapterConfig<Product, ProductDto>.NewConfig();
        // From DTO to Entity

        // From DTO to Response
        TypeAdapterConfig<ProductDto, ProductResponse>.NewConfig()
            .Map(dest => dest.Category, src => src.Category.Name)
            .Map(dest => dest.ProductType, src => src.ProductType.Name);
        // From Entity to Response
        TypeAdapterConfig<Product, ProductResponse>.NewConfig()
            .Map(dest => dest.Category, src => src.Category.Name)
            .Map(dest => dest.ProductType, src => src.ProductType.Name);
    }
}

