using Short_URL_System.Models;

namespace Short_URL_System.Interfaces
{
    public interface IMainRepository
    {
        bool IsTextUsed(string text);
        Task<Website> CreateAsync(Website website);
        Task<string?> GetURLAsync(string shortUrlString);
    }
}
