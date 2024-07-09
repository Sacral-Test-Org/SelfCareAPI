// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Attributes.RestrictHttpsAttribute
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

#nullable disable
namespace Selfcare.Api.Attributes
{
  public class RestrictHttpsAttribute : ActionFilterAttribute
  {
    public virtual void OnActionExecuting(HttpActionContext actionContext)
    {
      if (!(actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps))
        return;
      actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
    }
  }
}
