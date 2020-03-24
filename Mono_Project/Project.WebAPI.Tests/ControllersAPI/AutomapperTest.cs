using AutoMapper;
using Mono_Project_API.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.WebAPI.Tests.ControllersAPI
{
    class AutomapperTest
    {
        private static IMapper _mapper;
        public static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    // Auto Mapper Configurations
                    var mappingConfig = new MapperConfiguration(mc =>
                    {
                        mc.AddProfile(new VehicleProfiles());
                    });

                    IMapper mapper = mappingConfig.CreateMapper();
                    _mapper = mapper;
                }

                return _mapper;
            }

        }
    }
}
