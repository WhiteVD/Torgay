using Torgay.Core.Models.Payments;

namespace Torgay.Core.Services.Payments.Interfaces {
    public interface IAccountTypeService {
        Task<AccountType?> Get(Guid id);
        Task<List<AccountType>> GetList();
        void Add(AccountType accountType);
        void Update(AccountType accountType);
        void Delete(Guid id);
    }
}
