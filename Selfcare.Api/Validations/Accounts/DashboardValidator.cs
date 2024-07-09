// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Validations.Accounts.DashboardValidator
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
  public class DashboardValidator : AbstractValidator<DashboardRetrieveModel>
  {
    public DashboardValidator()
    {
      DefaultValidatorExtensions.NotEmpty<DashboardRetrieveModel, DateTime>((IRuleBuilder<DashboardRetrieveModel, DateTime>) this.RuleFor<DateTime>((Expression<Func<DashboardRetrieveModel, DateTime>>) (at => at.FromDate)));
      DefaultValidatorExtensions.NotEmpty<DashboardRetrieveModel, DateTime>((IRuleBuilder<DashboardRetrieveModel, DateTime>) this.RuleFor<DateTime>((Expression<Func<DashboardRetrieveModel, DateTime>>) (at => at.ToDate)));
    }
  }
}
