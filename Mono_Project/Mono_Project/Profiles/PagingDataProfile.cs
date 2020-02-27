using AutoMapper;
using Mono_Project.Models;
using Project.Service.Model;
using System;


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