using Microsoft.EntityFrameworkCore;
using Torgay.Core.Infrastructure;
using Torgay.Core.Models.Account;
using Torgay.Core.Models.Payments;
using Torgay.Core.Services.Payments.Interfaces;

namespace Torgay.Core.Services.Payments {
    public class ContractService(ApplicationDbContext dbContext) : IContractService {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Contract?> Get(Guid id) {
            return await dbContext.Contracts.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Contract>> GetList(ApplicationUser client) {
            return await dbContext.Contracts.Where(x => x.Client_id == client.Id).OrderBy(c => c.Number).ThenBy(c => c.Date).ToListAsync();
        }

        /// <summary>
        /// Adds the specified contract.
        /// </summary>
        /// <param name="contract">The contract.</param>
        public async void Add(Contract contract) {
            if (contract != null) {
                await dbContext.AddAsync(contract);
                await dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Updates the specified contract.
        /// </summary>
        /// <param name="contract">The contract.</param>
        public async void Update(Contract contract) {
            if (contract != null) {
                Contract? b = await dbContext.Contracts.FirstOrDefaultAsync(x => x.Id.Equals(contract.Id));
                if (b != null) {
                    b.Customer_id = contract.Customer_id;
                    b.Title = contract.Title;
                    b.Number = contract.Number;
                    b.Date = contract.Date;
                    b.StartDate = contract.StartDate;
                    b.EndDate = contract.EndDate;
                    b.Client_id = contract.Client_id;
                    b.ContractType_id = contract.ContractType_id;
                    b.Note = contract.Note;
                    b.Status = contract.Status;
                    b.IsDeleted = contract.IsDeleted;
                    b.SourceId = contract.SourceId;
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
                Contract? b = await dbContext.Contracts.FirstOrDefaultAsync(x => x.Id.Equals(id));
                if (b != null) {
                    b.IsDeleted = true;
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
