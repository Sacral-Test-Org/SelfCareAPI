// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.BackOffice.IBackOfficeManager
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using Selfcare.Infrastructure.Entities.Accounts;
using Selfcare.Infrastructure.Entities.Assets;
using Selfcare.Infrastructure.Entities.Case;
using Selfcare.Infrastructure.Entities.FAQ;
using Selfcare.Infrastructure.Entities.MasterTable;
using Selfcare.Infrastructure.Entities.Payment;
using Selfcare.Infrastructure.Entities.PointOfInterest;
using Selfcare.Infrastructure.Entities.Users;
using Selfcare.Infrastructure.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable disable
namespace Selfcare.Infrastructure.BackOffice
{
  public interface IBackOfficeManager
  {
    Task<BackOfficeApiResult<UserRegistrationValidationData>> ValidateUserRegistrationAsync(
      string userRegistrationCode,
      string userEmail);

    Task<BackOfficeApiResult<UserViewData>> RetrieveUserCustomerDataAsync(int userCustomerId);

    Task<BackOfficeApiResult<AccountViewData>> RetrieveAccountInfoAsync(int accountId);

    Task<BackOfficeApiResult<AccountTopUpRangeViewData>> RetrieveAccountTopUpRangeInfoAsync(
      int accountId);

    Task<BackOfficeApiResult<AccountTopupViewData>> RegisterTopupAsync(
      RegisterAccountTopupData topupData);

    Task<BackOfficeApiResult<AccountInfoRootViewData>> RetrieveCustomerAccountsAsync(
      int customerId,
      bool onlyNotClosed);

    Task<BackOfficeApiResult<IEnumerable<AccountTransactionsViewData>>> RetrieveAccountTransactionsAsync(
      AccountTransactionsRetrieveParameters accountTransactionData,
      ActionType action);

    Task<BackOfficeApiResult<AccountPageTransactionsViewData>> RetrieveAccountPageTransactionsAsync(
      AccountPageTransactionsRetrieveParameters accountTransactionData,
      ActionType action);

    Task<BackOfficeApiResult<IEnumerable<AssetViewData>>> RetrieveAssetsAsync(
      AssetsRetrieveParameters retrieveParameters);

    Task<BackOfficeApiResult<AssetDetailsViewData>> RetrieveAssetDetailsAsync(int accountUnitId);

    Task<BackOfficeApiResult<IEnumerable<AnonymousTransactionViewData>>> RetrieveAnonymousTransactionsAsync(
      AnonymousTransactionsRetrieveParameters retrieveParameters,
      ActionType action);

    Task<BackOfficeApiResult<AnonymousPaymentViewData>> RegisterAnonymousPaymentAsync(
      AnonymousPaymentRegisterData paymentData);

    Task<BackOfficeApiResult<IEnumerable<AssetDetailsViewData>>> RetrieveFilteredAssetsListAsync(
      AssetsFilterParameters retrieveParameters);

    Task<BackOfficeApiResult<CreateCaseViewData>> CreateCaseAsync(CaseCreateData caseData);

    Task<BackOfficeApiResult<IEnumerable<CaseViewData>>> RetrieveCasesAsync(
      CasesRetrieveParameters retrieveParameters);

    Task<BackOfficeApiResult<MasterTableRootViewData>> RetrieveMasterTableData(string tableName);

    Task<BackOfficeApiResult<IEnumerable<RetrieveFinancialDocumentsViewData>>> RetrieveFinancialDocumentsAsync(
      RetrieveFinancialDocumentsParametersEntity retrieveParameters);

    Task<BackOfficeApiResult<PaymentViewData>> RetrievePaymentSessionAsync(
      PaymentDetailsData paymentData);

    Task<BackOfficeApiResult<PaymentOrdersViewData>> RetrievePaymentOrderStatusAsync(string orderId);

    Task<BackOfficeApiResult<IEnumerable<FAQViewData>>> RetrieveFaqsAsync();

    Task<BackOfficeApiResult<IEnumerable<FAQCategoryViewData>>> RetrieveFaqCategoriesAsync();

    Task<BackOfficeApiResult<IEnumerable<PoiViewData>>> RetrievePointOfInterestsAsync();

    Task<BackOfficeApiResult<IEnumerable<PoiCategoryViewData>>> RetrievePointOfInterestCategoriesAsync();

    Task<BackOfficeApiResult<IEnumerable<PoiServiceViewData>>> RetrievePointOfInterestServicesAsync();

    Task<BackOfficeApiResult<IEnumerable<DashboardViewData>>> RetrieveDashboardDataAsync(
      DashboardRetrieveParameters retrieveParameters);
  }
}
