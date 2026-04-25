using PubHealth.Models;

namespace PubHealth.Services
{
    public interface ISlideService
    {
        Task<List<Slide>> GetAllSlidesAsync();
        Task<Slide?>GetSlideByIdAsync(int id);
         Task<Slide> CreateSlideAsync(Slide slide);
         Task<Slide> UpdateSlideAsync(int id, Slide slide);
         Task<bool> DeleteSlideAsync(int id);
    }
}
