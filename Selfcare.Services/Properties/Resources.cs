// Decompiled with JetBrains decompiler
// Type: Selfcare.Services.Properties.Resources
// Assembly: Selfcare.Services, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A5A76E13-8CFD-4949-AA66-F92CBBEE0424
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Services.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

#nullable disable
namespace Selfcare.Services.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (Selfcare.Services.Properties.Resources.resourceMan == null)
          Selfcare.Services.Properties.Resources.resourceMan = new ResourceManager("Selfcare.Services.Properties.Resources", typeof (Selfcare.Services.Properties.Resources).Assembly);
        return Selfcare.Services.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => Selfcare.Services.Properties.Resources.resourceCulture;
      set => Selfcare.Services.Properties.Resources.resourceCulture = value;
    }

    internal static string ResetPasswordEmailTemplate
    {
      get
      {
        return Selfcare.Services.Properties.Resources.ResourceManager.GetString(nameof (ResetPasswordEmailTemplate), Selfcare.Services.Properties.Resources.resourceCulture);
      }
    }

    internal static string SuccessfulTopupMailTemplate
    {
      get
      {
        return Selfcare.Services.Properties.Resources.ResourceManager.GetString(nameof (SuccessfulTopupMailTemplate), Selfcare.Services.Properties.Resources.resourceCulture);
      }
    }
  }
}
