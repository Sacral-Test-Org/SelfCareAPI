// Decompiled with JetBrains decompiler
// Type: Selfcare.Persistence.Sql.UserQueries
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
  internal class UserQueries
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal UserQueries()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (UserQueries.resourceMan == null)
          UserQueries.resourceMan = new ResourceManager("Selfcare.Persistence.Sql.UserQueries", typeof (UserQueries).Assembly);
        return UserQueries.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => UserQueries.resourceCulture;
      set => UserQueries.resourceCulture = value;
    }

    internal static string Delete
    {
      get => UserQueries.ResourceManager.GetString(nameof (Delete), UserQueries.resourceCulture);
    }

    internal static string Insert
    {
      get => UserQueries.ResourceManager.GetString(nameof (Insert), UserQueries.resourceCulture);
    }

    internal static string Select
    {
      get => UserQueries.ResourceManager.GetString(nameof (Select), UserQueries.resourceCulture);
    }

    internal static string SelectByEmail
    {
      get
      {
        return UserQueries.ResourceManager.GetString(nameof (SelectByEmail), UserQueries.resourceCulture);
      }
    }

    internal static string SelectByUserName
    {
      get
      {
        return UserQueries.ResourceManager.GetString(nameof (SelectByUserName), UserQueries.resourceCulture);
      }
    }

    internal static string Update
    {
      get => UserQueries.ResourceManager.GetString(nameof (Update), UserQueries.resourceCulture);
    }
  }
}
