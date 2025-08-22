using QuickApp.Core.Models.Payments;

namespace QuickApp.Core.Services.Payments.Interfaces {
    public interface IPPCService {
        Task<PPC?> Get(Guid id);
        Task<List<PPC>> GetList();
    }
}
