using AutoMapper;
using Mono_Project.Models;
using Project.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mono_Project.Profiles
{
    public class PagingDataListProfile : Profile
    {
        public PagingDataListProfile()
        {
            CreateMap<PagingDataList<VehicleMake>, PagingDataList<VehicleMakeViewModel>>()
                .ReverseMap();
            CreateMap<PagingDataList<VehicleModel>, PagingDataList<VehicleModelViewModel>>()
                .ReverseMap();
        }
    }
}
