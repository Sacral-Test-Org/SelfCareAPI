// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Controllers.BaseController
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using AutoMapper;
using Selfcare.Api.Attributes;
using Selfcare.Api.Mappings;
using Selfcare.Infrastructure.BackOffice;
using Selfcare.Infrastructure.Logging;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

#nullable disable
namespace Selfcare.Api.Controllers
{
  [ExceptionHandling]
  [RestrictHttps]
  public abstract class BaseController : ApiController
  {
    protected readonly IMapper mapper;
    protected readonly ILogger logger;

    public BaseController()
    {
      this.mapper = this.GenerateMapper();
      this.logger = LoggerFactory.GetLogger();
    }

    private IMapper GenerateMapper()
    {
      return new MapperConfiguration((Action<IMapperConfigurationExpression>) (cfg =>
      {
        cfg.AddProfile<UserProfile>();
        cfg.AddProfile<AccountProfile>();
        cfg.AddProfile<AssetProfile>();
        cfg.AddProfile<CaseProfile>();
        cfg.AddProfile<MasterTableProfile>();
        cfg.AddProfile<PaymentProfile>();
        cfg.AddProfile<FAQProfile>();
        cfg.AddProfile<PoiProfile>();
      })).CreateMapper();
    }

    protected HttpResponseMessage GenerateResponseMessage<TResult, TModel>(
      BackOfficeApiResult<TResult> apiResult)
      where TResult : class
      where TModel : class
    {
      return apiResult.StatusCode != HttpStatusCode.OK && apiResult.StatusCode != HttpStatusCode.Created ? HttpRequestMessageExtensions.CreateResponse<string>(this.Request, apiResult.StatusCode, apiResult.ErrorMessage, "application/json") : HttpRequestMessageExtensions.CreateResponse<TModel>(this.Request, HttpStatusCode.OK, this.mapper.Map<TModel>((object) apiResult.Data), "application/json");
    }
  }
}
