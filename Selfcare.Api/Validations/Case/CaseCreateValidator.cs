// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Validations.Case.CaseCreateValidator
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
  public class CaseCreateValidator : AbstractValidator<CaseCreateModel>
  {
    public CaseCreateValidator()
    {
      DefaultValidatorExtensions.Length<CaseCreateModel>((IRuleBuilder<CaseCreateModel, string>) DefaultValidatorExtensions.NotNull<CaseCreateModel, string>((IRuleBuilder<CaseCreateModel, string>) DefaultValidatorOptions.Cascade<CaseCreateModel, string>(this.RuleFor<string>((Expression<Func<CaseCreateModel, string>>) (cc => cc.Title)), (CascadeMode) 1)), 1, 256);
      DefaultValidatorExtensions.GreaterThanOrEqualTo<CaseCreateModel, int>((IRuleBuilder<CaseCreateModel, int>) DefaultValidatorExtensions.NotEmpty<CaseCreateModel, int>((IRuleBuilder<CaseCreateModel, int>) DefaultValidatorOptions.Cascade<CaseCreateModel, int>(this.RuleFor<int>((Expression<Func<CaseCreateModel, int>>) (cc => cc.AccountId)), (CascadeMode) 1)), 0);
      DefaultValidatorExtensions.GreaterThan<CaseCreateModel, int>((IRuleBuilder<CaseCreateModel, int>) DefaultValidatorExtensions.NotEmpty<CaseCreateModel, int>((IRuleBuilder<CaseCreateModel, int>) DefaultValidatorOptions.Cascade<CaseCreateModel, int>(this.RuleFor<int>((Expression<Func<CaseCreateModel, int>>) (cc => cc.CaseTypeId)), (CascadeMode) 1)), 0);
      DefaultValidatorExtensions.Length<CaseCreateModel>((IRuleBuilder<CaseCreateModel, string>) DefaultValidatorExtensions.NotNull<CaseCreateModel, string>((IRuleBuilder<CaseCreateModel, string>) DefaultValidatorOptions.Cascade<CaseCreateModel, string>(this.RuleFor<string>((Expression<Func<CaseCreateModel, string>>) (cc => cc.Comment)), (CascadeMode) 1)), 1, 2000);
    }
  }
}
