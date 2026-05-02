using PubHealth.DTOs.SlideDTOs;
using PubHealth.Models;

namespace PubHealth.Services.SlideServices
{
    public interface ISlideService
    {
        Task<List<GetSlideResponse>> GetAllSlidesAsync();
        Task<GetSlideResponse?>GetSlideByIdAsync(int id);
        Task<GetSlideResponse?> GetFirstSlideByCategoryAsync(string category);
        Task<GetSlideWithTransitionsResponse?> GetSlideWithTransitionsAsync(int slideId);
        Task<GetSlideResponse> CreateSlideAsync(CreateSlideRequest slide);
        Task<GetSlideResponse> UpdateSlideAsync(int id, UpdateSlideRequest slide);
         Task<bool> DeleteSlideAsync(int id);
    }
}
