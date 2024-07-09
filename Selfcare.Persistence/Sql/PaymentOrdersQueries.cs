// Decompiled with JetBrains decompiler
// Type: Selfcare.Persistence.Sql.PaymentOrdersQueries
// Assembly: Selfcare.Persistence, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC28A518-E4A9-4CDD-8B12-F4E86AD0AF6A
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Persistence.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

#nullable disable
namespace Selfcare.Persistence.Sql
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class PaymentOrdersQueries
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal PaymentOrdersQueries()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (PaymentOrdersQueries.resourceMan == null)
          PaymentOrdersQueries.resourceMan = new ResourceManager("Selfcare.Persistence.Sql.PaymentOrdersQueries", typeof (PaymentOrdersQueries).Assembly);
        return PaymentOrdersQueries.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => PaymentOrdersQueries.resourceCulture;
      set => PaymentOrdersQueries.resourceCulture = value;
    }

    internal static string Insert
    {
      get
      {
        return PaymentOrdersQueries.ResourceManager.GetString(nameof (Insert), PaymentOrdersQueries.resourceCulture);
      }
    }

    internal static string SelectByOrderId
    {
      get
      {
        return PaymentOrdersQueries.ResourceManager.GetString(nameof (SelectByOrderId), PaymentOrdersQueries.resourceCulture);
      }
    }

    internal static string SelectByOrderIdAndStatus
    {
      get
      {
        return PaymentOrdersQueries.ResourceManager.GetString(nameof (SelectByOrderIdAndStatus), PaymentOrdersQueries.resourceCulture);
      }
    }

    internal static string Update
    {
      get
      {
        return PaymentOrdersQueries.ResourceManager.GetString(nameof (Update), PaymentOrdersQueries.resourceCulture);
      }
    }
  }
}
