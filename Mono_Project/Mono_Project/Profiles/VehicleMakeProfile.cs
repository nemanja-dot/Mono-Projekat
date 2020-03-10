using AutoMapper;
using Mono_Project.Models;
using Project.Model.Model;

namespace Mono_Project.Profiles
{
    public class VehicleMakeProfile : AutoMapper.Profile
    {
        public VehicleMakeProfile()
        {
            CreateMap<VehicleMake, VehicleMakeViewModel>()
                .ReverseMap();
                
        }
    }
}
