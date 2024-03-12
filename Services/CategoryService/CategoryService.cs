
using LibSys.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibSys.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CategoryService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public ServiceResponse<List<GetCategoryDto>> AddCategory(AddCategoryDto newCategory)
        {
            var serviceResponse = new ServiceResponse<List<GetCategoryDto>>();
            var category = _mapper.Map<Category>(newCategory);

            _context.Categories.Add(category);
            _context.SaveChanges();

            serviceResponse.Data = _context.Categories.Select(c => _mapper.Map<GetCategoryDto>(c)).ToList();
            return serviceResponse;
        }

        public ServiceResponse<List<GetCategoryDto>> DeleteCategory(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCategoryDto>>();
            try
            {
                var category = _context.Categories.FirstOrDefault(c => c.Id == id);
                if (category == null)
                {
                    throw new Exception($"Category with Id '{id}' not found!");
                }

                _context.Categories.Remove(category);
                _context.SaveChanges();

                serviceResponse.Data = _context.Categories.Select(c => _mapper.Map<GetCategoryDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public ServiceResponse<List<GetCategoryDto>> GetAllCategories()
        {
            var serviceResponse = new ServiceResponse<List<GetCategoryDto>>();
            var dbCategories = _context.Categories.ToList();
            serviceResponse.Data = dbCategories.Select(c => _mapper.Map<GetCategoryDto>(c)).ToList();
            return serviceResponse;
        }

        public ServiceResponse<GetCategoryDto> GetCategoryById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCategoryDto>();
            var dbCategory = _context.Categories.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCategoryDto>(dbCategory);
            return serviceResponse;
        }

        public ServiceResponse<GetCategoryDto> UpdateCategory(UpdateCategoryDto updatedCategory)
        {
            var serviceResponse = new ServiceResponse<GetCategoryDto>();
            try
            {
                var category = _context.Categories.FirstOrDefault(c => c.Id == updatedCategory.Id);
                if (category == null)
                {
                    throw new Exception($"Category with Id '{updatedCategory.Id}' not found!");
                }


                _mapper.Map(updatedCategory, category);

                _context.SaveChanges();

                serviceResponse.Data = _mapper.Map<GetCategoryDto>(category);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
