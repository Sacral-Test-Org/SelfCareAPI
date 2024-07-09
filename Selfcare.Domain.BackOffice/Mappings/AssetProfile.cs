// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.BackOffice.Mappings.AssetProfile
// Assembly: Selfcare.Domain.BackOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 925D2EFC-2F9C-4686-933B-32D249405106
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.BackOffice.dll

using AutoMapper;
using Selfcare.Domain.BackOffice.Models.Assets;
using Selfcare.Infrastructure.Entities.Assets;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;

#nullable disable
namespace Selfcare.Domain.BackOffice.Mappings
{
  internal class AssetProfile : Profile
  {
    public AssetProfile()
    {
      this.CreateMap<AssetResponseModel, AssetViewData>().ForMember<int>((Expression<Func<AssetViewData, int>>) (dest => dest.AccountUnitId), (Action<IMemberConfigurationExpression<AssetResponseModel, AssetViewData, int>>) (opt => opt.MapFrom<int>((Expression<Func<AssetResponseModel, int>>) (src => src.AccountUnitID))));
      this.CreateMap<AssetResponseModel, AssetViewData>().ForMember<string>((Expression<Func<AssetViewData, string>>) (dest => dest.AssetIdentifier), (Action<IMemberConfigurationExpression<AssetResponseModel, AssetViewData, string>>) (opt => opt.MapFrom<string>((Expression<Func<AssetResponseModel, string>>) (src => src.AssetIdentifier)))).AfterMap((Action<AssetResponseModel, AssetViewData>) ((src, dest) =>
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
      this.CreateMap<AssetDetailsResponseModel, AssetDetailsViewData>().ForMember<int>((Expression<Func<AssetDetailsViewData, int>>) (dest => dest.StatusId), (Action<IMemberConfigurationExpression<AssetDetailsResponseModel, AssetDetailsViewData, int>>) (opt => opt.MapFrom<int>((Expression<Func<AssetDetailsResponseModel, int>>) (src => src.AccountUnitStatus)))).ForMember<int>((Expression<Func<AssetDetailsViewData, int>>) (dest => dest.OverallClassId), (Action<IMemberConfigurationExpression<AssetDetailsResponseModel, AssetDetailsViewData, int>>) (opt => opt.MapFrom<int>((Expression<Func<AssetDetailsResponseModel, int>>) (src => src.Class)))).ForMember<DateTime>((Expression<Func<AssetDetailsViewData, DateTime>>) (dest => dest.ValidFromDate), (Action<IMemberConfigurationExpression<AssetDetailsResponseModel, AssetDetailsViewData, DateTime>>) (opt => opt.MapFrom<DateTime>((Expression<Func<AssetDetailsResponseModel, DateTime>>) (src => src.ValidFrom)))).ForMember<DateTime?>((Expression<Func<AssetDetailsViewData, DateTime?>>) (dest => dest.ValidToDate), (Action<IMemberConfigurationExpression<AssetDetailsResponseModel, AssetDetailsViewData, DateTime?>>) (opt => opt.MapFrom<DateTime?>((Expression<Func<AssetDetailsResponseModel, DateTime?>>) (src => src.ValidTo))));
      this.CreateMap<VehicleResponseModel, VehicleViewData>();
    }
  }
}
