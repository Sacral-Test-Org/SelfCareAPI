// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.BackOffice.BackOfficeManager
// Assembly: Selfcare.Domain.BackOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 925D2EFC-2F9C-4686-933B-32D249405106
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.BackOffice.dll

using AutoMapper;
using Newtonsoft.Json;
using Selfcare.Domain.BackOffice.Mappings;
using Selfcare.Domain.BackOffice.Models;
using Selfcare.Domain.BackOffice.Models.Accounts;
using Selfcare.Domain.BackOffice.Models.Assets;
using Selfcare.Domain.BackOffice.Models.Case;
using Selfcare.Domain.BackOffice.Models.FAQ;
using Selfcare.Domain.BackOffice.Models.MasterTables;
using Selfcare.Domain.BackOffice.Models.Payment;
using Selfcare.Domain.BackOffice.Models.PointOfInterest;
using Selfcare.Domain.BackOffice.Models.Users;
using Selfcare.Infrastructure.BackOffice;
using Selfcare.Infrastructure.Entities.Accounts;
using Selfcare.Infrastructure.Entities.Assets;
using Selfcare.Infrastructure.Entities.Case;
using Selfcare.Infrastructure.Entities.FAQ;
using Selfcare.Infrastructure.Entities.MasterTable;
using Selfcare.Infrastructure.Entities.Payment;
using Selfcare.Infrastructure.Entities.Persistence;
using Selfcare.Infrastructure.Entities.PointOfInterest;
using Selfcare.Infrastructure.Entities.Users;
using Selfcare.Infrastructure.Enums;
using Selfcare.Infrastructure.Logging;
using Selfcare.Infrastructure.Persistence.Managers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Domain.BackOffice
{
  public class BackOfficeManager : IBackOfficeManager
  {
    private readonly IMapper mapper;
    private readonly IPaymentOrdersManager paymentmanager;
    protected readonly ILogger logger;
    private readonly int[] violationStatuses;

    public BackOfficeManager(IPaymentOrdersManager paymentmanager)
    {
      this.mapper = this.GenerateMapper();
      this.paymentmanager = paymentmanager;
      this.logger = LoggerFactory.GetLogger();
      this.violationStatuses = new int[3]{ 17, 100, 101 };
    }

    public async Task<BackOfficeApiResult<UserRegistrationValidationData>> ValidateUserRegistrationAsync(
      string userRegistrationCode,
      string userEmail)
    {
      BackOfficeApiResult<UserRegistrationValidationData> apiResult;
      using (HttpClient httpClient = this.CreateHttpClient())
      {
        this.LogApiRequestData("GET", string.Format("{0}customer/validatecustomer/{1}/{2}", (object) httpClient.BaseAddress, (object) userRegistrationCode, (object) userEmail), "");
        HttpResponseMessage response = await httpClient.GetAsync("customer/validatecustomer/" + userRegistrationCode + "/" + userEmail);
        apiResult = await this.GenerateApiResultAsync<UserRegistrationValidationData, ValidateCustomerResponseModel>(response);
        response = (HttpResponseMessage) null;
      }
      this.LogApiResponseData((object) apiResult);
      BackOfficeApiResult<UserRegistrationValidationData> backOfficeApiResult = apiResult;
      apiResult = (BackOfficeApiResult<UserRegistrationValidationData>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<UserViewData>> RetrieveUserCustomerDataAsync(
      int userCustomerId)
    {
      BackOfficeApiResult<UserViewData> apiResult;
      using (HttpClient httpClient = this.CreateHttpClient())
      {
        this.LogApiRequestData("GET", string.Format("{0}customer/retrievecustomerdata/{1}", (object) httpClient.BaseAddress, (object) userCustomerId), "");
        HttpResponseMessage response = await httpClient.GetAsync(string.Format("customer/retrievecustomerdata/{0}", (object) userCustomerId));
        apiResult = await this.GenerateApiResultAsync<UserViewData, UserDataResponseModel>(response);
        response = (HttpResponseMessage) null;
      }
      this.LogApiResponseData((object) apiResult);
      BackOfficeApiResult<UserViewData> backOfficeApiResult = apiResult;
      apiResult = (BackOfficeApiResult<UserViewData>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<AccountViewData>> RetrieveAccountInfoAsync(int accountId)
    {
      BackOfficeApiResult<AccountViewData> apiResult;
      using (HttpClient httpClient = this.CreateHttpClient())
      {
        this.LogApiRequestData("GET", string.Format("{0}accounts/retrieveaccountinformation/{1}", (object) httpClient.BaseAddress, (object) accountId), "");
        HttpResponseMessage response = await httpClient.GetAsync(string.Format("accounts/retrieveaccountinformation/{0}", (object) accountId));
        apiResult = await this.GenerateApiResultAsync<AccountViewData, AccountResponseModel>(response);
        response = (HttpResponseMessage) null;
      }
      this.LogApiResponseData((object) apiResult);
      BackOfficeApiResult<AccountViewData> backOfficeApiResult = apiResult;
      apiResult = (BackOfficeApiResult<AccountViewData>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<AccountTopUpRangeViewData>> RetrieveAccountTopUpRangeInfoAsync(
      int accountId)
    {
      BackOfficeApiResult<AccountTopUpRangeViewData> apiResult;
      using (HttpClient httpClient = this.CreateHttpClient())
      {
        this.LogApiRequestData("GET", string.Format("{0}accounts/retrieveAccountTopUpTresholds/{1}", (object) httpClient.BaseAddress, (object) accountId), "");
        HttpResponseMessage response = await httpClient.GetAsync(string.Format("accounts/retrieveAccountTopUpTresholds/{0}", (object) accountId));
        apiResult = await this.GenerateApiResultAsync<AccountTopUpRangeViewData, AccountTopUpRangeResponseModel>(response);
        response = (HttpResponseMessage) null;
      }
      this.LogApiResponseData((object) apiResult);
      BackOfficeApiResult<AccountTopUpRangeViewData> backOfficeApiResult = apiResult;
      apiResult = (BackOfficeApiResult<AccountTopUpRangeViewData>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<AccountTopupViewData>> RegisterTopupAsync(
      RegisterAccountTopupData topupData)
    {
      string json = JsonConvert.SerializeObject((object) topupData);
      StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
      BackOfficeApiResult<AccountTopupViewData> apiResult;
      using (HttpClient httpClient = this.CreateHttpClient())
      {
        this.LogApiRequestData("POST", string.Format("{0}accounts/registertopup/{1}/", (object) httpClient.BaseAddress, (object) topupData.AccountId), json);
        RegisterAccountTopupRequestModel accountTopupRequest = this.mapper.Map<RegisterAccountTopupRequestModel>((object) topupData);
        HttpResponseMessage response = await httpClient.PostAsync(string.Format("accounts/registertopup/{0}/", (object) topupData.AccountId), (HttpContent) content);
        if (response.StatusCode == HttpStatusCode.OK)
        {
          PaymentOrders paymentOrder = new PaymentOrders()
          {
            OrderId = topupData.OrderId,
            Status = true
          };
          await this.paymentmanager.UpdateAsync(paymentOrder);
          paymentOrder = (PaymentOrders) null;
        }
        apiResult = await this.GenerateApiResultAsync<AccountTopupViewData, AccountTopupResponseModel>(response);
        accountTopupRequest = (RegisterAccountTopupRequestModel) null;
        response = (HttpResponseMessage) null;
      }
      this.LogApiResponseData((object) apiResult);
      BackOfficeApiResult<AccountTopupViewData> backOfficeApiResult = apiResult;
      json = (string) null;
      content = (StringContent) null;
      apiResult = (BackOfficeApiResult<AccountTopupViewData>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<AccountInfoRootViewData>> RetrieveCustomerAccountsAsync(
      int customerId,
      bool onlyNotClosed)
    {
      BackOfficeApiResult<AccountInfoRootViewData> apiResult;
      using (HttpClient httpClient = this.CreateHttpClient())
      {
        this.LogApiRequestData("GET", string.Format("{0}customer/{1}/Accounts/{2}", (object) httpClient.BaseAddress, (object) customerId, (object) onlyNotClosed), "");
        HttpResponseMessage response = await httpClient.GetAsync(string.Format("customer/{0}/Accounts/{1}", (object) customerId, (object) onlyNotClosed));
        apiResult = await this.GenerateApiResultAsync<AccountInfoRootViewData, AccountInfoRootResponseModel>(response);
        response = (HttpResponseMessage) null;
      }
      this.LogApiResponseData((object) apiResult);
      BackOfficeApiResult<AccountInfoRootViewData> backOfficeApiResult = apiResult;
      apiResult = (BackOfficeApiResult<AccountInfoRootViewData>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<IEnumerable<AccountTransactionsViewData>>> RetrieveAccountTransactionsAsync(
      AccountTransactionsRetrieveParameters accountTransactionData,
      ActionType actionType)
    {
      int accountId = accountTransactionData.AccountId;
      int accountUnitId = accountTransactionData.AccountUnitId;
      int gantryId = accountTransactionData.GantryId;
      string from = JsonConvert.SerializeObject((object) accountTransactionData.FromDate).Replace("\"", string.Empty);
      string to = JsonConvert.SerializeObject((object) accountTransactionData.ToDate).Replace("\"", string.Empty);
      IEnumerable<AccountTransactionsViewData> responseViewData = (IEnumerable<AccountTransactionsViewData>) new List<AccountTransactionsViewData>();
      BackOfficeApiResult<IEnumerable<AccountTransactionsViewData>> bcResponse = new BackOfficeApiResult<IEnumerable<AccountTransactionsViewData>>();
      try
      {
        using (HttpClient httpClient = this.CreateHttpClient())
        {
          this.LogApiRequestData("GET", string.Format("{0}accounts/{1}/transactions/{2}/{3}/{4}/{5}", (object) httpClient.BaseAddress, (object) accountId, (object) accountUnitId, (object) gantryId, (object) from, (object) to), "");
          HttpResponseMessage response = await httpClient.GetAsync(string.Format("accounts/{0}/transactions/{1}/{2}/{3}/{4}", (object) accountId, (object) accountUnitId, (object) gantryId, (object) from, (object) to));
          string content = await response.Content.ReadAsStringAsync();
          bcResponse.StatusCode = response.StatusCode;
          if (response.IsSuccessStatusCode)
          {
            IEnumerable<AccountTransactionsResponseModel> responseData = JsonConvert.DeserializeObject<IEnumerable<AccountTransactionsResponseModel>>(content);
            ActionType actionType1 = actionType;
            switch (actionType1)
            {
              case ActionType.Transaction:
                responseData = (IEnumerable<AccountTransactionsResponseModel>) responseData.Where<AccountTransactionsResponseModel>((Func<AccountTransactionsResponseModel, bool>) (x => !((IEnumerable<int>) this.violationStatuses).Contains<int>(x.StatusId))).ToList<AccountTransactionsResponseModel>();
                break;
              case ActionType.Violation:
                responseData = (IEnumerable<AccountTransactionsResponseModel>) responseData.Where<AccountTransactionsResponseModel>((Func<AccountTransactionsResponseModel, bool>) (x => ((IEnumerable<int>) this.violationStatuses).Contains<int>(x.StatusId))).ToList<AccountTransactionsResponseModel>();
                break;
            }
            responseViewData = this.mapper.Map<IEnumerable<AccountTransactionsViewData>>((object) responseData);
            responseData = (IEnumerable<AccountTransactionsResponseModel>) null;
          }
          else
            bcResponse.ErrorMessage = content;
          bcResponse.Data = responseViewData;
          response = (HttpResponseMessage) null;
          content = (string) null;
        }
        this.LogApiResponseData((object) bcResponse);
      }
      catch (Exception ex)
      {
        bcResponse.StatusCode = HttpStatusCode.BadRequest;
        bcResponse.ErrorMessage = ex.Message;
        this.logger.Error(ex.Message);
      }
      BackOfficeApiResult<IEnumerable<AccountTransactionsViewData>> backOfficeApiResult = bcResponse;
      BackOfficeApiResult<IEnumerable<AccountTransactionsViewData>> apiResult = (BackOfficeApiResult<IEnumerable<AccountTransactionsViewData>>) null;
      from = (string) null;
      to = (string) null;
      responseViewData = (IEnumerable<AccountTransactionsViewData>) null;
      bcResponse = (BackOfficeApiResult<IEnumerable<AccountTransactionsViewData>>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<AccountPageTransactionsViewData>> RetrieveAccountPageTransactionsAsync(
      AccountPageTransactionsRetrieveParameters accountTransactionData,
      ActionType actionType)
    {
      int accountId = accountTransactionData.AccountId;
      int accountUnitId = accountTransactionData.AccountUnitId;
      int gantryId = accountTransactionData.GantryId;
      int pageNumber = accountTransactionData.PageNumber;
      int pageSize = accountTransactionData.PageSize;
      string from = JsonConvert.SerializeObject((object) accountTransactionData.FromDate).Replace("\"", string.Empty);
      string to = JsonConvert.SerializeObject((object) accountTransactionData.ToDate).Replace("\"", string.Empty);
      AccountPageTransactionsViewData responseViewData = new AccountPageTransactionsViewData();
      BackOfficeApiResult<AccountPageTransactionsViewData> bcResponse = new BackOfficeApiResult<AccountPageTransactionsViewData>();
      try
      {
        using (HttpClient httpClient = this.CreateHttpClient())
        {
          this.LogApiRequestData("GET", string.Format("{0}accounts/{1}/transactions/{2}/{3}/{4}/{5}/{6}/{7}", (object) httpClient.BaseAddress, (object) accountId, (object) accountUnitId, (object) gantryId, (object) from, (object) to, (object) pageNumber, (object) pageSize), "");
          HttpResponseMessage response = await httpClient.GetAsync(string.Format("accounts/{0}/transactions/{1}/{2}/{3}/{4}/{5}/{6}", (object) accountId, (object) accountUnitId, (object) gantryId, (object) from, (object) to, (object) pageNumber, (object) pageSize));
          string content = await response.Content.ReadAsStringAsync();
          bcResponse.StatusCode = response.StatusCode;
          if (response.IsSuccessStatusCode)
          {
            AccountPageTransactionsResponseModel responseData = JsonConvert.DeserializeObject<AccountPageTransactionsResponseModel>(content);
            IEnumerable<AccountTransactionsResponseModel> transactionsList = (IEnumerable<AccountTransactionsResponseModel>) new List<AccountTransactionsResponseModel>();
            ActionType actionType1 = actionType;
            switch (actionType1)
            {
              case ActionType.Transaction:
                transactionsList = (IEnumerable<AccountTransactionsResponseModel>) responseData.List.Where<AccountTransactionsResponseModel>((Func<AccountTransactionsResponseModel, bool>) (x => !((IEnumerable<int>) this.violationStatuses).Contains<int>(x.StatusId))).ToList<AccountTransactionsResponseModel>();
                break;
              case ActionType.Violation:
                transactionsList = (IEnumerable<AccountTransactionsResponseModel>) responseData.List.Where<AccountTransactionsResponseModel>((Func<AccountTransactionsResponseModel, bool>) (x => ((IEnumerable<int>) this.violationStatuses).Contains<int>(x.StatusId))).ToList<AccountTransactionsResponseModel>();
                break;
            }
            responseViewData.TransactionsList = this.mapper.Map<IEnumerable<AccountTransactionsViewData>>((object) transactionsList);
            responseViewData.TotalRows = responseData.TotalRows;
            responseData = (AccountPageTransactionsResponseModel) null;
            transactionsList = (IEnumerable<AccountTransactionsResponseModel>) null;
          }
          else
            bcResponse.ErrorMessage = content;
          bcResponse.Data = responseViewData;
          response = (HttpResponseMessage) null;
          content = (string) null;
        }
      }
      catch (Exception ex)
      {
        bcResponse.StatusCode = HttpStatusCode.BadRequest;
        bcResponse.ErrorMessage = ex.Message;
      }
      this.LogApiResponseData((object) bcResponse);
      BackOfficeApiResult<AccountPageTransactionsViewData> backOfficeApiResult = bcResponse;
      from = (string) null;
      to = (string) null;
      responseViewData = (AccountPageTransactionsViewData) null;
      bcResponse = (BackOfficeApiResult<AccountPageTransactionsViewData>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<IEnumerable<AssetViewData>>> RetrieveAssetsAsync(
      AssetsRetrieveParameters retrieveParameters)
    {
      BackOfficeApiResult<IEnumerable<AssetViewData>> apiResult;
      using (HttpClient httpClient = this.CreateHttpClient())
      {
        this.LogApiRequestData("GET", string.Format("{0}accounts/accountUnits/{1}/{2}/{3}/{4}", (object) httpClient.BaseAddress, (object) retrieveParameters.AccountId, (object) retrieveParameters.StatusId, (object) retrieveParameters.AssetTypeId, (object) retrieveParameters.Identifier), "");
        HttpResponseMessage response = await httpClient.GetAsync(string.Format("accounts/accountUnits/{0}/{1}/{2}/{3}", (object) retrieveParameters.AccountId, (object) retrieveParameters.StatusId, (object) retrieveParameters.AssetTypeId, (object) retrieveParameters.Identifier));
        apiResult = await this.GenerateApiResultAsync<IEnumerable<AssetViewData>, IEnumerable<AssetResponseModel>>(response);
        response = (HttpResponseMessage) null;
      }
      this.LogApiResponseData((object) apiResult);
      BackOfficeApiResult<IEnumerable<AssetViewData>> backOfficeApiResult = apiResult;
      apiResult = (BackOfficeApiResult<IEnumerable<AssetViewData>>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<AssetDetailsViewData>> RetrieveAssetDetailsAsync(
      int accountUnitId)
    {
      BackOfficeApiResult<AssetDetailsViewData> apiResult;
      using (HttpClient httpClient = this.CreateHttpClient())
      {
        this.LogApiRequestData("GET", string.Format("{0}accounts/accountUnit/{1}", (object) httpClient.BaseAddress, (object) accountUnitId), "");
        HttpResponseMessage response = await httpClient.GetAsync(string.Format("accounts/accountUnit/{0}", (object) accountUnitId));
        apiResult = await this.GenerateApiResultAsync<AssetDetailsViewData, AssetDetailsResponseModel>(response);
        response = (HttpResponseMessage) null;
      }
      this.LogApiResponseData((object) apiResult);
      BackOfficeApiResult<AssetDetailsViewData> backOfficeApiResult = apiResult;
      apiResult = (BackOfficeApiResult<AssetDetailsViewData>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<IEnumerable<AnonymousTransactionViewData>>> RetrieveAnonymousTransactionsAsync(
      AnonymousTransactionsRetrieveParameters retrieveParameters,
      ActionType actionType)
    {
      string from = JsonConvert.SerializeObject((object) retrieveParameters.From).Replace("\"", string.Empty);
      string to = JsonConvert.SerializeObject((object) retrieveParameters.To).Replace("\"", string.Empty);
      IEnumerable<AnonymousTransactionViewData> responseViewData = (IEnumerable<AnonymousTransactionViewData>) new List<AnonymousTransactionViewData>();
      BackOfficeApiResult<IEnumerable<AnonymousTransactionViewData>> bcResponse = new BackOfficeApiResult<IEnumerable<AnonymousTransactionViewData>>();
      try
      {
        using (HttpClient httpClient = this.CreateHttpClient())
        {
          this.LogApiRequestData("GET", string.Format("{0}anonymous/retrieveAnonymousTransactions/{1}/{2}/{3}/{4}/{5}/{6}", (object) httpClient.BaseAddress, (object) retrieveParameters.LicensePlateNumber, (object) retrieveParameters.CountryId, (object) retrieveParameters.RegionId, (object) retrieveParameters.PlateTypeCodeId, (object) from, (object) to), "");
          HttpResponseMessage response = await httpClient.GetAsync(string.Format("anonymous/retrieveAnonymousTransactions/{0}/{1}/{2}/{3}/{4}/{5}", (object) retrieveParameters.LicensePlateNumber, (object) retrieveParameters.CountryId, (object) retrieveParameters.RegionId, (object) retrieveParameters.PlateTypeCodeId, (object) from, (object) to));
          string content = await response.Content.ReadAsStringAsync();
          bcResponse.StatusCode = response.StatusCode;
          if (response.IsSuccessStatusCode)
          {
            IEnumerable<AnonymousTransactionResponseModel> responseData = JsonConvert.DeserializeObject<IEnumerable<AnonymousTransactionResponseModel>>(content);
            ActionType actionType1 = actionType;
            switch (actionType1)
            {
              case ActionType.Transaction:
                responseData = (IEnumerable<AnonymousTransactionResponseModel>) responseData.Where<AnonymousTransactionResponseModel>((Func<AnonymousTransactionResponseModel, bool>) (x => !((IEnumerable<int>) this.violationStatuses).Contains<int>(x.StatusId))).ToList<AnonymousTransactionResponseModel>();
                break;
              case ActionType.Violation:
                responseData = (IEnumerable<AnonymousTransactionResponseModel>) responseData.Where<AnonymousTransactionResponseModel>((Func<AnonymousTransactionResponseModel, bool>) (x => ((IEnumerable<int>) this.violationStatuses).Contains<int>(x.StatusId))).ToList<AnonymousTransactionResponseModel>();
                break;
            }
            responseViewData = this.mapper.Map<IEnumerable<AnonymousTransactionViewData>>((object) responseData);
            responseData = (IEnumerable<AnonymousTransactionResponseModel>) null;
          }
          else
            bcResponse.ErrorMessage = content;
          bcResponse.Data = responseViewData;
          response = (HttpResponseMessage) null;
          content = (string) null;
        }
      }
      catch (Exception ex)
      {
        bcResponse.StatusCode = HttpStatusCode.BadRequest;
        bcResponse.ErrorMessage = ex.Message;
      }
      this.LogApiResponseData((object) bcResponse);
      BackOfficeApiResult<IEnumerable<AnonymousTransactionViewData>> backOfficeApiResult = bcResponse;
      from = (string) null;
      to = (string) null;
      responseViewData = (IEnumerable<AnonymousTransactionViewData>) null;
      bcResponse = (BackOfficeApiResult<IEnumerable<AnonymousTransactionViewData>>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<AnonymousPaymentViewData>> RegisterAnonymousPaymentAsync(
      AnonymousPaymentRegisterData paymentData)
    {
      string json = JsonConvert.SerializeObject((object) paymentData);
      BackOfficeApiResult<AnonymousPaymentViewData> apiResult;
      using (HttpClient httpClient = this.CreateHttpClient())
      {
        this.LogApiRequestData("POST", string.Format("{0}anonymous/{1}/registerpayment", (object) httpClient.BaseAddress, (object) paymentData.AccountId), json);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await httpClient.PostAsync(string.Format("anonymous/{0}/registerpayment", (object) paymentData.AccountId), (HttpContent) content);
        apiResult = await this.GenerateApiResultAsync<AnonymousPaymentViewData, AnonymousPaymentResponseModel>(response);
        if (response.StatusCode == HttpStatusCode.OK)
        {
          PaymentOrders paymentOrder = new PaymentOrders()
          {
            OrderId = paymentData.OrderId,
            Status = true
          };
          await this.paymentmanager.UpdateAsync(paymentOrder);
          apiResult.Data.IsResponseValid = true;
          paymentOrder = (PaymentOrders) null;
        }
        this.LogApiResponseData((object) response.StatusCode);
        content = (StringContent) null;
        response = (HttpResponseMessage) null;
      }
      BackOfficeApiResult<AnonymousPaymentViewData> backOfficeApiResult = apiResult;
      json = (string) null;
      apiResult = (BackOfficeApiResult<AnonymousPaymentViewData>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<IEnumerable<AssetDetailsViewData>>> RetrieveFilteredAssetsListAsync(
      AssetsFilterParameters retrieveParameters)
    {
      string identifier = string.Empty;
      int statusId = 1;
      IEnumerable<AssetResponseModel> responseData = (IEnumerable<AssetResponseModel>) new List<AssetResponseModel>();
      List<AssetDetailsViewData> assetDetailsResult = new List<AssetDetailsViewData>();
      BackOfficeApiResult<IEnumerable<AssetDetailsViewData>> bcResponse = new BackOfficeApiResult<IEnumerable<AssetDetailsViewData>>();
      using (HttpClient httpClient = this.CreateHttpClient())
      {
        this.LogApiRequestData("GET", string.Format("{0}accounts/accountunits/{1}/{2}/{3}/{4}", (object) httpClient.BaseAddress, (object) retrieveParameters.AccountId, (object) statusId, (object) retrieveParameters.AssetTypeId, (object) identifier), "");
        HttpResponseMessage response = await httpClient.GetAsync(string.Format("accounts/accountunits/{0}/{1}/{2}/{3}", (object) retrieveParameters.AccountId, (object) statusId, (object) retrieveParameters.AssetTypeId, (object) identifier));
        if (response.IsSuccessStatusCode)
        {
          string data = await response.Content.ReadAsStringAsync();
          bcResponse.StatusCode = response.StatusCode;
          responseData = JsonConvert.DeserializeObject<IEnumerable<AssetResponseModel>>(data);
          foreach (AssetResponseModel rData in responseData)
          {
            try
            {
              HttpResponseMessage assetDetailsResponse = await httpClient.GetAsync(string.Format("accounts/accountUnit/{0}", (object) rData.AccountUnitID));
              AssetDetailsResponseModel assetDetailsResponseModel;
              if (assetDetailsResponse.IsSuccessStatusCode)
              {
                string detailsString = await assetDetailsResponse.Content.ReadAsStringAsync();
                assetDetailsResponseModel = JsonConvert.DeserializeObject<AssetDetailsResponseModel>(detailsString);
                AssetDetailsViewData assetDetailsViewData = this.mapper.Map<AssetDetailsViewData>((object) assetDetailsResponseModel);
                assetDetailsViewData.RelatedAssetIdentifier = rData.RelatedAssetIdentifier;
                assetDetailsViewData.AccountUnitId = rData.AccountUnitID;
                assetDetailsResult.Add(assetDetailsViewData);
                detailsString = (string) null;
                assetDetailsViewData = (AssetDetailsViewData) null;
              }
              else
              {
                BackOfficeApiResult<IEnumerable<AssetDetailsViewData>> backOfficeApiResult = bcResponse;
                backOfficeApiResult.ErrorMessage = backOfficeApiResult.ErrorMessage + assetDetailsResponse.StatusCode.ToString() + string.Format("for request accounts/accountUnit/{0} ", (object) rData.AccountUnitID);
              }
              assetDetailsResponse = (HttpResponseMessage) null;
              assetDetailsResponseModel = (AssetDetailsResponseModel) null;
            }
            catch (Exception ex)
            {
              bcResponse.ErrorMessage = ex.Message;
            }
          }
          data = (string) null;
        }
        else
        {
          BackOfficeApiResult<IEnumerable<AssetDetailsViewData>> backOfficeApiResult = bcResponse;
          backOfficeApiResult.ErrorMessage = backOfficeApiResult.ErrorMessage + response.StatusCode.ToString() + string.Format("accounts/accountunits/{0}/{1}/{2}/{3} ", (object) retrieveParameters.AccountId, (object) statusId, (object) retrieveParameters.AssetTypeId, (object) identifier);
        }
        response = (HttpResponseMessage) null;
      }
      bcResponse.Data = (IEnumerable<AssetDetailsViewData>) assetDetailsResult;
      bcResponse.StatusCode = bcResponse.ErrorMessage != null ? HttpStatusCode.BadRequest : HttpStatusCode.OK;
      this.LogApiResponseData((object) bcResponse);
      BackOfficeApiResult<IEnumerable<AssetDetailsViewData>> backOfficeApiResult1 = bcResponse;
      identifier = (string) null;
      responseData = (IEnumerable<AssetResponseModel>) null;
      assetDetailsResult = (List<AssetDetailsViewData>) null;
      bcResponse = (BackOfficeApiResult<IEnumerable<AssetDetailsViewData>>) null;
      return backOfficeApiResult1;
    }

    public async Task<BackOfficeApiResult<CreateCaseViewData>> CreateCaseAsync(
      CaseCreateData caseData)
    {
      string json = JsonConvert.SerializeObject((object) caseData);
      BackOfficeApiResult<CreateCaseViewData> apiResult = (BackOfficeApiResult<CreateCaseViewData>) null;
      using (HttpClient httpClient = this.CreateHttpClient())
      {
        this.LogApiRequestData("POST", string.Format("{0}customer/cases", (object) httpClient.BaseAddress), json);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await httpClient.PostAsync("customer/cases", (HttpContent) content);
        apiResult = await this.GenerateApiResultAsync<CreateCaseViewData, CreateCaseResponseModel>(response);
        content = (StringContent) null;
        response = (HttpResponseMessage) null;
      }
      this.LogApiResponseData((object) apiResult);
      BackOfficeApiResult<CreateCaseViewData> caseAsync = apiResult;
      json = (string) null;
      apiResult = (BackOfficeApiResult<CreateCaseViewData>) null;
      return caseAsync;
    }

    public async Task<BackOfficeApiResult<IEnumerable<CaseViewData>>> RetrieveCasesAsync(
      CasesRetrieveParameters retrieveParameters)
    {
      string from = JsonConvert.SerializeObject((object) retrieveParameters.FromDate).Replace("\"", string.Empty);
      string to = JsonConvert.SerializeObject((object) retrieveParameters.ToDate).Replace("\"", string.Empty);
      BackOfficeApiResult<IEnumerable<CaseViewData>> apiResult;
      using (HttpClient httpClient = this.CreateHttpClient())
      {
        this.LogApiRequestData("GET", string.Format("{0}customer/{1}/cases/{2}/{3}/{4}/{5}", (object) httpClient.BaseAddress, (object) retrieveParameters.CustomerId, (object) from, (object) to, (object) retrieveParameters.OnlyActive, (object) retrieveParameters.AccountId), "");
        HttpResponseMessage response = await httpClient.GetAsync(string.Format("customer/{0}/cases/{1}/{2}/{3}/{4}", (object) retrieveParameters.CustomerId, (object) from, (object) to, (object) retrieveParameters.OnlyActive, (object) retrieveParameters.AccountId));
        apiResult = await this.GenerateApiResultAsync<IEnumerable<CaseViewData>, IEnumerable<CaseResponseModel>>(response);
        response = (HttpResponseMessage) null;
      }
      this.LogApiResponseData((object) apiResult);
      BackOfficeApiResult<IEnumerable<CaseViewData>> backOfficeApiResult = apiResult;
      from = (string) null;
      to = (string) null;
      apiResult = (BackOfficeApiResult<IEnumerable<CaseViewData>>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<MasterTableRootViewData>> RetrieveMasterTableData(
      string tableName)
    {
      BackOfficeApiResult<MasterTableRootViewData> apiResult;
      using (HttpClient httpClient = this.CreateHttpClient())
      {
        this.LogApiRequestData("GET", string.Format("{0}mastertables/{1}", (object) httpClient.BaseAddress, (object) tableName), "");
        HttpResponseMessage response = await httpClient.GetAsync("mastertables/" + tableName);
        apiResult = await this.GenerateApiResultAsync<MasterTableRootViewData, MasterTableRootResponseModel>(response);
        response = (HttpResponseMessage) null;
      }
      this.LogApiResponseData((object) apiResult);
      BackOfficeApiResult<MasterTableRootViewData> backOfficeApiResult = apiResult;
      apiResult = (BackOfficeApiResult<MasterTableRootViewData>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<IEnumerable<RetrieveFinancialDocumentsViewData>>> RetrieveFinancialDocumentsAsync(
      RetrieveFinancialDocumentsParametersEntity documentData)
    {
      string json = JsonConvert.SerializeObject((object) documentData);
      BackOfficeApiResult<IEnumerable<RetrieveFinancialDocumentsViewData>> apiResult = (BackOfficeApiResult<IEnumerable<RetrieveFinancialDocumentsViewData>>) null;
      using (HttpClient httpClient = this.CreateHttpClient())
      {
        this.LogApiRequestData("POST", string.Format("{0}accounts/financialdocuments", (object) httpClient.BaseAddress), json);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await httpClient.PostAsync("accounts/financialdocuments", (HttpContent) content);
        apiResult = await this.GenerateApiResultAsync<IEnumerable<RetrieveFinancialDocumentsViewData>, IEnumerable<RetrieveFinancialDocumentsResponseModel>>(response);
        content = (StringContent) null;
        response = (HttpResponseMessage) null;
      }
      this.LogApiResponseData((object) apiResult);
      BackOfficeApiResult<IEnumerable<RetrieveFinancialDocumentsViewData>> backOfficeApiResult = apiResult;
      json = (string) null;
      apiResult = (BackOfficeApiResult<IEnumerable<RetrieveFinancialDocumentsViewData>>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<PaymentViewData>> RetrievePaymentSessionAsync(
      PaymentDetailsData paymentData)
    {
      BackOfficeApiResult<PaymentViewData> apiResult = (BackOfficeApiResult<PaymentViewData>) null;
      PaymentSessionRequestModel requestData = new PaymentSessionRequestModel();
      PaymentOrderDetails orderDetails = new PaymentOrderDetails();
      PaymentInteractionDetails interactionData = new PaymentInteractionDetails();
      requestData.apiOperation = "CREATE_CHECKOUT_SESSION";
      orderDetails.id = paymentData.OrderId;
      orderDetails.amount = paymentData.Amount;
      orderDetails.currency = "AED";
      requestData.order = orderDetails;
      interactionData.locale = "EN";
      interactionData.returnUrl = ConfigurationManager.AppSettings["WebAppDomain"] + ConfigurationManager.AppSettings[((PaymentReturnUrl) paymentData.PaymentType).ToString()] + "?order=" + paymentData.OrderId;
      interactionData.cancelUrl = ConfigurationManager.AppSettings["WebAppDomain"] + ConfigurationManager.AppSettings[((PaymentReturnUrl) paymentData.PaymentType).ToString()] + "?order=" + ConfigurationManager.AppSettings["ApplicationBasePaymentSuccessfulUrlCanceled"];
      interactionData.timeoutUrl = ConfigurationManager.AppSettings["WebAppDomain"] + ConfigurationManager.AppSettings[((PaymentReturnUrl) paymentData.PaymentType).ToString()] + "?order=" + ConfigurationManager.AppSettings["ApplicationBasePaymentSuccessfulUrlTimeout"];
      requestData.interaction = interactionData;
      string merchantId = ConfigurationManager.AppSettings["ApplicationMerchantId"];
      string paymentUsername = ConfigurationManager.AppSettings["PaymentUsername"];
      string paymentUserPassword = ConfigurationManager.AppSettings["PaymentPassword"];
      string json = JsonConvert.SerializeObject((object) requestData);
      using (HttpClient httpClient = this.CreatePaymentHttpClient())
      {
        this.LogApiRequestData("POST", string.Format("{0}merchant/{1}/session", (object) httpClient.BaseAddress, (object) merchantId), json);
        byte[] byteArray = Encoding.ASCII.GetBytes(paymentUsername + ":" + paymentUserPassword);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await httpClient.PostAsync("merchant/" + merchantId + "/session", (HttpContent) content);
        if (response.StatusCode == HttpStatusCode.Created)
        {
          PaymentOrders paymentOrder = new PaymentOrders()
          {
            OrderId = paymentData.OrderId,
            Status = false
          };
          string state = await this.paymentmanager.InsertAsync(paymentOrder);
          paymentOrder = (PaymentOrders) null;
          state = (string) null;
        }
        apiResult = await this.GenerateApiResultAsync<PaymentViewData, PaymentSessionResponseModel>(response, 2);
        byteArray = (byte[]) null;
        content = (StringContent) null;
        response = (HttpResponseMessage) null;
      }
      this.LogApiResponseData((object) apiResult);
      BackOfficeApiResult<PaymentViewData> backOfficeApiResult = apiResult;
      apiResult = (BackOfficeApiResult<PaymentViewData>) null;
      requestData = (PaymentSessionRequestModel) null;
      orderDetails = (PaymentOrderDetails) null;
      interactionData = (PaymentInteractionDetails) null;
      merchantId = (string) null;
      paymentUsername = (string) null;
      paymentUserPassword = (string) null;
      json = (string) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<PaymentOrdersViewData>> RetrievePaymentOrderStatusAsync(
      string orderId)
    {
      string merchantId = ConfigurationManager.AppSettings["ApplicationMerchantId"];
      string paymentUsername = ConfigurationManager.AppSettings["PaymentUsername"];
      string paymentUserPassword = ConfigurationManager.AppSettings["PaymentPassword"];
      BackOfficeApiResult<PaymentOrdersViewData> apiResult;
      using (HttpClient httpClient = this.CreatePaymentHttpClient())
      {
        this.LogApiRequestData("GET", string.Format("{0}merchant/{1}/order/{2}", (object) httpClient.BaseAddress, (object) merchantId, (object) orderId), "");
        byte[] byteArray = Encoding.ASCII.GetBytes(paymentUsername + ":" + paymentUserPassword);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        HttpResponseMessage response = await httpClient.GetAsync("merchant/" + merchantId + "/order/" + orderId);
        if (response.StatusCode == HttpStatusCode.OK)
        {
          PaymentOrders paymentOrder = new PaymentOrders()
          {
            OrderId = orderId,
            Status = false
          };
          await this.paymentmanager.UpdateAsync(paymentOrder);
          paymentOrder = (PaymentOrders) null;
        }
        apiResult = await this.GenerateApiResultAsync<PaymentOrdersViewData, PaymentOrdersResponseModel>(response, 2);
        byteArray = (byte[]) null;
        response = (HttpResponseMessage) null;
      }
      this.LogApiResponseData((object) apiResult);
      BackOfficeApiResult<PaymentOrdersViewData> backOfficeApiResult = apiResult;
      apiResult = (BackOfficeApiResult<PaymentOrdersViewData>) null;
      merchantId = (string) null;
      paymentUsername = (string) null;
      paymentUserPassword = (string) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<IEnumerable<FAQViewData>>> RetrieveFaqsAsync()
    {
      BackOfficeApiResult<IEnumerable<FAQViewData>> apiResult;
      using (HttpClient httpClient = this.CreateExternalFaqHttpClient())
      {
        this.LogApiRequestData("GET", string.Format("{0}faqs", (object) httpClient.BaseAddress), "");
        byte[] byteArray = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["ExternalApiAuthorizationDetails"]);
        string authorizationCode = Convert.ToBase64String(byteArray);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorizationCode);
        HttpResponseMessage response = await httpClient.GetAsync("faqs");
        apiResult = await this.GenerateApiResultAsync<IEnumerable<FAQViewData>, IEnumerable<FAQResponseModel>>(response);
        byteArray = (byte[]) null;
        authorizationCode = (string) null;
        response = (HttpResponseMessage) null;
      }
      this.LogApiResponseData((object) apiResult);
      BackOfficeApiResult<IEnumerable<FAQViewData>> backOfficeApiResult = apiResult;
      apiResult = (BackOfficeApiResult<IEnumerable<FAQViewData>>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<IEnumerable<FAQCategoryViewData>>> RetrieveFaqCategoriesAsync()
    {
      BackOfficeApiResult<IEnumerable<FAQCategoryViewData>> apiResult;
      using (HttpClient httpClient = this.CreateExternalFaqHttpClient())
      {
        this.LogApiRequestData("GET", string.Format("{0}faqs/categories", (object) httpClient.BaseAddress), "");
        byte[] byteArray = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["ExternalApiAuthorizationDetails"]);
        string authorizationCode = Convert.ToBase64String(byteArray);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorizationCode);
        HttpResponseMessage response = await httpClient.GetAsync("faqs/categories");
        apiResult = await this.GenerateApiResultAsync<IEnumerable<FAQCategoryViewData>, IEnumerable<FAQCategoryResponseModel>>(response);
        byteArray = (byte[]) null;
        authorizationCode = (string) null;
        response = (HttpResponseMessage) null;
      }
      this.LogApiResponseData((object) apiResult);
      BackOfficeApiResult<IEnumerable<FAQCategoryViewData>> backOfficeApiResult = apiResult;
      apiResult = (BackOfficeApiResult<IEnumerable<FAQCategoryViewData>>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<IEnumerable<PoiViewData>>> RetrievePointOfInterestsAsync()
    {
      BackOfficeApiResult<IEnumerable<PoiViewData>> apiResult;
      using (HttpClient httpClient = this.CreateExternalPoiHttpClient())
      {
        this.LogApiRequestData("GET", string.Format("{0}pois", (object) httpClient.BaseAddress), "");
        byte[] byteArray = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["ExternalApiAuthorizationDetails"]);
        string authorizationCode = Convert.ToBase64String(byteArray);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorizationCode);
        HttpResponseMessage response = await httpClient.GetAsync("pois");
        apiResult = await this.GenerateApiResultAsync<IEnumerable<PoiViewData>, IEnumerable<PoiResponseModel>>(response);
        byteArray = (byte[]) null;
        authorizationCode = (string) null;
        response = (HttpResponseMessage) null;
      }
      BackOfficeApiResult<IEnumerable<PoiViewData>> backOfficeApiResult = apiResult;
      apiResult = (BackOfficeApiResult<IEnumerable<PoiViewData>>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<IEnumerable<PoiCategoryViewData>>> RetrievePointOfInterestCategoriesAsync()
    {
      BackOfficeApiResult<IEnumerable<PoiCategoryViewData>> apiResult;
      using (HttpClient httpClient = this.CreateExternalPoiHttpClient())
      {
        this.LogApiRequestData("GET", string.Format("{0}pois/categories", (object) httpClient.BaseAddress), "");
        byte[] byteArray = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["ExternalApiAuthorizationDetails"]);
        string authorizationCode = Convert.ToBase64String(byteArray);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorizationCode);
        HttpResponseMessage response = await httpClient.GetAsync("pois/categories");
        apiResult = await this.GenerateApiResultAsync<IEnumerable<PoiCategoryViewData>, IEnumerable<PoiCategoryResponseModel>>(response);
        byteArray = (byte[]) null;
        authorizationCode = (string) null;
        response = (HttpResponseMessage) null;
      }
      this.LogApiResponseData((object) apiResult);
      BackOfficeApiResult<IEnumerable<PoiCategoryViewData>> backOfficeApiResult = apiResult;
      apiResult = (BackOfficeApiResult<IEnumerable<PoiCategoryViewData>>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<IEnumerable<PoiServiceViewData>>> RetrievePointOfInterestServicesAsync()
    {
      BackOfficeApiResult<IEnumerable<PoiServiceViewData>> apiResult;
      using (HttpClient httpClient = this.CreateExternalPoiHttpClient())
      {
        this.LogApiRequestData("GET", string.Format("{0}pois/services", (object) httpClient.BaseAddress), "");
        byte[] byteArray = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["ExternalApiAuthorizationDetails"]);
        string authorizationCode = Convert.ToBase64String(byteArray);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorizationCode);
        HttpResponseMessage response = await httpClient.GetAsync("pois/services");
        apiResult = await this.GenerateApiResultAsync<IEnumerable<PoiServiceViewData>, IEnumerable<PoiServiceResponseModel>>(response);
        byteArray = (byte[]) null;
        authorizationCode = (string) null;
        response = (HttpResponseMessage) null;
      }
      this.LogApiResponseData((object) apiResult);
      BackOfficeApiResult<IEnumerable<PoiServiceViewData>> backOfficeApiResult = apiResult;
      apiResult = (BackOfficeApiResult<IEnumerable<PoiServiceViewData>>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<IEnumerable<DashboardViewData>>> RetrieveDashboardDataAsync(
      DashboardRetrieveParameters retrieveParameters)
    {
      string from = JsonConvert.SerializeObject((object) retrieveParameters.FromDate).Replace("\"", string.Empty);
      string to = JsonConvert.SerializeObject((object) retrieveParameters.ToDate).Replace("\"", string.Empty);
      BackOfficeApiResult<IEnumerable<DashboardViewData>> apiResult;
      using (HttpClient httpClient = this.CreateHttpClient())
      {
        this.LogApiRequestData("GET", string.Format("{0}accounts/transactions/{1}/{2}", (object) httpClient.BaseAddress, (object) from, (object) to), "");
        HttpResponseMessage response = await httpClient.GetAsync("accounts/transactions/" + from + "/" + to);
        apiResult = await this.GenerateApiResultAsync<IEnumerable<DashboardViewData>, IEnumerable<DashboardResponseModel>>(response);
        response = (HttpResponseMessage) null;
      }
      this.LogApiResponseData((object) apiResult);
      BackOfficeApiResult<IEnumerable<DashboardViewData>> backOfficeApiResult = apiResult;
      apiResult = (BackOfficeApiResult<IEnumerable<DashboardViewData>>) null;
      from = (string) null;
      to = (string) null;
      return backOfficeApiResult;
    }

    private IMapper GenerateMapper()
    {
      return new MapperConfiguration((Action<IMapperConfigurationExpression>) (cfg =>
      {
        cfg.AddProfile<UserProfile>();
        cfg.AddProfile<AccountProfile>();
        cfg.AddProfile<AssetProfile>();
        cfg.AddProfile<CaseProfile>();
        cfg.AddProfile<MasterTablesProfile>();
        cfg.AddProfile<PaymentProfile>();
        cfg.AddProfile<FAQProfile>();
        cfg.AddProfile<PointOfInterestProfile>();
      })).CreateMapper();
    }

    private HttpClient CreateHttpClient()
    {
      ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback) ((sender, certificate, chain, sslPolicyErrors) => true);
      return new HttpClient()
      {
        BaseAddress = new Uri(ConfigurationManager.AppSettings["BackOfficeApiUrl"])
      };
    }

    private HttpClient CreatePaymentHttpClient()
    {
      ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback) ((sender, certificate, chain, sslPolicyErrors) => true);
      return new HttpClient()
      {
        BaseAddress = new Uri(ConfigurationManager.AppSettings["PaymentBaseUrl"])
      };
    }

    private HttpClient CreateExternalPoiHttpClient()
    {
      ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback) ((sender, certificate, chain, sslPolicyErrors) => true);
      return new HttpClient()
      {
        BaseAddress = new Uri(ConfigurationManager.AppSettings["ExternalPoiApiUrl"])
      };
    }

    private HttpClient CreateExternalFaqHttpClient()
    {
      ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback) ((sender, certificate, chain, sslPolicyErrors) => true);
      return new HttpClient()
      {
        BaseAddress = new Uri(ConfigurationManager.AppSettings["ExternalFaqApiUrl"])
      };
    }

    private async Task<BackOfficeApiResult<TResult>> GenerateApiResultAsync<TResult, TResponse>(
      HttpResponseMessage response,
      int apiType = 1)
      where TResult : class
      where TResponse : class
    {
      BackOfficeApiResult<TResult> apiResult = new BackOfficeApiResult<TResult>()
      {
        StatusCode = response.StatusCode
      };
      string content = await response.Content.ReadAsStringAsync();
      if (apiResult.StatusCode == HttpStatusCode.OK || apiResult.StatusCode == HttpStatusCode.Created)
      {
        TResponse data = this.DeserializeContent<TResponse>(content);
        apiResult.Data = this.mapper.Map<TResult>((object) data);
        data = default (TResponse);
      }
      else if (!string.IsNullOrWhiteSpace(content) && apiType == 1)
        apiResult.ErrorMessage = content;
      else if (!string.IsNullOrWhiteSpace(content) && apiType == 2)
      {
        PaymentErrorResponse errorModel = this.DeserializeContent<PaymentErrorResponse>(content);
        ErrorResponseModel errorResponseModel = new ErrorResponseModel()
        {
          StatusCode = response.StatusCode,
          StatusDescription = response.StatusCode.ToString(),
          Content = content
        };
        apiResult.ErrorMessage = errorModel.Error.Explanation;
        errorModel = (PaymentErrorResponse) null;
        errorResponseModel = (ErrorResponseModel) null;
      }
      BackOfficeApiResult<TResult> apiResultAsync = apiResult;
      apiResult = (BackOfficeApiResult<TResult>) null;
      content = (string) null;
      return apiResultAsync;
    }

    private void LogApiRequestData(string method, string uri, string requestBody)
    {
      this.logger.Information("BO API Request: [" + method + "]" + uri);
      if (!(requestBody != string.Empty))
        return;
      this.logger.Debug("BO API Request Body: " + requestBody);
    }

    private void LogApiResponseData(object response)
    {
      this.logger.Debug("BO API Response: " + JsonConvert.SerializeObject(response));
    }

    private T DeserializeContent<T>(string content) => JsonConvert.DeserializeObject<T>(content);
  }
}
