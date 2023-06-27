using BackEnd_SocialE.Learning.Domain.Models;
using BackEnd_SocialE.Learning.Domain.Services.Communication;

namespace BackEnd_SocialE.Learning.Domain.Services;

public interface IEventService
{
    Task<IEnumerable<Event>> ListAsync();
    Task<EventResponse> SaveAsync(Event _event);
    Task<EventResponse> UpdateAsync(int id, Event _event);
    Task<EventResponse> DeleteAsync(int id);
}