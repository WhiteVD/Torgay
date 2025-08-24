using Microsoft.EntityFrameworkCore;
using Torgay.Core.DTO;
using Torgay.Core.Infrastructure;
using Torgay.Core.Models.Payments;
using Torgay.Core.Services.Payments.Interfaces;
using Torgay.Server.DTO;
using System.Linq.Expressions;

namespace Torgay.Core.Services.Payments {
    public class CurrencyService(ApplicationDbContext dbContext) : ICurrencyService {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Currency?> Get(Guid id) {
            return await dbContext.Currensies.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public async Task<ListResponse> GetList(ListQueryParams queryParams) {
            IQueryable<Currency> query = dbContext.Currensies.AsNoTracking();

            // Поиск
            if (!string.IsNullOrEmpty(queryParams.SearchTerm)) {
                string searchTerm = queryParams.SearchTerm.ToLower();
                query = query.Where(p =>
                    p.Title.ToLower().Contains(searchTerm) ||
                    p.ISO.ToLower().Contains(searchTerm));
            }

            // Фильтрация
            //if (!string.IsNullOrEmpty(queryParams.Filter)) {
            //    query = query.Where(p => p.Title == queryParams.Filter);
            //}

            // Сортировка
            query = ApplySorting(query, queryParams.SortBy);

            // Пагинация
            int totalItems = await query.CountAsync();
            int totalPages = (int)Math.Ceiling(totalItems / (double)queryParams.PageSize);

            List<Currency> products = await query
                .Skip((queryParams.Page - 1) * queryParams.PageSize)
                .Take(queryParams.PageSize)
                .ToListAsync();

            ListResponse response = new() {
                TotalItems = totalItems,
                TotalPages = totalPages,
                CurrentPage = queryParams.Page,
                PageSize = queryParams.PageSize,
                SortBy = queryParams.SortBy,
                Items = products
            };
            return response;
        }

        private IQueryable<Currency> ApplySorting(IQueryable<Currency> query, string sortBy) {
            if (string.IsNullOrEmpty(sortBy))
                return query.OrderBy(p => p.Id);

            var sortRules = sortBy.Split('|', StringSplitOptions.RemoveEmptyEntries);

            IOrderedQueryable<Currency> orderedQuery = null;

            foreach (var rule in sortRules) {
                var parts = rule.Split(',');
                if (parts.Length != 2) continue;

                string field = parts[0].Trim();
                string direction = parts[1].Trim().ToLower();

                if (orderedQuery == null) {
                    orderedQuery = direction == "desc"
                        ? query.OrderByDescending(GetSortProperty(field))
                        : query.OrderBy(GetSortProperty(field));
                } else {
                    orderedQuery = direction == "desc"
                        ? orderedQuery.ThenByDescending(GetSortProperty(field))
                        : orderedQuery.ThenBy(GetSortProperty(field));
                }
            }

            return orderedQuery ?? query.OrderBy(p => p.Id);
        }

        private Expression<Func<Currency, object>> GetSortProperty(string propertyName) {
            return propertyName.ToLower() switch {
                "title" => p => p.Title,
                "iso" => p => p.ISO,
                "symbol" => p => p.Symbol,
                _ => p => p.Id
            };
        }


    }
}
