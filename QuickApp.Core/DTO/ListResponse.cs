namespace Torgay.Core.DTO {
    public class ListResponse {
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public dynamic Items { get; set; }
    }
}
