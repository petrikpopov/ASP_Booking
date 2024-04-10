using ASP_.Net_Core_Class_Home_Work.Services.Kdf;

namespace ASP_.Net_Core_Class_Home_Work.Data.DAL;

public class DataAccessor
{
    public readonly DataContext _dataContext;
    private readonly IKdfService _kdfService;
    public UserDao UserDao { get; private set; }

    public DataAccessor(DataContext dataContext, IKdfService kdfService)
    {
        _dataContext = dataContext;
        _kdfService = kdfService;
        UserDao = new UserDao(dataContext, kdfService);
    }
}