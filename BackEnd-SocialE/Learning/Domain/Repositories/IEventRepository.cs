using BackEnd_SocialE.Learning.Domain.Models;

namespace BackEnd_SocialE.Learning.Domain.Repositories;

public interface IEventRepository
{
    Task<IEnumerable<Event>> ListAsync();
    Task AddAsync(Event _event);
    Task<Event> FindByIdAsync(int id);
    void Update(Event _event);
    void Remove(Event _event);
}