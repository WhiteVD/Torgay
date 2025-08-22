using System.ComponentModel;

namespace QuickApp.Core.Models.Enums {
    public enum PaymentStatus {
        [Description("Черновик")]
        CREATED,
        [Description("Отклонен")]
        REJECTED,
        [Description("Согласован")]
        AGREED,
        [Description("Утвержден")]
        APPROVED,
        [Description("Отправлен на оплату")]
        SENT_TO_PAY,
        [Description("Оплачен")]
        PAID
    }
}
