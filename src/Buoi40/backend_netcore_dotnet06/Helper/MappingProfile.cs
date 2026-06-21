using AutoMapper;

namespace backend_netcore_dotnet06.Helper;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // proModel.Alias = Helper.GenerateAlias(newproduct.Name);
        // proModel.Deleted = false;
        // proModel.CreatedAt = DateTime.Now;
        // proModel.UpdatedAt = DateTime.Now;
        CreateMap<ProductInsertDTO, Product>()
        .ForMember(dest => dest.Alias, opt => opt.MapFrom(src => HelperFunction.StringToSlug(src.Name)))
        .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => false))
        .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
        .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));


        CreateMap<ProductUpdate, Product>().ReverseMap();
    }
}