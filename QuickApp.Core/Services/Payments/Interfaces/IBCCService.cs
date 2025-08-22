using QuickApp.Core.Models.Payments;

namespace QuickApp.Core.Services.Payments.Interfaces {
    public interface IBCCService {
        Task<BCC?> Get(Guid id);
        Task<List<BCC>> GetList();
    }
}
