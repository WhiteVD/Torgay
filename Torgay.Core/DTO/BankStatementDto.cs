namespace Torgay.Core.DTO {
    /// <summary>
    /// DTO банковской выписки
    /// </summary>
    public class BankStatementDto {
        public Guid Id { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }
        public decimal InitialBalance { get; set; }
        public decimal FinalBalance { get; set; }
        public string OrganizationName { get; set; } = string.Empty;
        public string OrganizationBin { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int TransactionCount { get; set; }
        public string UploadedByUserName { get; set; }
    }
}
