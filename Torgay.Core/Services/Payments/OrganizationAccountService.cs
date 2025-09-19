using Microsoft.EntityFrameworkCore;
using Torgay.Core.Infrastructure;
using Torgay.Core.Models.Account;
using Torgay.Core.Models.Payments;
using Torgay.Core.Services.Payments.Interfaces;

namespace Torgay.Core.Services.Payments {
    public class OrganizationAccountService(ApplicationDbContext dbContext) : IOrganizationAccountService {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<OrganizationAccount?> Get(Guid id) {
            return await dbContext.OrganizationAccounts.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public async Task<List<OrganizationAccount>> GetList(ApplicationUser client) {
            return await dbContext.OrganizationAccounts.Where(x => x.Client_id == client.Id).OrderBy(c => c.Title).ThenBy(c => c.bank.Title).ToListAsync();
        }

        /// <summary>
        /// Adds the specified organization account.
        /// </summary>
        /// <param name="organizationAccount">The organization account.</param>
        public async void Add(OrganizationAccount organizationAccount) {
            if (organizationAccount != null) {
                await dbContext.AddAsync(organizationAccount);
                await dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Updates the specified organization account.
        /// </summary>
        /// <param name="organizationAccount">The organization account.</param>
        public async void Update(OrganizationAccount organizationAccount) {
            if (organizationAccount != null) {
                OrganizationAccount? b = await dbContext.OrganizationAccounts.FirstOrDefaultAsync(x => x.Id.Equals(organizationAccount.Id));
                if (b != null) {
                    b.Title = organizationAccount.Title;
                    b.Currency_id = organizationAccount.Currency_id;
                    b.AccountType_id = organizationAccount.AccountType_id;
                    b.Bank_id = organizationAccount.Bank_id;
                    b.Source_id = organizationAccount.Source_id;
                    b.IsDeleted = organizationAccount.IsDeleted;
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
                OrganizationAccount? b = await dbContext.OrganizationAccounts.FirstOrDefaultAsync(x => x.Id.Equals(id));
                if (b != null) {
                    b.IsDeleted = true;
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
