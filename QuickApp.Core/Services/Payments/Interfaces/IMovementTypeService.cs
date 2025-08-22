using QuickApp.Core.Models.Payments;

namespace QuickApp.Core.Services.Payments.Interfaces {
    public interface IMovementTypeService {
        Task<MovementType?> Get(Guid id);
        Task<List<MovementType>> GetList();
    }
}
