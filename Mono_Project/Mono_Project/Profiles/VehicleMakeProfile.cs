using AutoMapper;
using Mono_Project.Models;
using Project.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mono_Project.Profiles
{
    public class VehicleMakeProfile : Profile
    {
        public VehicleMakeProfile()
        {
            CreateMap<VehicleMake, VehicleMakeViewModel>();
        }
    }
}
