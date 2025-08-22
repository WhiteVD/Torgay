using QuickApp.Core.Models.Payments;

namespace QuickApp.Core.Services.Payments.Interfaces {
    public interface ICustomerAccountService {
        void Add(CustomerAccount customerAccount);
        void Delete(Guid id);
        Task<CustomerAccount?> Get(Guid id);
        Task<List<CustomerAccount>> GetList(Customer customer);
        void Update(CustomerAccount customerAccount);
    }
}
