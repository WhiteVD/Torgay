using Microsoft.EntityFrameworkCore;
using Torgay.Core.Infrastructure;
using Torgay.Core.Models.Access;
using Torgay.Core.Models.Payments;
using Torgay.Core.Services.Payments.Interfaces;

namespace Torgay.Core.Services.Payments {
    public class CustomerAccountService(ApplicationDbContext dbContext) : ICustomerAccountService {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<CustomerAccount?> Get(Guid id) {
            return await dbContext.CustomerAccounts.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public async Task<List<CustomerAccount>> GetList(Customer customer) {
            return await dbContext.CustomerAccounts.Where(x => x.Customer_id == customer.Id).OrderBy(c => c.Title).ThenBy(c => c.bank.Title).ToListAsync();
        }

        /// <summary>
        /// Adds the specified customer account.
        /// </summary>
        /// <param name="customerAccount">The customer account.</param>
        public async void Add(CustomerAccount customerAccount) {
            if (customerAccount != null) {
                await dbContext.AddAsync(customerAccount);
                await dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Updates the specified customer account.
        /// </summary>
        /// <param name="customerAccount">The customer account.</param>
        public async void Update(CustomerAccount customerAccount) {
            if (customerAccount != null) {
                CustomerAccount? b = await dbContext.CustomerAccounts.FirstOrDefaultAsync(x => x.Id.Equals(customerAccount.Id));
                if (b != null) {
                    b.Title = customerAccount.Title;
                    b.Currency_id = customerAccount.Currency_id;
                    b.AccountType_id = customerAccount.AccountType_id;
                    b.Bank_id = customerAccount.Bank_id;
                    b.Source_id = customerAccount.Source_id;
                    b.IsDeleted = customerAccount.IsDeleted;
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
                CustomerAccount? b = await dbContext.CustomerAccounts.FirstOrDefaultAsync(x => x.Id.Equals(id));
                if (b != null) {
                    b.IsDeleted = true;
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
