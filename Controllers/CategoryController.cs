using Dapper;
using Microsoft.AspNetCore.Mvc;
using RealPOSApi.DTO;
using RealPOSApi.Model;


[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly AppDb _context;
    public CategoryController(AppDb context)
    {
        _context = context;
    }
    // GET: api/allcategory
    [HttpGet("GetAllCategories", Name = "GetAllCategories")]
    public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
    {
        return await _context.GetAll<Category>("SELECT * FROM tbcategory;", new
        DynamicParameters());
    }
    // POST: api/AddCategory
    [HttpPost("AddCategory", Name = "AddCategory")]
    public async Task<ActionResult<Category>> AddCategory(CategoryDTO category)
    {
        string query = "INSERT INTO tbcategory (category_id,category, expired_day) VALUES(@category_id, @category, @expired_day);";
        await _context.EditData(query, category);
        return Created(nameof(GetAllCategories), category);
    }
    // PUT: api/UpdateCategory
    [HttpPut("UpdateCategory", Name = "UpdateCategory")]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryRequestDTO category)
    {
        string query = "UPDATE category SET category = @category WHERE category_id =@category_id; ";
        await _context.EditData(query, category);
        return Ok(category);
    }
    // DELETE: api/DeleteCategory/1
    [HttpDelete("DeleteCategory/{categoryid}", Name = "DeleteCategory")]
    public async Task<IActionResult> DeleteCategory(int categoryid)
    {
        string query = "DELETE FROM book WHERE book_id = @id;";
        await _context.EditData(query, new { id = categoryid });
        return Ok();
    }
}