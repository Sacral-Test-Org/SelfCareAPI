// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Validations.Accounts.RetrieveFinancialDocumentsValidator
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using FluentValidation;
using Selfcare.Api.Models.Accounts;
using System;
using System.Linq.Expressions;

#nullable disable
namespace Selfcare.Api.Validations.Accounts
{
  public class RetrieveFinancialDocumentsValidator : 
    AbstractValidator<RetrieveFinancialDocumentsParametersModel>
  {
    public RetrieveFinancialDocumentsValidator()
    {
      DefaultValidatorOptions.WithMessage<RetrieveFinancialDocumentsParametersModel, int>(DefaultValidatorExtensions.InclusiveBetween<RetrieveFinancialDocumentsParametersModel, int>((IRuleBuilder<RetrieveFinancialDocumentsParametersModel, int>) DefaultValidatorOptions.WithMessage<RetrieveFinancialDocumentsParametersModel, int>(DefaultValidatorExtensions.NotNull<RetrieveFinancialDocumentsParametersModel, int>((IRuleBuilder<RetrieveFinancialDocumentsParametersModel, int>) DefaultValidatorOptions.Cascade<RetrieveFinancialDocumentsParametersModel, int>(this.RuleFor<int>((Expression<Func<RetrieveFinancialDocumentsParametersModel, int>>) (fd => fd.AccountId)), (CascadeMode) 1)), "AccountId is required"), 1, int.MaxValue), "AccountId invalid value");
      DefaultValidatorExtensions.NotEmpty<RetrieveFinancialDocumentsParametersModel, DateTime>((IRuleBuilder<RetrieveFinancialDocumentsParametersModel, DateTime>) this.RuleFor<DateTime>((Expression<Func<RetrieveFinancialDocumentsParametersModel, DateTime>>) (fd => fd.FromDate)));
      DefaultValidatorExtensions.NotEmpty<RetrieveFinancialDocumentsParametersModel, DateTime>((IRuleBuilder<RetrieveFinancialDocumentsParametersModel, DateTime>) this.RuleFor<DateTime>((Expression<Func<RetrieveFinancialDocumentsParametersModel, DateTime>>) (fd => fd.ToDate)));
    }
  }
}
