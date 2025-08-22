using Microsoft.EntityFrameworkCore;
using QuickApp.Core.Infrastructure;
using QuickApp.Core.Models.Payments;
using QuickApp.Core.Services.Payments.Interfaces;

namespace QuickApp.Core.Services.Payments {
    public class ContractTypeService(ApplicationDbContext dbContext) : IContractTypeService {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ContractType?> Get(Guid id) {
            return await dbContext.ContractTypes.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ContractType>> GetList() {
            return await dbContext.ContractTypes.OrderBy(c => c.Title).ToListAsync();
        }
    }
}
