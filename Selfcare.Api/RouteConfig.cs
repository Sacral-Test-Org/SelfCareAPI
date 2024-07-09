// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.RouteConfig
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using System.Web.Mvc;
using System.Web.Routing;

#nullable disable
namespace Selfcare.Api
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      RouteCollectionExtensions.IgnoreRoute(routes, "{resource}.axd/{*pathInfo}");
      RouteCollectionExtensions.MapRoute(routes, "Default", "{controller}/{action}/{id}", (object) new
      {
        action = "Index",
        id = UrlParameter.Optional
      });
    }
  }
}
