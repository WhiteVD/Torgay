using QuickApp.Core.Models.Payments;

namespace QuickApp.Core.Services.Payments.Interfaces {
    public interface IAccountTypeService {
        Task<AccountType?> Get(Guid id);
        Task<List<AccountType>> GetList();
    }
}
