// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

using Microsoft.EntityFrameworkCore;
using Torgay.Core.Infrastructure;

namespace Torgay.Core.Services.Shop
{
    public class CustomerService(ApplicationDbContext dbContext) : ICustomerService
    {
        //public IEnumerable<Customer> GetTopActiveCustomers(int count) => throw new NotImplementedException();

        //public IEnumerable<Customer> GetAllCustomersData() => dbContext.Customers
        //        .Include(c => c.Orders).ThenInclude(o => o.OrderDetails).ThenInclude(d => d.Product)
        //        .Include(c => c.Orders).ThenInclude(o => o.Cashier)
        //        .AsSingleQuery()
        //        .OrderBy(c => c.Name)
        //        .ToList();
    }
}
