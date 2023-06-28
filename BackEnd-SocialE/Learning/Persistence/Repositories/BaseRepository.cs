using BackEnd_SocialE.Learning.Persistence.Contexts;

namespace BackEnd_SocialE.Learning.Persistence.Repositories;

public class BaseRepository {
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context) {
        _context = context;
    }
}