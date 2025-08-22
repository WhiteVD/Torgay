using Microsoft.EntityFrameworkCore;
using QuickApp.Core.Infrastructure;
using QuickApp.Core.Models.Payments;
using QuickApp.Core.Services.Payments.Interfaces;

namespace QuickApp.Core.Services.Payments {
    public class CountryService(ApplicationDbContext dbContext) : ICountryService {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Country?> Get(Guid id) {
            return await dbContext.Countries.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Country>> GetList() {
            return await dbContext.Countries.OrderBy(c => c.Title).ToListAsync();
        }
    }
}
