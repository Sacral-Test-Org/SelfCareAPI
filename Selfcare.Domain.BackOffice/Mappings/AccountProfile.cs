// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.BackOffice.Mappings.AccountProfile
// Assembly: Selfcare.Domain.BackOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 925D2EFC-2F9C-4686-933B-32D249405106
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.BackOffice.dll

using AutoMapper;
using Selfcare.Domain.BackOffice.Models.Accounts;
using Selfcare.Infrastructure.Entities.Accounts;
using System;
using System.Linq.Expressions;

#nullable disable
namespace Selfcare.Domain.BackOffice.Mappings
{
  internal class AccountProfile : Profile
  {
    public AccountProfile()
    {
      this.CreateMap<AccountResponseModel, AccountViewData>();
      this.CreateMap<AccountTopupResponseModel, AccountTopupViewData>();
      this.CreateMap<AccountTopUpRangeResponseModel, AccountTopUpRangeViewData>();
      this.CreateMap<AccountInfoResponseModel, AccountInfoViewData>();
      this.CreateMap<AccountInfoRootResponseModel, AccountInfoRootViewData>();
      this.CreateMap<RegisterAccountTopupData, RegisterAccountTopupRequestModel>();
      this.CreateMap<RetrieveFinancialDocumentsResponseModel, RetrieveFinancialDocumentsViewData>().ForMember<Decimal>((Expression<Func<RetrieveFinancialDocumentsViewData, Decimal>>) (dest => dest.OutstandingBalance), (Action<IMemberConfigurationExpression<RetrieveFinancialDocumentsResponseModel, RetrieveFinancialDocumentsViewData, Decimal>>) (opt => opt.MapFrom<Decimal>((Expression<Func<RetrieveFinancialDocumentsResponseModel, Decimal>>) (src => src.Outstanding))));
      this.CreateMap<AnonymousTransactionResponseModel, AnonymousTransactionViewData>();
      this.CreateMap<AnonymousPaymentResponseModel, AnonymousPaymentViewData>();
      this.CreateMap<DashboardResponseModel, DashboardViewData>();
    }
  }
}
