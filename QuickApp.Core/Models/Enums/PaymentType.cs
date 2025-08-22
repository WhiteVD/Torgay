using System.ComponentModel;

namespace QuickApp.Core.Models.Enums {
    public enum PaymentType {
        [Description("Выбытие")]
        CREDIT,

        [Description("Поступление")]
        DEBIT,

        [Description("Перемещение")]
        TRANSFER
    }
}
