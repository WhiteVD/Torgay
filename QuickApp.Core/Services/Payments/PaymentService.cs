using Microsoft.EntityFrameworkCore;
using QuickApp.Core.Infrastructure;
using QuickApp.Core.Models.Access;
using QuickApp.Core.Models.Payments;
using QuickApp.Core.Services.Payments.Interfaces;

namespace QuickApp.Core.Services.Payments {
    public class PaymentService(ApplicationDbContext dbContext) : IPaymentService {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Payment?> Get(Guid id) {
            return await dbContext.Payments.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Payment>> GetList(Client client) {
            return await dbContext.Payments.Where(x => x.Client_id == client.Id).OrderBy(c => c.ActualDate).ThenBy(c => c.PaymentId).ToListAsync();
        }

        /// <summary>
        /// Adds the specified payment.
        /// </summary>
        /// <param name="payment">The payment.</param>
        public async void Add(Payment payment) {
            if (payment != null) {
                await dbContext.AddAsync(payment);
                await dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Updates the specified payment.
        /// </summary>
        /// <param name="payment">The payment.</param>
        public async void Update(Payment payment) {
            if (payment != null) {
                Payment? b = await dbContext.Payments.FirstOrDefaultAsync(x => x.Id.Equals(payment.Id));
                if (b != null) {
                    b.ActualDate = payment.ActualDate;
                    b.IncomeDate = payment.IncomeDate;
                    b.VatRate = payment.VatRate;
                    b.Amount = payment.Amount;
                    b.AmountInCurrency = payment.AmountInCurrency;
                    b.Currency = payment.Currency;
                    b.Contract_id = payment.Contract_id;
                    b.IsDeleted = payment.IsDeleted;
                    b.KbkCode = payment.KbkCode;
                    b.KnpCode = payment.KnpCode;
                    b.Note = payment.Note;
                    b.Customer_id = payment.Customer_id;
                    b.ParentPayment_id = payment.ParentPayment_id;
                    b.PaymentCategory_id = payment.PaymentCategory_id;
                    b.PlannedDate = payment.PlannedDate;
                    b.PurposeOfPayment = payment.PurposeOfPayment;
                    b.RecipientAccount_id = payment.RecipientAccount_id;
                    b.SenderAccountId = payment.SenderAccountId;
                    b.Source_id = payment.Source_id;
                    b.Status = payment.Status;
                    b.TotalAmount = payment.TotalAmount;
                    b.TotalAmountInCurrency = payment.TotalAmountInCurrency;
                    b.TransferPair_id = payment.TransferPair_id;
                    b.Type = payment.Type;
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
                Payment? b = await dbContext.Payments.FirstOrDefaultAsync(x => x.Id.Equals(id));
                if (b != null) {
                    b.IsDeleted = true;
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
