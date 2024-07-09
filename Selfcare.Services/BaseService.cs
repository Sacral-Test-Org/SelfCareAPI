// Decompiled with JetBrains decompiler
// Type: Selfcare.Services.BaseService
// Assembly: Selfcare.Services, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A5A76E13-8CFD-4949-AA66-F92CBBEE0424
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Services.dll

using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace Selfcare.Services
{
  public class BaseService
  {
    protected static IEnumerable<T> GetItemsFromList<T>(List<T> listOfItems)
    {
      return (IEnumerable<T>) listOfItems.OfType<T>().ToList<T>();
    }
  }
}
