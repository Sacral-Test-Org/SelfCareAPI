// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.Accounts.AccountViewData
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using System;

#nullable disable
namespace Selfcare.Infrastructure.Entities.Accounts
{
  public class AccountViewData
  {
    public int AccountId { get; set; }

    public int AccountCode { get; set; }

    public string AccountName { get; set; }

    public Decimal Balance { get; set; }

    public int StatusId { get; set; }

    public string AddressLine1 { get; set; }

    public string AddressLine2 { get; set; }

    public PrimaryContact PrimaryContact { get; set; }

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

    public Decimal MinimumReplenishmentAmount { get; set; }

    public Decimal MaximumReplenishmentAmount { get; set; }
  }
}
