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

        /// <summary>
        /// Adds the specified account type.
        /// </summary>
        public async void Add(AccountType accountType) {
            if (accountType != null) {
                await dbContext.AddAsync(accountType);
                await dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Updates the specified account type.
        /// </summary>
        public async void Update(AccountType accountType) {
            if (accountType != null) {
                AccountType? existing = await dbContext.AccountTypes.FirstOrDefaultAsync(x => x.Id.Equals(accountType.Id));
                if (existing != null) {
                    existing.Title = accountType.Title;
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        public async void Delete(Guid id) {
            if (id != Guid.Empty) {
                AccountType? existing = await dbContext.AccountTypes.FirstOrDefaultAsync(x => x.Id.Equals(id));
                if (existing != null) {
                    dbContext.Remove(existing);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
