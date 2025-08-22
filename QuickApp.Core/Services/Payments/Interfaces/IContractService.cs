using QuickApp.Core.Models.Access;
using QuickApp.Core.Models.Payments;

namespace QuickApp.Core.Services.Payments.Interfaces {
    public interface IContractService {
        void Add(Contract contract);
        void Delete(Guid id);
        Task<Contract?> Get(Guid id);
        Task<List<Contract>> GetList(Client client);
        void Update(Contract contract);
    }
}
