namespace QuickApp.Server.ViewModels.Payments {
    public class CustomerVM {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string INN { get; set; }
        public bool IsDeleted { get; set; }
    }
}
