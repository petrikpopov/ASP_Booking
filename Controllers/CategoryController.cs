using ASP_.Net_Core_Class_Home_Work.Data.DAL;
using ASP_.Net_Core_Class_Home_Work.Data.Entities;

namespace ASP_.Net_Core_Class_Home_Work.Controllers;
using Microsoft.AspNetCore.Mvc;

[Route("api/category")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly DataAccessor _DataAccessor;

    public CategoryController(DataAccessor dataAccessor)
    {
        _DataAccessor = dataAccessor;
    }

    [HttpGet]
    public List<Category> DoGet()
    {
       return _DataAccessor._ContentDao.GetCategories();
    }

    [HttpPost]
    public string DoPost([FromBody]CategoryPostModel model)
    {
        try
        {
            _DataAccessor._ContentDao.AddCategory(model.Name, model.Description);
            Response.StatusCode = StatusCodes.Status201Created;
            return "Ok";
        }
        catch(Exception exception)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            return "Error";
        }
    }

    public class CategoryPostModel
    {
        public string Name { set; get; }
        public string Description { set; get; }
    }
}