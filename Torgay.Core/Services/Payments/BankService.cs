using Microsoft.EntityFrameworkCore;
using Torgay.Core.DTO;
using Torgay.Core.Infrastructure;
using Torgay.Core.Models.Payments;
using Torgay.Core.Services.Payments.Interfaces;
using Torgay.Server.DTO;
using System.Linq.Expressions;

namespace Torgay.Core.Services.Payments {
    public class BankService(ApplicationDbContext dbContext) : IBankService {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Bank?> Get(Guid id) {
            return await dbContext.Banks.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public async Task<ListResponse> GetList(ListQueryParams queryParams) {
            IQueryable<Bank> query = dbContext.Banks.AsNoTracking();

            // Поиск
            if (!string.IsNullOrEmpty(queryParams.SearchTerm)) {
                string searchTerm = queryParams.SearchTerm.ToLower();
                query = query.Where(p =>
                    p.Title.ToLower().Contains(searchTerm) ||
                    p.BIC.ToLower().Contains(searchTerm));
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

            List<Bank> products = await query
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        private IQueryable<Bank> ApplySorting(IQueryable<Bank> query, string sortBy) {
            if (string.IsNullOrEmpty(sortBy))
                return query.OrderBy(p => p.Id);

            var sortRules = sortBy.Split('|', StringSplitOptions.RemoveEmptyEntries);

            IOrderedQueryable<Bank> orderedQuery = null;

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

        private Expression<Func<Bank, object>> GetSortProperty(string propertyName) {
            return propertyName.ToLower() switch {
                "title" => p => p.Title,
                "bic" => p => p.BIC,
                "country" => p => p.Country,
                _ => p => p.Id
            };
        }

        /// <summary>
        /// Adds the specified bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        public async void Add(Bank bank) {
            if (bank != null) {
                await dbContext.AddAsync(bank);
                await dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Updates the specified bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        public async void Update(Bank bank) {
            if (bank != null) {
                Bank? b = await dbContext.Banks.FirstOrDefaultAsync(x => x.Id.Equals(bank.Id));
                if (b != null) {
                    b.Title = bank.Title;
                    b.BIC = bank.BIC;
                    b.IsDeleted = bank.IsDeleted;
                    b.SourceId = bank.SourceId;
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async void Delete(Guid id) {
            if (id != Guid.Empty) {
                Bank? b = await dbContext.Banks.FirstOrDefaultAsync(x => x.Id.Equals(id));
                if (b != null) {
                    b.IsDeleted = true;
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        /// <summary>
        /// Gets the list page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        public async Task<List<Bank>> GetListPage(int page, int pageSize) {
            IQueryable<Bank> query = dbContext.Banks.AsSingleQuery().OrderBy(r => r.Title);

            if (page != -1)
                query = query.Skip((page - 1) * pageSize);

            if (pageSize != -1)
                query = query.Take(pageSize);

            var roles = await query.ToListAsync();

            return roles;
        }
    }
}
