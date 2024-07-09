// Decompiled with JetBrains decompiler
// Type: Selfcare.Services.Registration.ServicesModule
// Assembly: Selfcare.Services, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A5A76E13-8CFD-4949-AA66-F92CBBEE0424
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Services.dll

using Autofac;
using Selfcare.Infrastructure.Services;

#nullable disable
namespace Selfcare.Services.Registration
{
  public class ServicesModule : Module
  {
    protected virtual void Load(ContainerBuilder builder)
    {
      RegistrationExtensions.RegisterType<UserService>(builder).As<IUserService>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<LoginService>(builder).As<ILoginService>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<AccountService>(builder).As<IAccountService>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<AssetService>(builder).As<IAssetService>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<CaseService>(builder).As<ICaseService>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<MasterTableService>(builder).As<IMasterTableService>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<MailService>(builder).As<IMailService>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<PaymentService>(builder).As<IPaymentService>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<FAQService>(builder).As<IFAQService>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<PointOfInterestService>(builder).As<IPointOfInterestService>().InstancePerLifetimeScope();
    }
  }
}
