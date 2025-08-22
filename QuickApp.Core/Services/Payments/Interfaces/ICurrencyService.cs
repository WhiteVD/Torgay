using QuickApp.Core.DTO;
using QuickApp.Core.Models.Payments;
using QuickApp.Server.DTO;

namespace QuickApp.Core.Services.Payments.Interfaces {
    public interface ICurrencyService {
        Task<Currency?> Get(Guid id);
        Task<ListResponse> GetList(ListQueryParams queryParams);
    }
}
