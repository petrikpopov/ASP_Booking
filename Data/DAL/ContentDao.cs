using ASP_.Net_Core_Class_Home_Work.Data.Entities;
using Microsoft.EntityFrameworkCore;

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

    public void AddCategory(string name, string description, string? photoUrl, string? slug=null)
    {
        if (slug == null)
        {
            slug = name;
        }
        lock (_dbLocker)
        {        
            _context.categories.Add(new Category()
            {
                     Id = Guid.NewGuid(),
                     Name=name,
                     Description = description,
                     DeletedDt = null,
                     PhotoUrl = photoUrl,
                     Slug = slug
            });
            _context.SaveChanges();
        }


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

    public Category? GetCategoryBySlug(string slug)
    {
        Category? ctg;
        lock (_dbLocker)
        {
            ctg = _context.categories.FirstOrDefault(c => c.Slug == slug);
        }

        return ctg;
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
        Guid? CityId = null, string? Address = null, string? PhotoUrl = null, string? slug = null)
    {
        if (slug == null)
        {
            slug = name;
        }
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
                        PhotoUrl = PhotoUrl,
                        Slug = slug
             });
             _context.SaveChanges();
        }
       
    }
    public Location? GetLocationBySlug(string slug)
    {
        Location? loc;
        lock (_dbLocker)
        {
            loc = _context.locations.FirstOrDefault(l => l.Slug == slug);
        }

        return loc;
    }
    public List<Location> GetLocations(String categorySlug)
    {
        var ctg = GetCategoryBySlug(categorySlug);
        if(ctg == null)
        {
            return new List<Location>();
        }
        var query = _context
            .locations
            .Where(loc => 
                loc.DeleteDt == null && 
                loc.CategoryId == ctg.Id);  
        return query.ToList();
    }
    public void AddRoom(String name, String description, 

        String photoUrl, String slug, Guid locationId, int stars)
    {

        lock (_dbLocker)

        {
            _context.rooms.Add(new()

            {

                Id = Guid.NewGuid(),

                Name = name,

                Description = description,

                DeleteDt = null,

                PhotoUrl = photoUrl,

                Slug = slug,

                LocationId = locationId,

                Stars = stars

            });

            _context.SaveChanges();

        }

    }

    public List<Room> GetRooms(string locationSlug)
    {
        Location? location;
        lock (_dbLocker)
        {
             location=_context.locations.FirstOrDefault(loc => loc.Slug == locationSlug);
        }
       
        if (location==null)
        {
            throw new Exception("Slug belongs to No location!");
        }

        return GetRooms(location.Id);
    }
    public List<Room> GetRooms(Guid locationId)
    {
        List<Room> res ;
        lock (_dbLocker)
        {
            res = _context.rooms.Where(r => r.LocationId == locationId).ToList();
        }

        return res;
    }

    public Room? GetRoomBySlug(string slug)
    {
        Guid? id;
        try
        {
            id = Guid.Parse(slug);
        }
        catch
        {
            id = null;
        }

        var slugSelector = (Room c) => c.Slug == slug;
        var idSelector = (Room c) => c.Id == id;
        
        Room? rooms;
        lock (_dbLocker)
        {
            rooms = _context.rooms.Include(r=>r.Reservations).FirstOrDefault(id==null?slugSelector:idSelector);
        }

        return rooms;
    }
}