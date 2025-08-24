using Torgay.Core.Models.Payments;

namespace Torgay.Core.Services.Payments.Interfaces {
    public interface ICustomerAccountService {
        void Add(CustomerAccount customerAccount);
        void Delete(Guid id);
        Task<CustomerAccount?> Get(Guid id);
        Task<List<CustomerAccount>> GetList(Customer customer);
        void Update(CustomerAccount customerAccount);
    }
}
