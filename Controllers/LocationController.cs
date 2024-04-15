using ASP_.Net_Core_Class_Home_Work.Data.DAL;
using ASP_.Net_Core_Class_Home_Work.Data.Entities;

namespace ASP_.Net_Core_Class_Home_Work.Controllers;
using Microsoft.AspNetCore.Mvc;
[Route("api/category")]
[ApiController]
public class LocationController: ControllerBase
{
    private readonly DataAccessor _dataAccessor;

    public LocationController(DataAccessor dataAccessor)
    {
        _dataAccessor = dataAccessor;
    }

    [HttpGet]
    public List<Location> DoGet(Guid? categoryId)
    {
        return _dataAccessor._ContentDao.GetLocations(categoryId);
    }

    [HttpPost]
    public string DoPost([FromBody] LocationPostModel model)
    {
        try
        {
            _dataAccessor._ContentDao.AddLocation(name:model.Name,description:model.Description,CategoryId:model.CategoryId,Stars:model.Stars);
            Response.StatusCode = StatusCodes.Status201Created;
            return "Ok";
        }
        catch (Exception e)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            return "Error";
        }
    }

    public class  LocationPostModel
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public Guid CategoryId { set; get; }
        public int Stars { set; get; }


    }
}