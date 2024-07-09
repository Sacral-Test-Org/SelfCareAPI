// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Mappings.AccountProfile
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using AutoMapper;
using Selfcare.Api.Models.Accounts;
using Selfcare.Infrastructure.Entities.Accounts;
using System;
using System.Linq.Expressions;

#nullable disable
namespace Selfcare.Api.Mappings
{
  public class AccountProfile : Profile
  {
    public AccountProfile()
    {
      this.CreateMap<RegisterAccountTopupModel, RegisterAccountTopupData>();
      this.CreateMap<CustomerAccountModel, CustomerAccountData>();
      this.CreateMap<AccountViewData, AccountViewModel>();
      this.CreateMap<PrimaryContact, PrimaryContactModel>();
      this.CreateMap<AccountTopupViewData, AccountTopupViewModel>().ForMember<Decimal>((Expression<Func<AccountTopupViewModel, Decimal>>) (dest => dest.AccountBalance), (Action<IMemberConfigurationExpression<AccountTopupViewData, AccountTopupViewModel, Decimal>>) (opt => opt.MapFrom<Decimal>((Expression<Func<AccountTopupViewData, Decimal>>) (src => src.Balance))));
      this.CreateMap<AccountInfoViewData, AccountInfoViewModel>();
      this.CreateMap<RetrieveFinancialDocumentsParametersModel, RetrieveFinancialDocumentsParametersEntity>();
      this.CreateMap<RetrieveFinancialDocumentsViewData, RetrieveFinancialDocumentsResponseModel>();
      this.CreateMap<AnonymousTransactionsRetrieveParameters, AnonymousTransactionsRetrieveParametersModel>();
      this.CreateMap<AnonymousTransactionViewData, AnonymousTransactionViewModel>().ForMember<int>((Expression<Func<AnonymousTransactionViewModel, int>>) (dest => dest.AccountId), (Action<IMemberConfigurationExpression<AnonymousTransactionViewData, AnonymousTransactionViewModel, int>>) (opt => opt.MapFrom<int>((Expression<Func<AnonymousTransactionViewData, int>>) (src => src.AccountID))));
      this.CreateMap<AnonymousPaymentRegisterData, AnonymousPaymentRegisterModel>();
      this.CreateMap<AccountTransactionsViewData, AccountTransactionsViewModel>();
      this.CreateMap<AccountPageTransactionsViewData, AccountPageTransactionsViewModel>();
      this.CreateMap<AccountTransactionsRetrieveModel, AccountTransactionsRetrieveParameters>();
      this.CreateMap<AccountPageTransactionsRetrieveModel, AccountPageTransactionsRetrieveParameters>();
      this.CreateMap<AnonymousPaymentViewData, AnonymousPaymentViewModel>();
      this.CreateMap<DashboardRetrieveModel, DashboardRetrieveParameters>();
      this.CreateMap<DashboardViewData, DashboardViewModel>();
    }
  }
}
