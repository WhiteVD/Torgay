using Torgay.Core.Models.Account;
using Torgay.Core.Models.Payments;

namespace Torgay.Core.Services.Payments.Interfaces {
    public interface IContractService {
        void Add(Contract contract);
        void Delete(Guid id);
        Task<Contract?> Get(Guid id);
        Task<List<Contract>> GetList(ApplicationUser client);
        void Update(Contract contract);
    }
}
