namespace LibSys
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, GetCategoryDto>();
            CreateMap<GetCategoryDto, Category>();
            CreateMap<AddCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Book, GetBookDto>();
            CreateMap<GetBookDto, Book>();
            CreateMap<AddBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();
            
            

        }
    }
}
