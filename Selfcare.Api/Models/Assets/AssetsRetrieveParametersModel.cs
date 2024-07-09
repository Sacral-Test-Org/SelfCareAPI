// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Models.Assets.AssetsRetrieveParametersModel
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

#nullable disable
namespace Selfcare.Api.Models.Assets
{
  public class AssetsRetrieveParametersModel
  {
    public int AccountId { get; set; }

    public int StatusId { get; set; }

    public int AssetTypeId { get; set; }

    public string Identifier { get; set; }
  }
}
