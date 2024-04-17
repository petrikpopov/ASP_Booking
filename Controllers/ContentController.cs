using ASP_.Net_Core_Class_Home_Work.Data.DAL;
using ASP_.Net_Core_Class_Home_Work.Models.Content.Index;
using Microsoft.AspNetCore.Mvc;

namespace ASP_.Net_Core_Class_Home_Work.Controllers;

public class ContentController : Controller
{
    public DataAccessor dataAccessor;
    public ContentController(DataAccessor dataAccessor)
    {
        this.dataAccessor = dataAccessor;
    }

    // GET
    public IActionResult Index()
    {
        ContentIndexPageModel model = new()
        {
            categories = dataAccessor._ContentDao.GetCategories()
        };
        return View(model);
    }

    public IActionResult Category([FromRoute]Guid id)
    {
        return View();
    }
}