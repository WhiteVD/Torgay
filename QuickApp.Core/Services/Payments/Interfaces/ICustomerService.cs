using Torgay.Core.DTO;
using Torgay.Core.Models.Access;
using Torgay.Core.Models.Payments;

namespace Torgay.Core.Services.Payments.Interfaces {
    public interface ICustomerService {
        void Add(Customer customer);
        void Delete(Guid id);
        Task<Customer?> Get(Guid id);
        Task<ListResponse> GetList(ClientListQueryParams queryParams);
        void Update(Customer customer);
    }
}
