using QuickApp.Core.Models.Access;
using QuickApp.Core.Models.Payments;

namespace QuickApp.Core.Services.Payments.Interfaces {
    public interface IOrganizationAccountService {
        void Add(OrganizationAccount organizationAccount);
        void Delete(Guid id);
        Task<OrganizationAccount?> Get(Guid id);
        Task<List<OrganizationAccount>> GetList(Client client);
        void Update(OrganizationAccount organizationAccount);
    }
}
