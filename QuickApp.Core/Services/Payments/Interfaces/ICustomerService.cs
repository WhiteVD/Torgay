using QuickApp.Core.DTO;
using QuickApp.Core.Models.Access;
using QuickApp.Core.Models.Payments;

namespace QuickApp.Core.Services.Payments.Interfaces {
    public interface ICustomerService {
        void Add(Customer customer);
        void Delete(Guid id);
        Task<Customer?> Get(Guid id);
        Task<ListResponse> GetList(ClientListQueryParams queryParams);
        void Update(Customer customer);
    }
}
