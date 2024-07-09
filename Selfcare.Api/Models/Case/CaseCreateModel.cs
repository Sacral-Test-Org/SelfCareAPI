// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Models.Case.CaseCreateModel
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

#nullable disable
namespace Selfcare.Api.Models.Case
{
  public class CaseCreateModel
  {
    public string Title { get; set; }

    public int AccountId { get; set; }

    public int CaseTypeId { get; set; }

    public string Comment { get; set; }

    public int? AdditionalDataValue { get; set; }
  }
}
