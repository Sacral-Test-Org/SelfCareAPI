// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.Security.Registration.SecurityModule
// Assembly: Selfcare.Domain.Security, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DC9F2D8-6CF0-46B1-83A5-38B437E012C7
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.Security.dll

using Autofac;
using Autofac.Builder;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Selfcare.Domain.Security.Managers;
using Selfcare.Domain.Security.Stores;
using Selfcare.Infrastructure.Entities.Persistence;
using Selfcare.Infrastructure.Persistence.Managers;
using System;
using System.Collections.Generic;

#nullable disable
namespace Selfcare.Domain.Security.Registration
{
  public class SecurityModule : Module
  {
    protected virtual void Load(ContainerBuilder builder)
    {
      RegistrationExtensions.Register<IAuthenticationManager>(builder, (Func<IComponentContext, IAuthenticationManager>) (c => new OwinContext((IDictionary<string, object>) new Dictionary<string, object>()).Authentication));
      RegistrationExtensions.RegisterType<UserStore>(builder).As<IUserStore<User>>().InstancePerLifetimeScope();
      RegistrationExtensions.AsSelf<UserManager, ConcreteReflectionActivatorData>(RegistrationExtensions.RegisterType<UserManager>(builder)).InstancePerLifetimeScope();
      RegistrationExtensions.AsSelf<SignInManager, ConcreteReflectionActivatorData>(RegistrationExtensions.RegisterType<SignInManager>(builder)).InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<PaymentOrdersManager>(builder).As<IPaymentOrdersManager>().InstancePerLifetimeScope();
    }
  }
}
