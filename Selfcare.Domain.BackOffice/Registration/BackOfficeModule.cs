// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.BackOffice.Registration.BackOfficeModule
// Assembly: Selfcare.Domain.BackOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 925D2EFC-2F9C-4686-933B-32D249405106
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.BackOffice.dll

using Autofac;
using Selfcare.Infrastructure.BackOffice;

#nullable disable
namespace Selfcare.Domain.BackOffice.Registration
{
  public class BackOfficeModule : Module
  {
    protected virtual void Load(ContainerBuilder builder)
    {
      RegistrationExtensions.RegisterType<BackOfficeManager>(builder).As<IBackOfficeManager>().InstancePerLifetimeScope();
    }
  }
}
