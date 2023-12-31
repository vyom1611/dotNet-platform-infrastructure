using PlatformService.Models;

namespace PlatformService.Data;

public class PlatformRepo : IPlatformRepo
{
    private readonly AppDbContext _context;

    public PlatformRepo(AppDbContext context)
    {
        _context = context;
    }
    
    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }

    public IEnumerable<Platform> getAllPlatforms()
    {
        return _context.Platforms.ToList();
    }

    public Platform getPlatformById(int id)
    {
        return _context.Platforms.FirstOrDefault(p => p.Id == id);
    }

    public void CreatePlatform(Platform plat) 
    {
        if (plat == null)
        {
            throw new ArgumentNullException(nameof(plat));
        }
        
        _context.Platforms.Add(plat);
        
    }
    
    public void DeletePlatform(int id)
    {
        if (id == 0)
        {
            throw new ArgumentNullException(nameof(id));
        }

        _context.Platforms.Remove(_context.Platforms.FirstOrDefault(p => p.Id == id));
        _context.SaveChanges();
    }
}