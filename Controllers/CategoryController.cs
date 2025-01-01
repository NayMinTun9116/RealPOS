
using Microsoft.AspNetCore.Mvc;
using RealPOSApi.Controllers;
using RealPOSApi.DTO;
using RealPOSApi.Model;
using RealPOSApi.Repositories;


[ApiController]
[Route("api/[controller]")]
public class CategoryController : BaseController<CategoryController>
{
    private readonly IRepositoryWrapper _repositoryWrapper;
    public CategoryController(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }
    // GET: api/GetAllCategories
    [HttpGet("GetAllCategories", Name = "GetAllCategories")]
    public async Task<List<Category>> GetAllCategories()
    {
        return await _repositoryWrapper.Category.GetAllCategories(0);
    }
    // POST: api/AddCategory
    [HttpPost("SaveCategory", Name = "SaveCategory")]
    public async Task<CategoryRespondDTO> AddCategory(CategoryDTO param)
    {
        try
        {
            if (!await _repositoryWrapper.Category.CheckDuplicate(param.Category))
            {
                int Maxid = await _repositoryWrapper.Category.MaxCategoryID(0);
                Category newobj = new Category
                {
                    category_id = Maxid,
                    category = param.Category,
                    expired_day = param.Exprired_day
                };
                await _repositoryWrapper.Category.Create(newobj);
                return new CategoryRespondDTO { Message = "Category Save Successfully" };
            }
            else
            {
                return new CategoryRespondDTO { Message = "Category Already Exist" };
            }
        }
        catch (Exception ex)
        {
            return new CategoryRespondDTO { Message = "Error in AddCategory", Error = "Error in AddCategory" };
        }
    }
    // POST: api/UpdateCategory
    [HttpPost("UpdateCategory", Name = "UpdateCategory")]
    public async Task<CategoryRespondDTO> UpdateCategory(UpdateCategoryRequestDTO param)
    {
        try
        {
            var OldCategory = await _repositoryWrapper.Category.OldCategory(param.CategoryID, 0);
            if (OldCategory == null)
            {
                return new CategoryRespondDTO { Message = "Category does not exist" };
            }
            else
            {
                OldCategory.category = param.Category;
                OldCategory.expired_day = param.Exprired_day;
                await _repositoryWrapper.Category.Update(OldCategory);
                return new CategoryRespondDTO { Message = "Category update successfull" };
            }
        }
        catch (Exception ex)
        {
            return new CategoryRespondDTO { Message = "Error in UpdateCategory", Error = "Error in UpdateCategory" };
        }
    }
    // POST: api/DeleteCategory/1
    [HttpPost("DeleteCategory/{categoryid}", Name = "DeleteCategory")]
    public async Task<CategoryRespondDTO> DeleteCategory(int categoryid)
    {
        try
        {
            Category? OldCategory = await _repositoryWrapper.Category.OldCategory(categoryid, 0);
            if (OldCategory == null)
            {
                return new CategoryRespondDTO { Message = "Category does not exist" };
            }
            else
            {
                await _repositoryWrapper.Category.Delete(OldCategory);
                return new CategoryRespondDTO { Message = "Category delete successfull" };
            }
        }
        catch (Exception ex)
        {
            return new CategoryRespondDTO { Message = "Error in UpdateCategory", Error = "Error in UpdateCategory" };
        }
    }
}