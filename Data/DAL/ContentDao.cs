using ASP_.Net_Core_Class_Home_Work.Data.Entities;

namespace ASP_.Net_Core_Class_Home_Work.Data.DAL;

public class ContentDao
{
    private readonly DataContext _context;
    private readonly Object _dbLocker;
    public ContentDao(DataContext context, Object _dbLocker)
    {
        _context = context;
        this._dbLocker = _dbLocker;
    }

    public void AddCategory(string name, string description, string? photoUrl)
    {
        _context.categories.Add(new Category()
        {
            Id = Guid.NewGuid(),
            Name=name,
            Description = description,
            DeletedDt = null,
            PhotoUrl = photoUrl
        });
        _context.SaveChanges();
    }

    public List<Category> GetCategories()
    {
        List<Category> list;
        lock (_dbLocker)
        {
            list = _context.categories.Where(c => c.DeletedDt == null).ToList();
        }

        return list;
    }

    public void UpdateCategory(Category category)
    {
        var ctg = _context.categories.Find(category.Id);
        if (ctg != null)
        {
            ctg.Name = category.Name;
            ctg.Description = category.Description;
            ctg.DeletedDt = category.DeletedDt;
            _context.SaveChanges();
        }
    }

    public void DeleteCategory(Guid id)
    {
        var ctg = _context.categories.Find(id);
        if (ctg != null)
        {
            ctg.DeletedDt = DateTime.Now;
            _context.SaveChanges();
        }
    }
    public void DeleteCategory(Category category)
    {
        DeleteCategory(category.Id);
    }
    public void AddLocation(String name, String description,Guid CategoryId,
        int? Stars = null, Guid? CountryId = null, 
        Guid? CityId = null, string? Address = null, string? PhotoUrl = null)
    {
        lock (_dbLocker)
        {
             _context.locations.Add(new()
             {
                        Id = Guid.NewGuid(),
                        Name = name,
                        Description = description,
                        CategoryId = CategoryId,
                        Stars = Stars,
                        CountryId = CountryId,
                        CityId = CityId,
                        Address = Address,
                        DeleteDt = null,
                        PhotoUrl = PhotoUrl
             });
             _context.SaveChanges();
        }
       
    }

    public List<Location> GetLocations(Guid? categoryId = null)
    {
        var query = _context.locations.Where(loc => loc.DeleteDt == null);
        if (categoryId!=null)
        {
            query = query.Where(loc => loc.CategoryId == categoryId);
        }

        return query.ToList();
    }
}