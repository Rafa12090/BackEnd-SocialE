using BackEnd_SocialE.Learning.Domain.Models;

namespace BackEnd_SocialE.Learning.Domain.Repositories;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> ListAsync();
    Task AddAsync(Payment payment);
    Task<Payment> FindByIdAsync(int id);
    Task<List<Payment>> FindByUserIdAsync(int UserId);
    Task<List<Payment>> FindByEventIdAsync(int EventId);
    void Update(Payment payment);
    void Remove(Payment payment);
}