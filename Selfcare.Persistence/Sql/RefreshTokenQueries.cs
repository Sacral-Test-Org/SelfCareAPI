// Decompiled with JetBrains decompiler
// Type: Selfcare.Persistence.Sql.RefreshTokenQueries
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
  internal class RefreshTokenQueries
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal RefreshTokenQueries()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (RefreshTokenQueries.resourceMan == null)
          RefreshTokenQueries.resourceMan = new ResourceManager("Selfcare.Persistence.Sql.RefreshTokenQueries", typeof (RefreshTokenQueries).Assembly);
        return RefreshTokenQueries.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => RefreshTokenQueries.resourceCulture;
      set => RefreshTokenQueries.resourceCulture = value;
    }

    internal static string Delete
    {
      get
      {
        return RefreshTokenQueries.ResourceManager.GetString(nameof (Delete), RefreshTokenQueries.resourceCulture);
      }
    }

    internal static string Insert
    {
      get
      {
        return RefreshTokenQueries.ResourceManager.GetString(nameof (Insert), RefreshTokenQueries.resourceCulture);
      }
    }

    internal static string Select
    {
      get
      {
        return RefreshTokenQueries.ResourceManager.GetString(nameof (Select), RefreshTokenQueries.resourceCulture);
      }
    }

    internal static string SelectByUsernameAndClientId
    {
      get
      {
        return RefreshTokenQueries.ResourceManager.GetString(nameof (SelectByUsernameAndClientId), RefreshTokenQueries.resourceCulture);
      }
    }
  }
}
