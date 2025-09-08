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

        /// <summary>
        /// Adds BCC
        /// </summary>
        public async void Add(BCC bcc) {
            if (bcc != null) {
                await dbContext.AddAsync(bcc);
                await dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Updates BCC
        /// </summary>
        public async void Update(BCC bcc) {
            if (bcc != null) {
                var existing = await dbContext.BCCs.FirstOrDefaultAsync(x => x.Id == bcc.Id);
                if (existing != null) {
                    existing.Code = bcc.Code;
                    existing.Title = bcc.Title;
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        /// <summary>
        /// Deletes BCC by id
        /// </summary>
        public async void Delete(Guid id) {
            if (id != Guid.Empty) {
                var existing = await dbContext.BCCs.FirstOrDefaultAsync(x => x.Id == id);
                if (existing != null) {
                    dbContext.Remove(existing);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
