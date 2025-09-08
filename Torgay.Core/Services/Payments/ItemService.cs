using Torgay.Core.Infrastructure;
using Torgay.Core.Services.Payments.Interfaces;

namespace Torgay.Core.Services.Payments {
    public class ItemService(ApplicationDbContext dbContext) : IItemService {
    }
}
