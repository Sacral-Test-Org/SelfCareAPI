// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.Case.CaseCreateData
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

#nullable disable
namespace Selfcare.Infrastructure.Entities.Case
{
  public class CaseCreateData
  {
    public string Title { get; set; }

    public int CustomerId { get; set; }

    public int AccountId { get; set; }

    public int CaseTypeId { get; set; }

    public string Comment { get; set; }

    public int? AdditionalDataValue { get; set; }
  }
}
