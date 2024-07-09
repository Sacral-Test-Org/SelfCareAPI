// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Validations.Assets.AssetsRetrieveParametersValidator
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using FluentValidation;
using Selfcare.Api.Models.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

#nullable disable
namespace Selfcare.Api.Validations.Assets
{
  public class AssetsRetrieveParametersValidator : AbstractValidator<AssetsRetrieveParametersModel>
  {
    public AssetsRetrieveParametersValidator()
    {
      DefaultValidatorExtensions.GreaterThan<AssetsRetrieveParametersModel, int>((IRuleBuilder<AssetsRetrieveParametersModel, int>) DefaultValidatorExtensions.NotEmpty<AssetsRetrieveParametersModel, int>((IRuleBuilder<AssetsRetrieveParametersModel, int>) DefaultValidatorOptions.Cascade<AssetsRetrieveParametersModel, int>(this.RuleFor<int>((Expression<Func<AssetsRetrieveParametersModel, int>>) (arp => arp.AccountId)), (CascadeMode) 1)), 0);
      DefaultValidatorOptions.WithMessage<AssetsRetrieveParametersModel, int>(DefaultValidatorExtensions.Must<AssetsRetrieveParametersModel, int>((IRuleBuilder<AssetsRetrieveParametersModel, int>) this.RuleFor<int>((Expression<Func<AssetsRetrieveParametersModel, int>>) (arp => arp.StatusId)), new Func<int, bool>(this.ValidateStatusId)), "StatusId must be '0' or '1'.");
      DefaultValidatorOptions.WithMessage<AssetsRetrieveParametersModel, int>(DefaultValidatorExtensions.Must<AssetsRetrieveParametersModel, int>((IRuleBuilder<AssetsRetrieveParametersModel, int>) this.RuleFor<int>((Expression<Func<AssetsRetrieveParametersModel, int>>) (arp => arp.AssetTypeId)), new Func<int, bool>(this.ValidateAssetTypeId)), "AssetTypeId must be '0', '1' or '2'.");
    }

    private bool ValidateStatusId(int statusId)
    {
      return new List<int>() { 0, 1 }.Any<int>((Func<int, bool>) (id => id == statusId));
    }

    private bool ValidateAssetTypeId(int assetTypeId)
    {
      return new List<int>() { 0, 1, 2 }.Any<int>((Func<int, bool>) (id => id == assetTypeId));
    }
  }
}
