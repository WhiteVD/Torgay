using Microsoft.EntityFrameworkCore;
using Torgay.Core.DTO;
using Torgay.Core.Infrastructure;
using Torgay.Core.Models.Access;
using Torgay.Core.Models.Payments;
using Torgay.Core.Services.Payments.Interfaces;
using Torgay.Server.DTO;
using System.Linq.Expressions;

namespace Torgay.Core.Services.Payments {
    public class CustomerService(ApplicationDbContext dbContext) : ICustomerService {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Customer?> Get(Guid id) {
            return await dbContext.Customers.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public async Task<ListResponse> GetList(ClientListQueryParams queryParams) {
            IQueryable<Customer> query = dbContext.Customers.Where(p => p.Client_id == queryParams.Client_id && p.Organization_id == queryParams.Organization_id).AsNoTracking();

            // Поиск
            if (!string.IsNullOrEmpty(queryParams.SearchTerm)) {
                string searchTerm = queryParams.SearchTerm.ToLower();
                query = query.Where(p =>
                    p.Title.ToLower().Contains(searchTerm) ||
                    p.BIN.ToLower().Contains(searchTerm));
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

            List<Customer> products = await query
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

        private IQueryable<Customer> ApplySorting(IQueryable<Customer> query, string sortBy) {
            if (string.IsNullOrEmpty(sortBy))
                return query.OrderBy(p => p.Id);

            var sortRules = sortBy.Split('|', StringSplitOptions.RemoveEmptyEntries);

            IOrderedQueryable<Customer> orderedQuery = null;

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

        private Expression<Func<Customer, object>> GetSortProperty(string propertyName) {
            return propertyName.ToLower() switch {
                "title" => p => p.Title,
                "inn" => p => p.BIN,
                _ => p => p.Id
            };
        }

        /// <summary>
        /// Adds the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public async void Add(Customer customer) {
            if (customer != null) {
                await dbContext.AddAsync(customer);
                await dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Updates the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public async void Update(Customer customer) {
            if (customer != null) {
                Customer? b = await dbContext.Customers.FirstOrDefaultAsync(x => x.Id.Equals(customer.Id));
                if (b != null) {
                    b.Title = customer.Title;
                    b.IsDeleted = customer.IsDeleted;
                    b.Source_id = customer.Source_id;
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
                Customer? b = await dbContext.Customers.FirstOrDefaultAsync(x => x.Id.Equals(id));
                if (b != null) {
                    b.IsDeleted = true;
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
