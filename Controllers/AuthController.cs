using ASP_.Net_Core_Class_Home_Work.Data.DAL;
using ASP_.Net_Core_Class_Home_Work.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ASP_.Net_Core_Class_Home_Work.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{ 
    private readonly DataAccessor _dataAccessor;
    public AuthController(DataAccessor dataAccessor)
    {
        _dataAccessor = dataAccessor;
    }

   
    [HttpGet]
    public object Get(string email, string password)
    {
        var user = _dataAccessor.UserDao.Authorize(email, password);
        if (user == null)
        {
            Response.StatusCode = StatusCodes.Status401Unauthorized;
            return new { Status = "Auth failed" };
        }
        else
        {
            return user;

        }
        
    }
    [HttpPost]
    public object Post()
    {
        return new { Status = "Post work" };
    }
    [HttpPut]
    public object Put()
    {
        return new { Status = "Put work" };
    }
}
// Контроллери поділяються на 2 групи - API та MVC
// MVC: мають багато Action, кожен з яких запускається своїм Route
// /Home/Ioc ---> public ViewResult Ioc(){...}
// /Home/Form ---> public ViewResult Form(){...}
// при цьому метод затипу ролі не грає, можливо лише обмежити за перелік
// GET /Home/Ioc , POST /Home/Form, ---> public ViewResult Ioc()
// -повернення - IActionResunt, частіше за все ViewResult


//API
// - мають одну адресу [Route("api/auth")], а різні діі запускаються різними методами запитів
// GET api/auth -->
// POST api/auth -->
// PUT api/auth -->
// вся відмінність - у методі запиту, неможна потрапити до одного Action різними методами
// - повернення - дані, які автоматично перетворюються або в текс або в json (якщо тип повернення String - text/plain, якщо інший object, List<...> , User --aplication/json)