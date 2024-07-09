// Decompiled with JetBrains decompiler
// Type: Selfcare.Services.AccountService
// Assembly: Selfcare.Services, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A5A76E13-8CFD-4949-AA66-F92CBBEE0424
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Services.dll

using Microsoft.AspNet.Identity;
using Selfcare.Domain.Security.Managers;
using Selfcare.Infrastructure.BackOffice;
using Selfcare.Infrastructure.Entities.Accounts;
using Selfcare.Infrastructure.Entities.Persistence;
using Selfcare.Infrastructure.Enums;
using Selfcare.Infrastructure.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Services
{
  public class AccountService : IAccountService
  {
    private readonly UserManager userManager;
    private readonly IBackOfficeManager backOfficeManager;
    private readonly IMailService mailServer;

    public AccountService(
      UserManager userManager,
      IBackOfficeManager backOfficeManager,
      IMailService mailServer)
    {
      this.userManager = userManager;
      this.backOfficeManager = backOfficeManager;
      this.mailServer = mailServer;
    }

    protected static IEnumerable<T> GetItemsFromList<T>(List<T> listOfItems)
    {
      return (IEnumerable<T>) listOfItems.OfType<T>().ToList<T>();
    }

    public async Task<BackOfficeApiResult<AccountViewData>> RetrieveAccountInfoAsync(int accountId)
    {
      BackOfficeApiResult<AccountViewData> backOfficeApiResult = await this.backOfficeManager.RetrieveAccountInfoAsync(accountId);
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<AccountTopUpRangeViewData>> RetrieveAccountTopUpInfoAsync(
      int accountId)
    {
      BackOfficeApiResult<AccountTopUpRangeViewData> backOfficeApiResult = await this.backOfficeManager.RetrieveAccountTopUpRangeInfoAsync(accountId);
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<AccountTopupViewData>> RegisterTopupAsync(
      RegisterAccountTopupData accountTopupData)
    {
      BackOfficeApiResult<AccountTopupViewData> result = await this.backOfficeManager.RegisterTopupAsync(accountTopupData);
      BackOfficeApiResult<AccountTopupViewData> backOfficeApiResult = result;
      result = (BackOfficeApiResult<AccountTopupViewData>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<AccountInfoRootViewData>> RetrieveCustomerAccountsAsync(
      string username,
      bool onlyNotClosed)
    {
      User user = await ((UserManager<User, string>) this.userManager).FindByNameAsync(username);
      BackOfficeApiResult<AccountInfoRootViewData> customerAccounts = await this.backOfficeManager.RetrieveCustomerAccountsAsync(user.CustomerId, onlyNotClosed);
      BackOfficeApiResult<AccountInfoRootViewData> backOfficeApiResult = customerAccounts;
      user = (User) null;
      customerAccounts = (BackOfficeApiResult<AccountInfoRootViewData>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<IEnumerable<RetrieveFinancialDocumentsViewData>>> RetrieveFinancialDocumentsAsync(
      RetrieveFinancialDocumentsParametersEntity retrieveParameters)
    {
      BackOfficeApiResult<IEnumerable<RetrieveFinancialDocumentsViewData>> financialDocuments = await this.backOfficeManager.RetrieveFinancialDocumentsAsync(retrieveParameters);
      BackOfficeApiResult<IEnumerable<RetrieveFinancialDocumentsViewData>> backOfficeApiResult = financialDocuments;
      financialDocuments = (BackOfficeApiResult<IEnumerable<RetrieveFinancialDocumentsViewData>>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<AnonymousPaymentViewData>> RegisterAnonymousPaymentAsync(
      AnonymousPaymentRegisterData paymentData)
    {
      BackOfficeApiResult<AnonymousPaymentViewData> response = await this.backOfficeManager.RegisterAnonymousPaymentAsync(paymentData);
      BackOfficeApiResult<AnonymousPaymentViewData> backOfficeApiResult = response;
      response = (BackOfficeApiResult<AnonymousPaymentViewData>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<IEnumerable<AccountTransactionsViewData>>> RetrieveAccountTransactionsAsync(
      AccountTransactionsRetrieveParameters accountTransactionData)
    {
      BackOfficeApiResult<IEnumerable<AccountTransactionsViewData>> accountTransactions = await this.backOfficeManager.RetrieveAccountTransactionsAsync(accountTransactionData, ActionType.Transaction);
      BackOfficeApiResult<IEnumerable<AccountTransactionsViewData>> backOfficeApiResult = accountTransactions;
      accountTransactions = (BackOfficeApiResult<IEnumerable<AccountTransactionsViewData>>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<AccountPageTransactionsViewData>> RetrievePageAccountTransactionsAsync(
      AccountPageTransactionsRetrieveParameters accountTransactionData)
    {
      BackOfficeApiResult<AccountPageTransactionsViewData> accountTransactions = await this.backOfficeManager.RetrieveAccountPageTransactionsAsync(accountTransactionData, ActionType.Transaction);
      BackOfficeApiResult<AccountPageTransactionsViewData> backOfficeApiResult = accountTransactions;
      accountTransactions = (BackOfficeApiResult<AccountPageTransactionsViewData>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<IEnumerable<AccountTransactionsViewData>>> RetrieveAccountViolatiosAsync(
      AccountTransactionsRetrieveParameters accountTransactionData)
    {
      BackOfficeApiResult<IEnumerable<AccountTransactionsViewData>> accountViolations = await this.backOfficeManager.RetrieveAccountTransactionsAsync(accountTransactionData, ActionType.Violation);
      BackOfficeApiResult<IEnumerable<AccountTransactionsViewData>> backOfficeApiResult = accountViolations;
      accountViolations = (BackOfficeApiResult<IEnumerable<AccountTransactionsViewData>>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<AccountPageTransactionsViewData>> RetrievePageAccountViolatiosAsync(
      AccountPageTransactionsRetrieveParameters accountTransactionData)
    {
      BackOfficeApiResult<AccountPageTransactionsViewData> accountPagedTransactions = await this.backOfficeManager.RetrieveAccountPageTransactionsAsync(accountTransactionData, ActionType.Violation);
      BackOfficeApiResult<AccountPageTransactionsViewData> backOfficeApiResult = accountPagedTransactions;
      accountPagedTransactions = (BackOfficeApiResult<AccountPageTransactionsViewData>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<IEnumerable<AnonymousTransactionViewData>>> RetrieveAnonymousTransactionsAsync(
      AnonymousTransactionsRetrieveParameters retrieveParameters)
    {
      BackOfficeApiResult<IEnumerable<AnonymousTransactionViewData>> annonymousTransactions = await this.backOfficeManager.RetrieveAnonymousTransactionsAsync(retrieveParameters, ActionType.Transaction);
      BackOfficeApiResult<IEnumerable<AnonymousTransactionViewData>> backOfficeApiResult = annonymousTransactions;
      annonymousTransactions = (BackOfficeApiResult<IEnumerable<AnonymousTransactionViewData>>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<IEnumerable<AnonymousTransactionViewData>>> RetrieveAnonymousViolationsAsync(
      AnonymousTransactionsRetrieveParameters retrieveParameters)
    {
      BackOfficeApiResult<IEnumerable<AnonymousTransactionViewData>> annonymousViolations = await this.backOfficeManager.RetrieveAnonymousTransactionsAsync(retrieveParameters, ActionType.Violation);
      BackOfficeApiResult<IEnumerable<AnonymousTransactionViewData>> backOfficeApiResult = annonymousViolations;
      annonymousViolations = (BackOfficeApiResult<IEnumerable<AnonymousTransactionViewData>>) null;
      return backOfficeApiResult;
    }

    public async Task<BackOfficeApiResult<IEnumerable<DashboardViewData>>> RetrieveDashboardDataAsync(
      DashboardRetrieveParameters retrieveParameters)
    {
      BackOfficeApiResult<IEnumerable<DashboardViewData>> responseData = await this.backOfficeManager.RetrieveDashboardDataAsync(retrieveParameters);
      BackOfficeApiResult<IEnumerable<DashboardViewData>> backOfficeApiResult = responseData;
      responseData = (BackOfficeApiResult<IEnumerable<DashboardViewData>>) null;
      return backOfficeApiResult;
    }
  }
}
