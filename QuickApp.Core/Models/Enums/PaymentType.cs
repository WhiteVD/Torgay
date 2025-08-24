using System.ComponentModel;

namespace Torgay.Core.Models.Enums {
    public enum PaymentType {
        [Description("Выбытие")]
        CREDIT,

        [Description("Поступление")]
        DEBIT,

        [Description("Перемещение")]
        TRANSFER
    }
}
