using QuickApp.Core.Infrastructure;
using QuickApp.Core.Services.Payments.Interfaces;

namespace QuickApp.Core.Services.Payments {
    public class ItemService(ApplicationDbContext dbContext) : IItemService {
    }
}
