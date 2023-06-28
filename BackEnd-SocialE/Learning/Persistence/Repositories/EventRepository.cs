using BackEnd_SocialE.Learning.Domain.Models;
using BackEnd_SocialE.Learning.Domain.Repositories;
using BackEnd_SocialE.Shared.Persistence.Contexts;
using BackEnd_SocialE.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_SocialE.Learning.Persistence.Repositories;

public class EventRepository : BaseRepository, IEventRepository
{
    public EventRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Event>> ListAsync() {
        return await _context.Events.ToListAsync();
    }

    public async Task AddAsync(Event _event) {
        await _context.Events.AddAsync(_event);
    }

    public async Task<Event> FindByIdAsync(int id) {
        return await _context.Events.FindAsync(id);
    }

    public void Update(Event _event) {
        _context.Events.Update(_event);
    }

    public void Remove(Event _event) {
        _context.Events.Remove(_event);
    }
}