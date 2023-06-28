using BackEnd_SocialE.Learning.Domain.Repositories;
using BackEnd_SocialE.Learning.Persistence.Contexts;

namespace BackEnd_SocialE.Learning.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork {
    private readonly AppDbContext _context;
    
    public UnitOfWork(AppDbContext context){
        _context = context;
    }
    
    public async Task CompleteAsync() {
        await _context.SaveChangesAsync();
    }
}