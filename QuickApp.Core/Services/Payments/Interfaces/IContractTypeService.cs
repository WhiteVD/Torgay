using QuickApp.Core.Models.Payments;

namespace QuickApp.Core.Services.Payments.Interfaces {
    public interface IContractTypeService {
        Task<ContractType?> Get(Guid id);
        Task<List<ContractType>> GetList();
    }
}
