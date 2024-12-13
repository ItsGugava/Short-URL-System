using Microsoft.EntityFrameworkCore;
using Short_URL_System.Data;
using Short_URL_System.Interfaces;
using Short_URL_System.Models;

namespace Short_URL_System.Repositories
{
    public class MainRepository : IMainRepository
    {
        private readonly ApplicationDbContext _context;

        public MainRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Website> CreateAsync(Website website)
        {
            await _context.Websites.AddAsync(website);
            await _context.SaveChangesAsync();
            return website;
        }

        public async Task<string?> GetURLAsync(string shortUrlString)
        {
            Website? website = await _context.Websites.FirstOrDefaultAsync(w => w.ShortText.Equals(shortUrlString));
            if (website == null)
            {
                return null;
            }
            website.VisitCount += 1;
            await _context.SaveChangesAsync();
            return website.URL;
        }

        public bool IsTextUsed(string text)
        {
            return _context.Websites.Any(w => w.ShortText.Equals(text));
        }
    }
}
