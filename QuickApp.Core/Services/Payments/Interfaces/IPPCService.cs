using Torgay.Core.Models.Payments;

namespace Torgay.Core.Services.Payments.Interfaces {
    public interface IPPCService {
        Task<PPC?> Get(Guid id);
        Task<List<PPC>> GetList();
    }
}
