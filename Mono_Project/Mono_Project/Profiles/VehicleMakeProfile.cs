using AutoMapper;
using Mono_Project.Models;
using Project.Service.Model;
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
