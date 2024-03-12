namespace LibSys.Services.CategoryService
{
    public interface ICategoryService
    {
        ServiceResponse<List<GetCategoryDto>> GetAllCategories();
        ServiceResponse<GetCategoryDto> GetCategoryById(int id);
        ServiceResponse<List<GetCategoryDto>> AddCategory(AddCategoryDto newCategory);
        ServiceResponse<GetCategoryDto> UpdateCategory(UpdateCategoryDto updatedCategory);
        ServiceResponse<List<GetCategoryDto>> DeleteCategory(int id);
    }
}
