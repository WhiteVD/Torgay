using Microsoft.EntityFrameworkCore;
using QuickApp.Core.Infrastructure;
using QuickApp.Core.Models.Payments;
using QuickApp.Core.Services.Payments.Interfaces;

namespace QuickApp.Core.Services.Payments {
    public class CurrencyRateService(ApplicationDbContext dbContext) : ICurrencyRateService {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<CurrencyRate?> Get(Guid id) {
            return await dbContext.CurrencyRates.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public async Task<List<CurrencyRate>> GetList(Currency currency) {
            return await dbContext.CurrencyRates.Where(c => c.Currency_id == currency.Id).OrderBy(c => c.Date).ToListAsync();
        }

        /// <summary>
        /// Adds the specified currency rate.
        /// </summary>
        /// <param name="rate">The currency rate.</param>
        public async void Add(CurrencyRate rate) {
            if (rate != null) {
                await dbContext.AddAsync(rate);
                await dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Updates the specified currency rate.
        /// </summary>
        /// <param name="rate">The currency rate.</param>
        public async void Update(CurrencyRate rate) {
            if (rate != null) {
                CurrencyRate? b = await dbContext.CurrencyRates.FirstOrDefaultAsync(x => x.Id.Equals(rate.Id));
                if (b != null) {
                    b.Date = rate.Date;
                    b.Rate = rate.Rate;
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async void Delete(Guid id) {
            if (id != Guid.Empty) {
                CurrencyRate? b = await dbContext.CurrencyRates.FirstOrDefaultAsync(x => x.Id.Equals(id));
                if (b != null) {
                    dbContext.CurrencyRates.Remove(b);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
