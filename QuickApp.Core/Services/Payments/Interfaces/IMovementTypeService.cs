using Torgay.Core.Models.Payments;

namespace Torgay.Core.Services.Payments.Interfaces {
    public interface IMovementTypeService {
        Task<MovementType?> Get(Guid id);
        Task<List<MovementType>> GetList();
    }
}
