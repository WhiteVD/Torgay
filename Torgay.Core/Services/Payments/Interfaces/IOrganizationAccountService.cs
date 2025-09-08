using Torgay.Core.Models.Access;
using Torgay.Core.Models.Payments;

namespace Torgay.Core.Services.Payments.Interfaces {
    public interface IOrganizationAccountService {
        void Add(OrganizationAccount organizationAccount);
        void Delete(Guid id);
        Task<OrganizationAccount?> Get(Guid id);
        Task<List<OrganizationAccount>> GetList(Client client);
        void Update(OrganizationAccount organizationAccount);
    }
}
