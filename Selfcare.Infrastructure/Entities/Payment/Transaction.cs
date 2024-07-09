// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.Payment.Transaction
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using System;

#nullable disable
namespace Selfcare.Infrastructure.Entities.Payment
{
  public class Transaction
  {
    public AuthorizationResponse authorizationResponse { get; set; }

    public Customer2 customer { get; set; }

    public Device2 device { get; set; }

    public string gatewayEntryPoint { get; set; }

    public string merchant { get; set; }

    public Order order { get; set; }

    public Response2 response { get; set; }

    public string result { get; set; }

    public Risk2 risk { get; set; }

    public SourceOfFunds2 sourceOfFunds { get; set; }

    public DateTime timeOfRecord { get; set; }

    public Transaction2 transaction { get; set; }

    public string version { get; set; }
  }
}
