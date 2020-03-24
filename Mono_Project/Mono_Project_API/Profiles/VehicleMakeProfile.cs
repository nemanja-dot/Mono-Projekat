using Mono_Project_API.Models;
using Project.Model.Model;
using AutoMapper;
using Project.Common;

namespace Mono_Project_API.Profiles
{
    public class VehicleMakeProfile : Profile
    {
        public VehicleMakeProfile()
        {
            CreateMap<VehicleMake, VehicleMakeViewModel>()
                .ReverseMap();
            CreateMap<PagingDataList<VehicleMake>, PagingDataListViewModel<VehicleMakeViewModel>>()
                .ReverseMap();
        }
    }
}
