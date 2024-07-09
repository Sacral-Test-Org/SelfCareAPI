// Decompiled with JetBrains decompiler
// Type: Selfcare.Infrastructure.Entities.MasterTable.PlateViewData
// Assembly: Selfcare.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BEE7BF7A-9671-49F8-897B-41B38BF30A3E
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Infrastructure.dll

using System.Collections.Generic;

#nullable disable
namespace Selfcare.Infrastructure.Entities.MasterTable
{
  public class PlateViewData
  {
    public int Id { get; set; }

    public string Description { get; set; }

    public List<PlateTypeViewData> PlateTypes { get; set; }

    public PlateViewData() => this.PlateTypes = new List<PlateTypeViewData>();

    public void addPlateType(PlateTypeViewData plate) => this.PlateTypes.Add(plate);
  }
}
