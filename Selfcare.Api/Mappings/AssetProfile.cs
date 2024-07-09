// Decompiled with JetBrains decompiler
// Type: Selfcare.Api.Mappings.AssetProfile
// Assembly: Selfcare.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 933171C7-4848-4BC5-8A5A-40A781554582
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Api.dll

using AutoMapper;
using Selfcare.Api.Models.Assets;
using Selfcare.Infrastructure.Entities.Assets;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;

#nullable disable
namespace Selfcare.Api.Mappings
{
  public class AssetProfile : Profile
  {
    public AssetProfile()
    {
      this.CreateMap<AssetViewData, AssetViewModel>();
      this.CreateMap<VehicleViewData, VehicleViewModel>();
      this.CreateMap<AssetsRetrieveParametersModel, AssetsRetrieveParameters>();
      this.CreateMap<AssetsFilterParametersModel, AssetsFilterParameters>();
      this.CreateMap<AssetDetailsViewData, AssetDetailsViewModel>().ForMember<string>((Expression<Func<AssetDetailsViewModel, string>>) (dest => dest.AssetIdentifier), (Action<IMemberConfigurationExpression<AssetDetailsViewData, AssetDetailsViewModel, string>>) (opt => opt.MapFrom<string>((Expression<Func<AssetDetailsViewData, string>>) (src => src.Identifier)))).AfterMap((Action<AssetDetailsViewData, AssetDetailsViewModel>) ((src, dest) =>
      {
        string[] source1 = dest.AssetIdentifier.Split('-');
        string[] source2 = ConfigurationManager.AppSettings["LPNPattern"].Split('-');
        int result1;
        int.TryParse(((IEnumerable<string>) source2).Min<string>(), out result1);
        int result2;
        int.TryParse(((IEnumerable<string>) source2).Max<string>(), out result2);
        string[] strArray;
        if (((IEnumerable<string>) source1).Count<string>() == result2 && result1 > 0)
        {
          strArray = new string[((IEnumerable<string>) source2).Count<string>()];
          for (int index = 0; index < ((IEnumerable<string>) source2).Count<string>(); ++index)
          {
            string s = source2[index];
            strArray[index] = source1[int.Parse(s) - 1];
          }
        }
        else
          strArray = source1;
        dest.AssetIdentifier = string.Join("-", strArray);
      }));
    }
  }
}
