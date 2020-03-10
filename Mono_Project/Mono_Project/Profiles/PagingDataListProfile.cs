using AutoMapper;
using Mono_Project.Models;
using Project.Model.Model;

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
