using BackEnd_SocialE.Learning.Domain.Models;
using BackEnd_SocialE.Learning.Domain.Services.Communication;

namespace BackEnd_SocialE.Learning.Domain.Services;

public interface IPaymentService
{
    Task<IEnumerable<Payment>> ListAsync();
    Task<List<Payment>> ListByUserIdAsync(int UserId);
    Task<List<Payment>> ListByEventIdAsync(int EventId);
    Task<PaymentResponse> SaveAsync(Payment payment);
    Task<PaymentResponse> UpdateAsync(int id, Payment payment);
    Task<PaymentResponse> DeleteAsync(int id);
}