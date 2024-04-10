using ASP_.Net_Core_Class_Home_Work.Data.Entities;
using ASP_.Net_Core_Class_Home_Work.Services.Kdf;

namespace ASP_.Net_Core_Class_Home_Work.Data.DAL;

public class UserDao
{
    public readonly DataContext _DataContext;
    private readonly IKdfService _kdfService;
    public UserDao(DataContext dataContext, IKdfService kdfService)
    {
        _DataContext = dataContext;
        _kdfService = kdfService;
    }

    public User? Authorize(string email, string password)
    {
        var user = _DataContext.users.FirstOrDefault(u => u.Email == email);
        if (user == null || user.DerivedKey != _kdfService.DerivedKey(user.Salt, password))
        {
            return null;
        }
        return user;
        
    }

    public void SignUp(User user)
    {
        if (user.Id == default)
        {
            user.Id = Guid.NewGuid();
        }

        _DataContext.users.Add(user);
        _DataContext.SaveChanges();
    }
}
// DAL - (Data Access Layer) - сукупність усіх DAO
// DAO - (Data Access Object) - нфбір методів для роботи з сутністю