using Torgay.Core.Models.Payments;

namespace Torgay.Core.Services.Payments.Interfaces {
    public interface IContractTypeService {
        Task<ContractType?> Get(Guid id);
        Task<List<ContractType>> GetList();
    }
}
