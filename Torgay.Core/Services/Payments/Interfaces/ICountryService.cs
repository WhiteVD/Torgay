using Torgay.Core.Models.Payments;

namespace Torgay.Core.Services.Payments.Interfaces {
    public interface ICountryService {
        Task<Country?> Get(Guid id);
        Task<List<Country>> GetList();
    }
}
