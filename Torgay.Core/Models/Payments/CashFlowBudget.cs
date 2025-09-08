using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Torgay.Core.Models.Payments {
    [Table("Payment_C_CashFlowBudgets")]
    [Comment("Бюджет движения денег")]
    public class CashFlowBudget : ClientEntry {

    }
}
