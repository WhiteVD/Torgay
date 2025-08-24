using Torgay.Core.Models.Access;
using Torgay.Core.Models.Payments;

namespace Torgay.Core.Services.Payments.Interfaces {
    public interface IPaymentService {
        void Add(Payment payment);
        void Delete(Guid id);
        Task<Payment?> Get(Guid id);
        Task<List<Payment>> GetList(Client client);
        void Update(Payment payment);
    }
}
