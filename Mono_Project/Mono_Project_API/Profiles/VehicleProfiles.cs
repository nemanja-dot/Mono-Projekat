using Mono_Project_API.Models;
using Project.Model.Model;
using AutoMapper;
using Project.Common;

namespace Mono_Project_API.Profiles
{
    public class VehicleProfiles : Profile
    {
        public VehicleProfiles()
        {
            CreateMap<VehicleMake, VehicleMakeViewModel>()
                .ReverseMap();

            CreateMap<PagingDataList<VehicleMake>, PagingDataListViewModel<VehicleMakeViewModel>>()
                .ReverseMap();

            CreateMap<VehicleModel, VehicleModelViewModel>()
               .ReverseMap();

            CreateMap<PagingDataList<VehicleModel>, PagingDataListViewModel<VehicleModelViewModel>>()
                .ReverseMap();

        }
    }
}
