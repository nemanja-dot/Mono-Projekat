using AutoMapper;
using Mono_Project.Models;
using Project.Service.Model;
using System;


namespace Mono_Project.Profiles
{
    public class VehicleMadeProfile : Profile
    {
        public VehicleMadeProfile()
        {
            CreateMap<VehicleModel, VehicleModelViewModel>()
                .ReverseMap();
        }
    }
}
