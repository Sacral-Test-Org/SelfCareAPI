// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Handlers.RequireHttpsHandler
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Api.Handlers
{
  public class RequireHttpsHandler : DelegatingHandler
  {
    private readonly int _httpsPort;

    public RequireHttpsHandler()
      : this(int.Parse(ConfigurationManager.AppSettings["ServicePort"]))
    {
    }

    public RequireHttpsHandler(int httpsPort) => this._httpsPort = httpsPort;

    protected override Task<HttpResponseMessage> SendAsync(
      HttpRequestMessage request,
      CancellationToken cancellationToken)
    {
      if (request.RequestUri.Scheme == Uri.UriSchemeHttps)
        return base.SendAsync(request, cancellationToken);
      HttpResponseMessage response = this.CreateResponse(request);
      TaskCompletionSource<HttpResponseMessage> completionSource = new TaskCompletionSource<HttpResponseMessage>();
      completionSource.SetResult(response);
      return completionSource.Task;
    }

    private HttpResponseMessage CreateResponse(HttpRequestMessage request)
    {
      UriBuilder uriBuilder = new UriBuilder(request.RequestUri);
      uriBuilder.Scheme = Uri.UriSchemeHttps;
      uriBuilder.Port = this._httpsPort;
      string content = string.Format("HTTPS is required<br/>The resource can be found at <a href=\"{0}\">{0}</a>.", (object) uriBuilder.Uri.AbsoluteUri);
      HttpResponseMessage response;
      if (request.Method.Equals(HttpMethod.Get) || request.Method.Equals(HttpMethod.Head))
      {
        response = HttpRequestMessageExtensions.CreateResponse(request, HttpStatusCode.Found);
        response.Headers.Location = uriBuilder.Uri;
        if (request.Method.Equals(HttpMethod.Get))
          response.Content = (HttpContent) new StringContent(content, Encoding.UTF8, "text/html");
      }
      else
      {
        response = HttpRequestMessageExtensions.CreateResponse(request, HttpStatusCode.NotFound);
        response.Content = (HttpContent) new StringContent(content, Encoding.UTF8, "text/html");
      }
      return response;
    }
  }
}
