using AutoMapper;
using Mono_Project_API.Models;
using Project.Common;
using Project.Model.Model;

namespace Mono_Project_API.Profiles
{
    public class VehicleModelProfile : Profile
    {
        public VehicleModelProfile()
        {
            CreateMap<VehicleModel, VehicleModelViewModel>()
                .ReverseMap();
            CreateMap<PagingDataList<VehicleModel>, PagingDataListViewModel<VehicleModelViewModel>>()
                .ReverseMap();
        }
    }
}
