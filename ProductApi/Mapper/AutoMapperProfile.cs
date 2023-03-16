namespace ProductApi.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<NewProductDto, Product>().
                ForMember(destination => destination.TotalPrice,
                    option => option.MapFrom(required => required.Price - (required.Price * required.Discount / 100))).
                ForMember(destination => destination.CreatedDate,
                    option => option.MapFrom(required => DateTimeOffset.UtcNow));
            
            CreateMap<UpdateProductDto, Product>().
                ForMember(destination => destination.TotalPrice,
                    option => option.MapFrom(required => required.Price - (required.Price * required.Discount / 100))).
                ForMember(destination => destination.Id,
                    option => option.Ignore()).
                ForMember(destination => destination.CreatedDate,
                    option => option.Ignore());
        }
    }
}