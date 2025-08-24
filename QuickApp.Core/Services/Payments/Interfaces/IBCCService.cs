using Torgay.Core.Models.Payments;

namespace Torgay.Core.Services.Payments.Interfaces {
    public interface IBCCService {
        Task<BCC?> Get(Guid id);
        Task<List<BCC>> GetList();
    }
}
