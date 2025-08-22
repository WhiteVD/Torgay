using QuickApp.Core.Models.Payments;

namespace QuickApp.Core.Services.Payments.Interfaces {
    public interface ICountryService {
        Task<Country?> Get(Guid id);
        Task<List<Country>> GetList();
    }
}
