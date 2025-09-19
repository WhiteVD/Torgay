using Torgay.Core.Models.Account;
using Torgay.Core.Models.Payments;

namespace Torgay.Core.Services.Payments.Interfaces {
    public interface IPaymentService {
        void Add(Payment payment);
        void Delete(Guid id);
        Task<Payment?> Get(Guid id);
        Task<List<Payment>> GetList(ApplicationUser client);
        void Update(Payment payment);
    }
}
