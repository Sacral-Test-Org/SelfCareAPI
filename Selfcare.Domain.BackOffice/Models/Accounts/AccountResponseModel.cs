// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.BackOffice.Models.Accounts.AccountResponseModel
// Assembly: Selfcare.Domain.BackOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 925D2EFC-2F9C-4686-933B-32D249405106
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.BackOffice.dll

using Selfcare.Domain.BackOffice.Models.Users;
using System;

#nullable disable
namespace Selfcare.Domain.BackOffice.Models.Accounts
{
  public class AccountResponseModel
  {
    public int AccountId { get; set; }

    public string AccountName { get; set; }

    public Decimal Balance { get; set; }

    public int StatusId { get; set; }

    public string AddressLine1 { get; set; }

    public string AddressLine2 { get; set; }

    public ContactTypeResponseModel PrimaryContact { get; set; }

    public int FundingMethodTypeId { get; set; }

    public int BillingFrequencyTypeId { get; set; }

    public string DeliveryChannel { get; set; }

    public int TotalOpenCases { get; set; }

    public DateTime? LastDocument { get; set; }

    public DateTime? LastNotification { get; set; }

    public DateTime? LastPayment { get; set; }

    public DateTime? LastTransaction { get; set; }

    public DateTime? TollExceptionEndDate { get; set; }

    public Decimal MaxTonsAllowed { get; set; }

    public Decimal AccumulatedTons { get; set; }
  }
}
