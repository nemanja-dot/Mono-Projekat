using AutoMapper;
using Mono_Project.Models;
using Project.Common;
using Project.Model.Model;


namespace Mono_Project.Profiles
{
    public class PagingDataProfile : Profile
    {
        public PagingDataProfile()
        {
            CreateMap<PagingData, PagingDataViewModel>()
                .ReverseMap();
        }
    }
}