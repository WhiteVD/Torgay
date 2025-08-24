using Microsoft.EntityFrameworkCore;
using Torgay.Core.Infrastructure;
using Torgay.Core.Models.Payments;
using Torgay.Core.Services.Payments.Interfaces;

namespace Torgay.Core.Services.Payments {
    public class BCCService(ApplicationDbContext dbContext) : IBCCService {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<BCC?> Get(Guid id) {
            return await dbContext.BCCs.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public async Task<List<BCC>> GetList() {
            return await dbContext.BCCs.OrderBy(c => c.Code).ToListAsync();
        }
    }
}
