using QuickApp.Core.Models.Payments;

namespace QuickApp.Core.Services.Payments.Interfaces {
    public interface ICurrencyRateService {
        void Add(CurrencyRate rate);
        void Delete(Guid id);
        Task<CurrencyRate?> Get(Guid id);
        Task<List<CurrencyRate>> GetList(Currency currency);
        void Update(CurrencyRate rate);
    }
}
