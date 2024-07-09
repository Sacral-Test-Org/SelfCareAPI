// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Models.Accounts.RegisterAccountTopupModel
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using System;

#nullable disable
namespace Selfcare.Api.Models.Accounts
{
  public class RegisterAccountTopupModel
  {
    public int AccountId { get; set; }

    public string OrderId { get; set; }

    public Decimal TopUpAmount { get; set; }

    public string Reference { get; set; }

    public int ChannelId { get; set; }
  }
}
