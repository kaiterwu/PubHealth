using PubHealth.DTOs.TransitionDTOs;
using PubHealth.Models;

namespace PubHealth.Services.TransitionServices
{
    public interface ITransitionService
    {
        Task<List<GetTransitionResponse>> GetAllTransitionsAsync();
        Task<GetTransitionResponse?> GetTransitionByIdAsync(int id);
        Task<GetTransitionResponse> CreateTransitionAsync(Transition transition);
        Task<GetTransitionResponse> UpdateTransitionAsync(int id, Transition transition);
        Task<bool> DeleteTransitionAsync(int id);
    }
}
