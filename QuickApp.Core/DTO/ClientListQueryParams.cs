using System.ComponentModel.DataAnnotations;

namespace QuickApp.Core.DTO {
    public class ClientListQueryParams {
        public Guid Client_id { get; set; }
        public Guid Organization_id { get; set; }
        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;
        [Range(1, 100)]
        public int PageSize { get; set; } = 10;
        public string SearchTerm { get; set; } = string.Empty;
        //public string Filter { get; set; }
        // Параметры сортировки (пример: "name,asc|price,desc")
        public string SortBy { get; set; } = "Id,asc";
    }
}
