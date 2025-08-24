using Torgay.Core.DTO;
using Torgay.Core.Models.Payments;
using Torgay.Server.DTO;

namespace Torgay.Core.Services.Payments.Interfaces {
    public interface ICurrencyService {
        Task<Currency?> Get(Guid id);
        Task<ListResponse> GetList(ListQueryParams queryParams);
    }
}
