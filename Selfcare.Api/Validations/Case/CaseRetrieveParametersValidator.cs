// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Validations.Case.CaseRetrieveParametersValidator
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using FluentValidation;
using Selfcare.Api.Models.Case;
using System;
using System.Linq.Expressions;

#nullable disable
namespace Selfcare.Api.Validations.Case
{
  public class CaseRetrieveParametersValidator : AbstractValidator<CasesRetrieveParametersModel>
  {
    public CaseRetrieveParametersValidator()
    {
      ValidatorOptions.CascadeMode = (CascadeMode) 1;
      DefaultValidatorExtensions.GreaterThanOrEqualTo<CasesRetrieveParametersModel, int>((IRuleBuilder<CasesRetrieveParametersModel, int?>) DefaultValidatorExtensions.NotEmpty<CasesRetrieveParametersModel, int?>((IRuleBuilder<CasesRetrieveParametersModel, int?>) this.RuleFor<int?>((Expression<Func<CasesRetrieveParametersModel, int?>>) (crp => crp.AccountId))), 0);
      DefaultValidatorExtensions.Must<CasesRetrieveParametersModel, bool>((IRuleBuilder<CasesRetrieveParametersModel, bool>) this.RuleFor<bool>((Expression<Func<CasesRetrieveParametersModel, bool>>) (crp => crp.OnlyActive)), (Func<bool, bool>) (x => !x | x));
      DefaultValidatorOptions.WithMessage<CasesRetrieveParametersModel, DateTime>(DefaultValidatorExtensions.Must<CasesRetrieveParametersModel, DateTime>((IRuleBuilder<CasesRetrieveParametersModel, DateTime>) this.RuleFor<DateTime>((Expression<Func<CasesRetrieveParametersModel, DateTime>>) (crp => crp.FromDate)), new Func<DateTime, bool>(this.ValidateDateTime)), "FromDate must be valid DateTime string.");
      DefaultValidatorOptions.WithMessage<CasesRetrieveParametersModel, DateTime>(DefaultValidatorExtensions.Must<CasesRetrieveParametersModel, DateTime>((IRuleBuilder<CasesRetrieveParametersModel, DateTime>) this.RuleFor<DateTime>((Expression<Func<CasesRetrieveParametersModel, DateTime>>) (crp => crp.ToDate)), new Func<DateTime, bool>(this.ValidateDateTime)), "ToDate must be valid DateTime string.");
    }

    public bool ValidateDateTime(DateTime date) => !date.Equals(new DateTime());
  }
}
