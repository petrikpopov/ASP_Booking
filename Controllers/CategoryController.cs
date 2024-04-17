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
    public string DoPost([FromForm]CategoryPostModel model)
    {
        try
        {
            String fileName = null;
            if (model.Photo != null)
            {
                
                
                String ext = Path.GetExtension(model.Photo.FileName);
                String path = Directory.GetCurrentDirectory() + "/wwwroot/img/Content/";
                    
                String pathName;
                do
                {
                    fileName = Guid.NewGuid() + ext;
                    pathName = path + fileName;
                } while (System.IO.File.Exists(pathName));
                using var stream = System.IO.File.OpenWrite(pathName);
                model.Photo.CopyTo(stream);
                                    
                

               
            }
            _DataAccessor._ContentDao.AddCategory(model.Name, model.Description, fileName);
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
        public IFormFile? Photo { set; get; }
    }
}