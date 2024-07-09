// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Controllers.AccountController
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using Microsoft.AspNet.Identity;
using Selfcare.Api.Attributes;
using Selfcare.Api.Models.Accounts;
using Selfcare.Infrastructure.BackOffice;
using Selfcare.Infrastructure.Entities.Accounts;
using Selfcare.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

#nullable disable
namespace Selfcare.Api.Controllers
{
  public class AccountController : AdminController
  {
    private readonly IAccountService accountService;
    private readonly IPaymentService paymentService;
    private readonly IMailService mailService;

    public AccountController(
      IAccountService accountService,
      IPaymentService paymentService,
      IMailService mailService)
    {
      this.accountService = accountService;
      this.paymentService = paymentService;
      this.mailService = mailService;
    }

    [HttpGet]
    [Route("accounts/{accountId}")]
    public async Task<HttpResponseMessage> AccountInfo(int accountId)
    {
      string username = IdentityExtensions.GetUserName(this.User.Identity);
      BackOfficeApiResult<AccountViewData> accountInfo = await this.accountService.RetrieveAccountInfoAsync(accountId);
      BackOfficeApiResult<AccountTopUpRangeViewData> accountTopUpInfo = await this.accountService.RetrieveAccountTopUpInfoAsync(accountId);
      accountInfo.Data.MaximumReplenishmentAmount = accountTopUpInfo.Data.MaximumReplenishmentAmount;
      accountInfo.Data.MinimumReplenishmentAmount = accountTopUpInfo.Data.MinimumReplenishmentAmount;
      if (accountInfo.Data != null)
      {
        BackOfficeApiResult<AccountInfoRootViewData> retriveCustomerAccounts = await this.accountService.RetrieveCustomerAccountsAsync(username, false);
        AccountInfoViewData accountData = retriveCustomerAccounts.Data.Accounts.Where<AccountInfoViewData>((Func<AccountInfoViewData, bool>) (x => x.AccountId == accountInfo.Data.AccountId)).FirstOrDefault<AccountInfoViewData>();
        accountInfo.Data.AccountCode = accountData.AccountCode;
        retriveCustomerAccounts = (BackOfficeApiResult<AccountInfoRootViewData>) null;
        accountData = (AccountInfoViewData) null;
      }
      return this.GenerateResponseMessage<AccountViewData, AccountViewModel>(accountInfo);
    }

    [HttpPost]
    [Route("accounts/registertopup")]
    [ModelValidation]
    public async Task<HttpResponseMessage> RegisterTopup(RegisterAccountTopupModel registerTopup)
    {
      bool flag = await this.paymentService.ExistsByOrderIdAndStateAsync(registerTopup.OrderId, false);
      if (!flag)
        return HttpRequestMessageExtensions.CreateResponse<string>(this.Request, HttpStatusCode.BadRequest, "Invalid 'OrderId' value", "application/json");
      RegisterAccountTopupData topupRegistrationData = this.mapper.Map<RegisterAccountTopupData>((object) registerTopup);
      BackOfficeApiResult<AccountTopupViewData> accountTopupRegister = await this.accountService.RegisterTopupAsync(topupRegistrationData);
      HttpResponseMessage response = accountTopupRegister.StatusCode != HttpStatusCode.OK ? HttpRequestMessageExtensions.CreateResponse<string>(this.Request, HttpStatusCode.BadRequest, string.Format("Topup registration error: {0}", (object) accountTopupRegister.ErrorMessage), "application/json") : this.GenerateResponseMessage<AccountTopupViewData, AccountTopupViewModel>(accountTopupRegister);
      return response;
    }

    [HttpGet]
    [Route("accounts/customer/{onlyNotClosed}")]
    public async Task<HttpResponseMessage> RetrieveCustomerAccounts(bool onlyNotClosed)
    {
      string username = IdentityExtensions.GetUserName(this.User.Identity);
      BackOfficeApiResult<AccountInfoRootViewData> retriveCustomerAccounts = await this.accountService.RetrieveCustomerAccountsAsync(username, onlyNotClosed);
      return this.GenerateAccountsResponseMessage(retriveCustomerAccounts);
    }

    [HttpPost]
    [Route("accounts/financialdocuments")]
    [ModelValidation]
    public async Task<HttpResponseMessage> RetrieveFinancialDocuments(
      RetrieveFinancialDocumentsParametersModel retrieveParametersModel)
    {
      RetrieveFinancialDocumentsParametersEntity retrieveParameters = this.mapper.Map<RetrieveFinancialDocumentsParametersEntity>((object) retrieveParametersModel);
      BackOfficeApiResult<IEnumerable<RetrieveFinancialDocumentsViewData>> retriveCustomerAccounts = await this.accountService.RetrieveFinancialDocumentsAsync(retrieveParameters);
      return this.GenerateResponseMessage<IEnumerable<RetrieveFinancialDocumentsViewData>, IEnumerable<RetrieveFinancialDocumentsResponseModel>>(retriveCustomerAccounts);
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("accounts/anonymoustransactions")]
    [ModelValidation]
    public async Task<HttpResponseMessage> RetrieveAnonymousTransactions(
      AnonymousTransactionsRetrieveParametersModel retrieveParametersModel)
    {
      AnonymousTransactionsRetrieveParameters retrieveParameters = this.mapper.Map<AnonymousTransactionsRetrieveParameters>((object) retrieveParametersModel);
      BackOfficeApiResult<IEnumerable<AnonymousTransactionViewData>> transactions = await this.accountService.RetrieveAnonymousTransactionsAsync(retrieveParameters);
      return this.GenerateResponseMessage<IEnumerable<AnonymousTransactionViewData>, IEnumerable<AnonymousTransactionViewModel>>(transactions);
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("accounts/anonymousviolations")]
    [ModelValidation]
    public async Task<HttpResponseMessage> RetrieveAnonymousViolations(
      AnonymousTransactionsRetrieveParametersModel retrieveParametersModel)
    {
      AnonymousTransactionsRetrieveParameters retrieveParameters = this.mapper.Map<AnonymousTransactionsRetrieveParameters>((object) retrieveParametersModel);
      BackOfficeApiResult<IEnumerable<AnonymousTransactionViewData>> transactions = await this.accountService.RetrieveAnonymousViolationsAsync(retrieveParameters);
      return this.GenerateResponseMessage<IEnumerable<AnonymousTransactionViewData>, IEnumerable<AnonymousTransactionViewModel>>(transactions);
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("accounts/anonymoustransactions/registerpayment")]
    [ModelValidation]
    public async Task<HttpResponseMessage> RegisterAnonymousPayment(
      AnonymousPaymentRegisterModel anonymousPaymentModel)
    {
      HttpResponseMessage response;
      if (await this.paymentService.ExistsByOrderIdAndStateAsync(anonymousPaymentModel.OrderId, false))
      {
        AnonymousPaymentRegisterData paymentData = this.mapper.Map<AnonymousPaymentRegisterData>((object) anonymousPaymentModel);
        BackOfficeApiResult<AnonymousPaymentViewData> boResponse = await this.accountService.RegisterAnonymousPaymentAsync(paymentData);
        response = this.GenerateResponseMessage<AnonymousPaymentViewData, AnonymousPaymentViewModel>(boResponse);
        paymentData = (AnonymousPaymentRegisterData) null;
        boResponse = (BackOfficeApiResult<AnonymousPaymentViewData>) null;
      }
      else
        response = HttpRequestMessageExtensions.CreateResponse<string>(this.Request, HttpStatusCode.BadRequest, "Invalid 'OrderId' value", "application/json");
      return response;
    }

    [HttpPost]
    [Route("accounts/dashboard")]
    [ModelValidation]
    public async Task<HttpResponseMessage> RetrieveAccountTransactions(
      DashboardRetrieveModel requestModel)
    {
      DashboardRetrieveParameters requestData = this.mapper.Map<DashboardRetrieveParameters>((object) requestModel);
      BackOfficeApiResult<IEnumerable<DashboardViewData>> dashboardData = await this.accountService.RetrieveDashboardDataAsync(requestData);
      return this.GenerateResponseMessage<IEnumerable<DashboardViewData>, IEnumerable<DashboardViewModel>>(dashboardData);
    }

    [HttpPost]
    [Route("accounts/transactions")]
    [ModelValidation]
    public async Task<HttpResponseMessage> RetrieveAccountTransactions(
      AccountTransactionsRetrieveModel transactionsModel)
    {
      AccountTransactionsRetrieveParameters transactionData = this.mapper.Map<AccountTransactionsRetrieveParameters>((object) transactionsModel);
      BackOfficeApiResult<IEnumerable<AccountTransactionsViewData>> retriveCustomerAccounts = await this.accountService.RetrieveAccountTransactionsAsync(transactionData);
      return this.GenerateResponseMessage<IEnumerable<AccountTransactionsViewData>, IEnumerable<AccountTransactionsViewModel>>(retriveCustomerAccounts);
    }

    [HttpPost]
    [Route("accounts/page/transactions")]
    [ModelValidation]
    public async Task<HttpResponseMessage> RetrieveAccountTransactionsByPage(
      AccountPageTransactionsRetrieveModel transactionsModel)
    {
      AccountPageTransactionsRetrieveParameters transactionData = this.mapper.Map<AccountPageTransactionsRetrieveParameters>((object) transactionsModel);
      BackOfficeApiResult<AccountPageTransactionsViewData> retriveCustomerAccounts = await this.accountService.RetrievePageAccountTransactionsAsync(transactionData);
      return this.GenerateResponseMessage<AccountPageTransactionsViewData, AccountPageTransactionsViewModel>(retriveCustomerAccounts);
    }

    [HttpPost]
    [Route("accounts/violations")]
    [ModelValidation]
    public async Task<HttpResponseMessage> RetrieveAccountViolations(
      AccountTransactionsRetrieveModel transactionsModel)
    {
      AccountTransactionsRetrieveParameters transactionData = this.mapper.Map<AccountTransactionsRetrieveParameters>((object) transactionsModel);
      BackOfficeApiResult<IEnumerable<AccountTransactionsViewData>> retriveCustomerAccounts = await this.accountService.RetrieveAccountViolatiosAsync(transactionData);
      return this.GenerateResponseMessage<IEnumerable<AccountTransactionsViewData>, IEnumerable<AccountTransactionsViewModel>>(retriveCustomerAccounts);
    }

    [HttpPost]
    [Route("accounts/page/violations")]
    [ModelValidation]
    public async Task<HttpResponseMessage> RetrieveAccountViolationsByPage(
      AccountPageTransactionsRetrieveModel transactionsModel)
    {
      AccountPageTransactionsRetrieveParameters transactionData = this.mapper.Map<AccountPageTransactionsRetrieveParameters>((object) transactionsModel);
      BackOfficeApiResult<AccountPageTransactionsViewData> retriveCustomerAccounts = await this.accountService.RetrievePageAccountTransactionsAsync(transactionData);
      return this.GenerateResponseMessage<AccountPageTransactionsViewData, AccountPageTransactionsViewModel>(retriveCustomerAccounts);
    }

    protected HttpResponseMessage GenerateAccountsResponseMessage(
      BackOfficeApiResult<AccountInfoRootViewData> apiResult)
    {
      return apiResult.StatusCode != HttpStatusCode.OK && apiResult.StatusCode != HttpStatusCode.Created ? HttpRequestMessageExtensions.CreateResponse<string>(this.Request, apiResult.StatusCode, apiResult.ErrorMessage, "application/json") : HttpRequestMessageExtensions.CreateResponse<IEnumerable<AccountInfoViewModel>>(this.Request, HttpStatusCode.OK, this.mapper.Map<IEnumerable<AccountInfoViewModel>>((object) apiResult.Data.Accounts));
    }
  }
}
