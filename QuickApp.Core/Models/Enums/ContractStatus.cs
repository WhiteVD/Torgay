using System.ComponentModel;

namespace QuickApp.Core.Models.Enums {
    public enum ContractStatus {
        [Description("Новый")]
        NEW,        // новый
        [Description("Черновик")]
        DRAFT,      // черновик
        [Description("На согласовании")]
        APPROVAL,   // на согласовании
        [Description("Согласован")]
        AGREED,     // согласован
        [Description("Подписан")]
        SIGNED,     // подписан
        [Description("Зарегистрирован")]
        REGISTERED, // зарегистрирован
        [Description("Просрочен")]
        EXPIRED,    // просрочен
        [Description("Аннулирован")]
        CANCELLED   // аннулирован
    }
}
