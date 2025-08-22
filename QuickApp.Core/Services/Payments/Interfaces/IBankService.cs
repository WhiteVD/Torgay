using QuickApp.Core.DTO;
using QuickApp.Core.Models.Payments;
using QuickApp.Server.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Core.Services.Payments.Interfaces {
    public interface IBankService {
        void Add(Bank bank);
        void Delete(Guid id);
        Task<Bank?> Get(Guid id);
        Task<ListResponse> GetList(ListQueryParams queryParams);
        void Update(Bank bank);
    }
}
