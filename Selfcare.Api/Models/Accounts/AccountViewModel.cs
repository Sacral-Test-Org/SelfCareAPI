// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Models.Accounts.AccountViewModel
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using System;

#nullable disable
namespace Selfcare.Api.Models.Accounts
{
  public class AccountViewModel
  {
    public int AccountId { get; set; }

    public int AccountCode { get; set; }

    public string AccountName { get; set; }

    public Decimal Balance { get; set; }

    public int StatusId { get; set; }

    public string AddressLine1 { get; set; }

    public string AddressLine2 { get; set; }

    public PrimaryContactModel PrimaryContact { get; set; }

    public int FundingMethodTypeId { get; set; }

    public int BillingFrequencyTypeId { get; set; }

    public string DeliveryChannel { get; set; }

    public int TotalOpenCases { get; set; }

    public DateTime? LastDocument { get; set; }

    public DateTime? LastNotification { get; set; }

    public DateTime? LastPayment { get; set; }

    public DateTime? LastTransaction { get; set; }

    public DateTime? TollExceptionEndDate { get; set; }

    public int MaxTonsAllowed { get; set; }

    public int AccumulatedTons { get; set; }

    public Decimal MinimumReplenishmentAmount { get; set; }

    public Decimal MaximumReplenishmentAmount { get; set; }
  }
}
