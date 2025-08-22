using Microsoft.EntityFrameworkCore;
using QuickApp.Core.Infrastructure;
using QuickApp.Core.Models.Payments;
using QuickApp.Core.Services.Payments.Interfaces;

namespace QuickApp.Core.Services.Payments {
    public class MovementTypeService(ApplicationDbContext dbContext) : IMovementTypeService {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<MovementType?> Get(Guid id) {
            return await dbContext.MovementTypes.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public async Task<List<MovementType>> GetList() {
            return await dbContext.MovementTypes.OrderBy(c => c.Title).ToListAsync();
        }
    }
}
