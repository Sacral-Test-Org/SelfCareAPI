// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Services.IAccountService
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using Selfcare.Infrastructure.BackOffice;
using Selfcare.Infrastructure.Entities.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Infrastructure.Services
{
  public interface IAccountService
  {
    Task<BackOfficeApiResult<AccountViewData>> RetrieveAccountInfoAsync(int accountId);

    Task<BackOfficeApiResult<AccountTopUpRangeViewData>> RetrieveAccountTopUpInfoAsync(int accountId);

    Task<BackOfficeApiResult<AccountTopupViewData>> RegisterTopupAsync(
      RegisterAccountTopupData accountTopupData);

    Task<BackOfficeApiResult<AccountInfoRootViewData>> RetrieveCustomerAccountsAsync(
      string username,
      bool onlyNotClosed);

    Task<BackOfficeApiResult<IEnumerable<RetrieveFinancialDocumentsViewData>>> RetrieveFinancialDocumentsAsync(
      RetrieveFinancialDocumentsParametersEntity retrieveParameters);

    Task<BackOfficeApiResult<IEnumerable<AnonymousTransactionViewData>>> RetrieveAnonymousTransactionsAsync(
      AnonymousTransactionsRetrieveParameters retrieveParameters);

    Task<BackOfficeApiResult<IEnumerable<AnonymousTransactionViewData>>> RetrieveAnonymousViolationsAsync(
      AnonymousTransactionsRetrieveParameters retrieveParameters);

    Task<BackOfficeApiResult<AnonymousPaymentViewData>> RegisterAnonymousPaymentAsync(
      AnonymousPaymentRegisterData paymentData);

    Task<BackOfficeApiResult<IEnumerable<AccountTransactionsViewData>>> RetrieveAccountTransactionsAsync(
      AccountTransactionsRetrieveParameters accountTransactionData);

    Task<BackOfficeApiResult<AccountPageTransactionsViewData>> RetrievePageAccountTransactionsAsync(
      AccountPageTransactionsRetrieveParameters accountTransactionData);

    Task<BackOfficeApiResult<AccountPageTransactionsViewData>> RetrievePageAccountViolatiosAsync(
      AccountPageTransactionsRetrieveParameters accountTransactionData);

    Task<BackOfficeApiResult<IEnumerable<AccountTransactionsViewData>>> RetrieveAccountViolatiosAsync(
      AccountTransactionsRetrieveParameters accountTransactionData);

    Task<BackOfficeApiResult<IEnumerable<DashboardViewData>>> RetrieveDashboardDataAsync(
      DashboardRetrieveParameters dashboardData);
  }
}
