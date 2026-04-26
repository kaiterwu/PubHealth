using Microsoft.EntityFrameworkCore;
using PubHealth.Data;
using PubHealth.DTOs.SlideDTOs;
using PubHealth.DTOs.TransitionDTOs;
using PubHealth.Models;

namespace PubHealth.Services.TransitionServices
{
    public class TransitionService(AppDbContext context) : ITransitionService
    {
        public Task<GetTransitionResponse> CreateTransitionAsync(Transition transition)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTransitionAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<List<GetTransitionResponse>> GetAllTransitionsAsync()
            => await context.Transitions.Select(t => new GetTransitionResponse
            {
                Id = t.Id,
                ParentSlideId = t.ParentSlideId,
                ChildSlideId = t.ChildSlideId,
                AnswerText1 = t.AnswerText1,
                AnswerText2 = t.AnswerText2
            }).ToListAsync();

        public async Task<GetTransitionResponse?> GetTransitionByIdAsync(int id)
        {
            var currTransition = await context.Transitions
                .Where(t => t.Id == id)
                .Select(t => new GetTransitionResponse
                {
                    Id = t.Id,
                    ParentSlideId = t.ParentSlideId,
                    ChildSlideId = t.ChildSlideId,
                    AnswerText1 = t.AnswerText1,
                    AnswerText2 = t.AnswerText2
                }).FirstOrDefaultAsync();
            return currTransition;
        }

        public Task<GetTransitionResponse> UpdateTransitionAsync(int id, Transition transition)
        {
            throw new NotImplementedException();
        }
    }
}
