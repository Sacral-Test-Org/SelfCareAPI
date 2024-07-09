// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Handlers.LogRequestAndResponseHandler
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using Selfcare.Infrastructure.Logging;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Api.Handlers
{
  public class LogRequestAndResponseHandler : DelegatingHandler
  {
    protected readonly ILogger logger;

    public LogRequestAndResponseHandler() => this.logger = LoggerFactory.GetLogger();

    protected override async Task<HttpResponseMessage> SendAsync(
      HttpRequestMessage request,
      CancellationToken cancellationToken)
    {
      string requestBody = string.Format("Middleware API Request: [{0}]{1}", (object) request.Method.Method, (object) request.RequestUri);
      string requestBodyData = request.Content.ReadAsStringAsync().Result;
      this.logger.Information(requestBody);
      if (requestBodyData != string.Empty && !request.RequestUri.AbsolutePath.Contains("login") && !request.RequestUri.AbsolutePath.Contains("registration") && !request.RequestUri.AbsolutePath.Contains("changepassword") && !request.RequestUri.AbsolutePath.Contains("resetpassword"))
        this.logger.Debug("Request Data: " + requestBodyData);
      HttpResponseMessage result = await base.SendAsync(request, cancellationToken);
      if (result.Content != null && !request.RequestUri.AbsolutePath.Contains("login") && !request.RequestUri.AbsolutePath.Contains("registration") && !request.RequestUri.AbsolutePath.Contains("changepassword") && !request.RequestUri.AbsolutePath.Contains("resetpassword"))
      {
        string responseBody = await result.Content.ReadAsStringAsync();
        this.logger.Debug(string.Format("Middleware API Response: [{0}]", (object) result.StatusCode) + responseBody);
        responseBody = (string) null;
      }
      return result;
    }
  }
}
