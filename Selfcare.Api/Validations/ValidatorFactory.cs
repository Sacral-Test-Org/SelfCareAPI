// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Validations.ValidatorFactory
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using Autofac;
using FluentValidation;
using System;

#nullable disable
namespace Selfcare.Api.Validations
{
  public class ValidatorFactory : ValidatorFactoryBase
  {
    private readonly IComponentContext context;

    public ValidatorFactory(IComponentContext context) => this.context = context;

    public virtual IValidator CreateInstance(Type validatorType)
    {
      return ResolutionExtensions.ResolveOptionalKeyed<IValidator>(this.context, (object) validatorType);
    }
  }
}
