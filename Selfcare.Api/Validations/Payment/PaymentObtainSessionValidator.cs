// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Validations.Payment.PaymentObtainSessionValidator
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using FluentValidation;
using Selfcare.Api.Models.Payment;
using Selfcare.Infrastructure.Services;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Api.Validations.Payment
{
  public class PaymentObtainSessionValidator : AbstractValidator<PaymentDetailsModel>
  {
    private readonly IPaymentService paymentService;

    public PaymentObtainSessionValidator(IPaymentService paymentService)
    {
      this.paymentService = paymentService;
      DefaultValidatorOptions.WithMessage<PaymentDetailsModel, string>(DefaultValidatorExtensions.MustAsync<PaymentDetailsModel, string>((IRuleBuilder<PaymentDetailsModel, string>) DefaultValidatorExtensions.NotNull<PaymentDetailsModel, string>((IRuleBuilder<PaymentDetailsModel, string>) DefaultValidatorOptions.Cascade<PaymentDetailsModel, string>(this.RuleFor<string>((Expression<Func<PaymentDetailsModel, string>>) (pv => pv.OrderId)), (CascadeMode) 1)), new Func<string, CancellationToken, Task<bool>>(this.ValidateOrderIdAsync)), "OrderId already used.");
      DefaultValidatorExtensions.NotNull<PaymentDetailsModel, string>((IRuleBuilder<PaymentDetailsModel, string>) DefaultValidatorOptions.Cascade<PaymentDetailsModel, string>(this.RuleFor<string>((Expression<Func<PaymentDetailsModel, string>>) (pv => pv.LanguageCode)), (CascadeMode) 1));
      DefaultValidatorExtensions.GreaterThan<PaymentDetailsModel, Decimal>((IRuleBuilder<PaymentDetailsModel, Decimal>) DefaultValidatorExtensions.NotEmpty<PaymentDetailsModel, Decimal>((IRuleBuilder<PaymentDetailsModel, Decimal>) DefaultValidatorOptions.Cascade<PaymentDetailsModel, Decimal>(this.RuleFor<Decimal>((Expression<Func<PaymentDetailsModel, Decimal>>) (pv => pv.Amount)), (CascadeMode) 1)), 0M);
    }

    private async Task<bool> ValidateOrderIdAsync(
      string orderId,
      CancellationToken cancellationToken)
    {
      bool flag = await this.paymentService.ExistsByOrderIdAsync(orderId);
      return !flag;
    }
  }
}
