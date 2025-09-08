using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Torgay.Server.ViewModels.Payments {
    public class CurrencyVM {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string? ISO { get; set; }
        public string? Symbol { get; set; }
    }
}
