// Decompiled with JetBrains decompiler
// Type: Selfcare.Domain.BackOffice.Mappings.MasterTablesProfile
// Assembly: Selfcare.Domain.BackOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 925D2EFC-2F9C-4686-933B-32D249405106
// Assembly location: C:\Users\vgunturu\Downloads\OneDrive_1_9-7-2024\Selfcare.Domain.BackOffice.dll

using AutoMapper;
using Selfcare.Domain.BackOffice.Models.MasterTables;
using Selfcare.Infrastructure.Entities.MasterTable;
using System;
using System.Linq.Expressions;

#nullable disable
namespace Selfcare.Domain.BackOffice.Mappings
{
  internal class MasterTablesProfile : Profile
  {
    public MasterTablesProfile()
    {
      this.CreateMap<MasterTableResponseModel, MasterTableViewData>().ForMember<string>((Expression<Func<MasterTableViewData, string>>) (dest => dest.ItemName), (Action<IMemberConfigurationExpression<MasterTableResponseModel, MasterTableViewData, string>>) (opt => opt.MapFrom<string>((Expression<Func<MasterTableResponseModel, string>>) (src => src.Description))));
      this.CreateMap<MasterTableRootResponseModel, MasterTableRootViewData>();
    }
  }
}
