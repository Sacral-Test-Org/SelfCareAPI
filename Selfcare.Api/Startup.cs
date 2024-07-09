// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Startup
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using Autofac;
using Microsoft.Owin.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using Selfcare.Api.Handlers;
using Selfcare.Factory;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;

#nullable disable
namespace Selfcare.Api
{
  public class Startup
  {
    public void Configuration(IAppBuilder appBuilder)
    {
      HttpConfiguration httpConfiguration = new HttpConfiguration();
      JsonMediaTypeFormatter jsonFormatter = httpConfiguration.Formatters.JsonFormatter;
      ((BaseJsonMediaTypeFormatter) jsonFormatter).SerializerSettings.ContractResolver = (IContractResolver) new DefaultContractResolver();
      JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
      {
        Formatting = (Newtonsoft.Json.Formatting) 0,
        DateTimeZoneHandling = (DateTimeZoneHandling) 1
      };
      ((BaseJsonMediaTypeFormatter) jsonFormatter).SerializerSettings = serializerSettings;
      Assembly assembly = this.GetType().Assembly;
      Module webApiModule = (Module) new ApiModule();
      ServiceFactoryBuilder.SetWebApiDependencies(appBuilder, httpConfiguration, assembly, webApiModule);
      HttpConfigurationExtensions.MapHttpAttributeRoutes(httpConfiguration);
      httpConfiguration.MessageHandlers.Add((DelegatingHandler) new LogRequestAndResponseHandler());
      CorsExtensions.UseCors(appBuilder, CorsOptions.AllowAll);
      WebApiAppBuilderExtensions.UseWebApi(appBuilder, httpConfiguration);
    }
  }
}
