using Services.Models.Domain;

namespace BankChecker.Interfaces;

public interface IPaymentService
{
    Task SendPayment(Payment payment);
}