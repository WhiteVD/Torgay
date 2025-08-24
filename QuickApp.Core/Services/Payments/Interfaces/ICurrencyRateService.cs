using Torgay.Core.Models.Payments;

namespace Torgay.Core.Services.Payments.Interfaces {
    public interface ICurrencyRateService {
        void Add(CurrencyRate rate);
        void Delete(Guid id);
        Task<CurrencyRate?> Get(Guid id);
        Task<List<CurrencyRate>> GetList(Currency currency);
        void Update(CurrencyRate rate);
    }
}
