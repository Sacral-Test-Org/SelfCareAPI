// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.Payment.Response
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using System.Collections.Generic;

#nullable disable
namespace Selfcare.Infrastructure.Entities.Payment
{
  public class Response
  {
    public string gatewayCode { get; set; }

    public Review review { get; set; }

    public List<Rule> rule { get; set; }
  }
}
