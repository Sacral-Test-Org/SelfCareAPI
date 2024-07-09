// Decompiled with JetBrains decompiler
// Type: Selfcare.Persistence.Registration.PersistenceModule
// Assembly: Selfcare.Persistence, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC28A518-E4A9-4CDD-8B12-F4E86AD0AF6A
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Persistence.dll

using Autofac;
using Selfcare.Infrastructure.Persistence;
using Selfcare.Infrastructure.Persistence.Repositories;
using Selfcare.Persistence.Repositories;

#nullable disable
namespace Selfcare.Persistence.Registration
{
  public class PersistenceModule : Module
  {
    protected virtual void Load(ContainerBuilder builder)
    {
      RegistrationExtensions.RegisterType<SqlConnectionFactory>(builder).As<ISqlConnectionFactory>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<UserRepository>(builder).As<IUserRepository>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<RefreshTokenRepository>(builder).As<IRefreshTokenRepository>().InstancePerLifetimeScope();
      RegistrationExtensions.RegisterType<PaymentOrdersRepository>(builder).As<IPaymentOrdersRepository>().InstancePerLifetimeScope();
    }
  }
}
