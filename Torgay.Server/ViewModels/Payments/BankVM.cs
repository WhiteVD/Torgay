namespace Torgay.Server.ViewModels.Payments {
    public class BankVM {
        public virtual Guid Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string BIC { get; set; }
        public virtual Guid? SourceId { get; set; }
        public virtual bool IsDeleted { get; set; }

    }
}
