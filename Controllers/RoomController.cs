using ASP_.Net_Core_Class_Home_Work.Data.DAL;
using ASP_.Net_Core_Class_Home_Work.Models.Content.Location;
using ASP_.Net_Core_Class_Home_Work.Models.Content.Room;

namespace ASP_.Net_Core_Class_Home_Work.Controllers;
using Microsoft.AspNetCore.Mvc;

[Route("api/room")]
[ApiController]
public class RoomController: ControllerBase
{
    private readonly DataAccessor _dataAccessor;

    public RoomController(DataAccessor _dataAccessor)
    {
        this._dataAccessor = _dataAccessor;
    }

    [HttpPost]
    public string DoPost( [FromForm] RoomFormModel model)
    {
        try
        {
            String? fileName = null;
            if (model.Photo != null)
            {
                String ext = Path.GetExtension(model.Photo.FileName);
                String path = Directory.GetCurrentDirectory() + "/wwwroot/img/content/";
                String pathName;
                do
                {
                    fileName = Guid.NewGuid() + ext;
                    pathName = path + fileName;
                }
                while (System.IO.File.Exists(pathName));
                using var stream = System.IO.File.OpenWrite(pathName);
                model.Photo.CopyTo(stream);
            }
            if (fileName == null)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return "File Image required";
            }
            _dataAccessor._ContentDao.AddRoom(
                name: model.Name,
                description: model.Description,
                photoUrl: fileName,
                slug: model.Slug,
                locationId: model.LocationyId,
                stars: model.Stars);
            Response.StatusCode = StatusCodes.Status201Created;
            return "Added";
        }
        catch (Exception ex)
        {
            Response.StatusCode = StatusCodes.Status500InternalServerError;
            return ex.Message;
        }
  
    }

    [HttpPost("reserve")]
    public string ReserveRoom([FromBody]ReserveRoomFormModel model)
    {
        return $"{model.UserId}, {model.RoomId}, {model.Date}";
    }
}