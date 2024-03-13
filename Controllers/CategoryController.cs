using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibSys.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
       private readonly ICategoryService _categoryService;
      private readonly IStringLocalizer<CategoryController> _localizer;

        public CategoryController(ICategoryService categoryService, IStringLocalizer<CategoryController> localizer)
        {
            _categoryService = categoryService;
            _localizer = localizer;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public ActionResult<ServiceResponse<List<GetCategoryDto>>> GetAll()
        {
            int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);
            return Ok(_categoryService.GetAllCategories());
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public ActionResult<ServiceResponse<GetCategoryDto>> Get(int id)
        {
            return Ok(_categoryService.GetCategoryById(id));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public ActionResult<ServiceResponse<List<GetCategoryDto>>> AddCategory(AddCategoryDto newCategory)
        {
            return Ok(_categoryService.AddCategory(newCategory));
        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public ActionResult<ServiceResponse<List<GetCategoryDto>>> UpdateBook(UpdateCategoryDto updatedCategory)
        {
            var response = _categoryService.UpdateCategory(updatedCategory);
            response.Message = _localizer["ErrorMessage"];
            if (response.Data is null) 
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public ActionResult<ServiceResponse<List<GetCategoryDto>>> DeleteBook(int id)
        {
            var response = _categoryService.DeleteCategory(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
