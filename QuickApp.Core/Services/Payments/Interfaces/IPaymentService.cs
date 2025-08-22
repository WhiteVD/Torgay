using QuickApp.Core.Models.Access;
using QuickApp.Core.Models.Payments;

namespace QuickApp.Core.Services.Payments.Interfaces {
    public interface IPaymentService {
        void Add(Payment payment);
        void Delete(Guid id);
        Task<Payment?> Get(Guid id);
        Task<List<Payment>> GetList(Client client);
        void Update(Payment payment);
    }
}
