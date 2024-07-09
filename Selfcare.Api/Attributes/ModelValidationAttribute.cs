// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Attributes.ModelValidationAttribute
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using Selfcare.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

#nullable disable
namespace Selfcare.Api.Attributes
{
  public class ModelValidationAttribute : ActionFilterAttribute
  {
    protected readonly ILogger logger;

    public ModelValidationAttribute() => this.logger = LoggerFactory.GetLogger();

    public virtual void OnActionExecuting(HttpActionContext actionContext)
    {
      if (actionContext.ModelState.IsValid)
        return;
      IEnumerable<string> source = actionContext.ModelState.Values.SelectMany<ModelState, ModelError>((Func<ModelState, IEnumerable<ModelError>>) (v => (IEnumerable<ModelError>) v.Errors)).Where<ModelError>((Func<ModelError, bool>) (err => !string.IsNullOrWhiteSpace(err.ErrorMessage))).Select<ModelError, string>((Func<ModelError, string>) (e => e.ErrorMessage)).Union<string>(actionContext.ModelState.Values.SelectMany<ModelState, ModelError>((Func<ModelState, IEnumerable<ModelError>>) (v => (IEnumerable<ModelError>) v.Errors)).Where<ModelError>((Func<ModelError, bool>) (err => err.Exception != null && !string.IsNullOrWhiteSpace(err.Exception.Message))).Select<ModelError, string>((Func<ModelError, string>) (err => err.Exception.Message)));
      if (!source.Any<string>())
        source = (IEnumerable<string>) new List<string>()
        {
          "Bad request. Invalid data."
        };
      actionContext.Response = HttpRequestMessageExtensions.CreateResponse<IEnumerable<string>>(actionContext.Request, HttpStatusCode.BadRequest, source);
    }
  }
}
