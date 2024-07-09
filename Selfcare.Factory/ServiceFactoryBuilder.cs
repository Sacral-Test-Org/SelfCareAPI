// Decompiled with JetBrains decompiler
// Type: Selfcare.Factory.ServiceFactoryBuilder
// Assembly: Selfcare.Factory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 10A80FED-0D13-497B-98B1-FA0E26E402A8
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Factory.dll

using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Integration.WebApi;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Selfcare.Domain.BackOffice.Registration;
using Selfcare.Domain.Security;
using Selfcare.Domain.Security.Managers;
using Selfcare.Domain.Security.Registration;
using Selfcare.Infrastructure.Logging;
using Selfcare.Infrastructure.Persistence;
using Selfcare.Infrastructure.Persistence.Repositories;
using Selfcare.Persistence.Registration;
using Selfcare.Services.Registration;
using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dependencies;

#nullable disable
namespace Selfcare.Factory
{
  public static class ServiceFactoryBuilder
  {
    public static void SetWebApiDependencies(
      IAppBuilder appBuilder,
      HttpConfiguration httpConfiguration,
      Assembly webApiAssembly,
      Module webApiModule)
    {
      ContainerBuilder containerBuilder = new ContainerBuilder();
      RegistrationExtensions.RegisterApiControllers(containerBuilder, new Assembly[1]
      {
        webApiAssembly
      });
      RegistrationExtensions.Register<ILogger>(containerBuilder, (Func<IComponentContext, ILogger>) (log => LoggerFactory.GetLogger())).As<ILogger>().InstancePerLifetimeScope();
      ModuleRegistrationExtensions.RegisterModule<PersistenceModule>(containerBuilder);
      ModuleRegistrationExtensions.RegisterModule<SecurityModule>(containerBuilder);
      ModuleRegistrationExtensions.RegisterModule<BackOfficeModule>(containerBuilder);
      ModuleRegistrationExtensions.RegisterModule<ServicesModule>(containerBuilder);
      ModuleRegistrationExtensions.RegisterModule(containerBuilder, (IModule) webApiModule);
      IContainer icontainer = containerBuilder.Build((ContainerBuildOptions) 0);
      httpConfiguration.DependencyResolver = (IDependencyResolver) new AutofacWebApiDependencyResolver((ILifetimeScope) icontainer);
      AppBuilderExtensions.CreatePerOwinContext<SignInManager>(appBuilder, new Func<SignInManager>(((ResolutionExtensions) icontainer).Resolve<SignInManager>));
      OAuthAuthorizationServerExtensions.UseOAuthAuthorizationServer(appBuilder, SecurityConfiguration.GetOAuthAuthorizationServerOptions(ResolutionExtensions.Resolve<ISqlConnectionFactory>((IComponentContext) icontainer), ResolutionExtensions.Resolve<IRefreshTokenRepository>((IComponentContext) icontainer)));
      OAuthBearerAuthenticationExtensions.UseOAuthBearerAuthentication(appBuilder, new OAuthBearerAuthenticationOptions());
      AutofacAppBuilderExtensions.UseAutofacMiddleware(appBuilder, (ILifetimeScope) icontainer);
      AutofacWebApiAppBuilderExtensions.UseAutofacWebApi(appBuilder, httpConfiguration);
    }
  }
}
