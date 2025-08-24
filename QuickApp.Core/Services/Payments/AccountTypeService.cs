using Microsoft.EntityFrameworkCore;
using Torgay.Core.Infrastructure;
using Torgay.Core.Models.Payments;
using Torgay.Core.Services.Payments.Interfaces;

namespace Torgay.Core.Services.Payments {
    public class AccountTypeService(ApplicationDbContext dbContext) : IAccountTypeService {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<AccountType?> Get(Guid id) {
            return await dbContext.AccountTypes.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public async Task<List<AccountType>> GetList() {
            return await dbContext.AccountTypes.OrderBy(c => c.Title).ToListAsync();
        }
    }
}
