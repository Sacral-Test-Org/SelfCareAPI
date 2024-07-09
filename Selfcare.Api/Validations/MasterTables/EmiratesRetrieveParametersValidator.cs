// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Validations.MasterTables.EmiratesRetrieveParametersValidator
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using FluentValidation;
using Selfcare.Api.Models.MasterTable;
using System;
using System.Linq.Expressions;

#nullable disable
namespace Selfcare.Api.Validations.MasterTables
{
  public class EmiratesRetrieveParametersValidator : 
    AbstractValidator<PlateTypeCategoryRetrieveParametersModel>
  {
    public EmiratesRetrieveParametersValidator()
    {
      DefaultValidatorExtensions.NotNull<PlateTypeCategoryRetrieveParametersModel, string>((IRuleBuilder<PlateTypeCategoryRetrieveParametersModel, string>) DefaultValidatorOptions.Cascade<PlateTypeCategoryRetrieveParametersModel, string>(this.RuleFor<string>((Expression<Func<PlateTypeCategoryRetrieveParametersModel, string>>) (e => e.RegionName)), (CascadeMode) 1));
    }
  }
}
