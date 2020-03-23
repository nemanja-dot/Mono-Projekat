using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mono_Project_API.Controllers;
using Mono_Project_API.Models;
using Mono_Project_API.Profiles;
using Moq;
using Project.Common;
using Project.Model.Model;
using Project.Service.Common.Interfaces.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Project.WebAPI.Tests.ControllersAPI
{
    public class VehicleMakesControllerTest
    {
        /* 
        //Test
        private readonly Mock<IVehicleMakeServiceAPI> _mockService;
        private readonly VehicleMakesController _vehicleMakesController;
       
        public VehicleMakesControllerTest()
        {
            _mockService = new Mock<IVehicleMakeServiceAPI>();
            _vehicleMakesController = new VehicleMakesController(_mockService.Object);
        }
        */

        // GET: api/VehicleMakes/5
        [Fact]
        public async Task GetVehicleMake_ReturnsHttpNotFound_ForInvalidId()
        {
            // Arrange
            int testId = -10;
            var mockRepo = new Mock<IVehicleMakeServiceAPI>();
            mockRepo.Setup(repo => repo.FindAsync(testId))
                .ReturnsAsync((VehicleMake)null);
            var controller = new VehicleMakesController(mockRepo.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.GetVehicleMake(testId);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(testId, notFoundObjectResult.Value);
        }

        // DELETE: api/VehicleMakes/5
        [Fact]
        public async Task DeleteVehicleMake_ReturnsHttpNotFound_ForInvalidId()
        {
            // Arrange
            int testId = -10;
            var mockRepo = new Mock<IVehicleMakeServiceAPI>();
            mockRepo.Setup(repo => repo.FindAsync(testId))
                .ReturnsAsync((VehicleMake)null);
            var controller = new VehicleMakesController(mockRepo.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.DeleteVehicleMake(testId);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(testId, notFoundObjectResult.Value);
        }
        [Fact]
        public async Task DeleteVehicleMake_ReturnsHttpNotFound_ForIdNull()
        {
            // Arrange
            int? testId = null;
            var mockRepo = new Mock<IVehicleMakeServiceAPI>();
            mockRepo.Setup(repo => repo.FindAsync(testId))
                .ReturnsAsync((VehicleMake)null);
            var controller = new VehicleMakesController(mockRepo.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.DeleteVehicleMake(testId);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(testId, notFoundObjectResult.Value);
        }

        // POST: api/VehicleMakes
        [Fact]
        public async Task PostVehicleMake_ReturnsBadRequest_GivenInvalidModel()
        {
            // Arrange & Act
            var mockRepo = new Mock<IVehicleMakeServiceAPI>();
            var controller = new VehicleMakesController(mockRepo.Object, AutomapperTest.Mapper);
            controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = await controller.PostVehicleMake(vehicleMake: null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
        
        [Fact]
        public async Task GetItemsReturnsOk()
        {
            // Arrange
            var pagingData = new PagingData
            {
                Count = 0,
                Page = 0,
                SearchString = null,
                SortOrder = null,
                VehicleMakeId = 0
                
            }; 
            var itemServiceMock = new Mock<IVehicleMakeServiceAPI>();
            itemServiceMock.Setup(service => service.GetAllAsync(pagingData));

            var controller = new VehicleMakesController(itemServiceMock.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.GetVehicleMake(pagingData);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        // PUT: api/VehicleMakes/5 
        /*
        [Fact]
        public async Task PutVehicleMake_ReturnsHttpNotFound_ForInvalidId()
        {
            // Arrange
            int testId = -10;
            var mockRepo = new Mock<IMapper>();
            mockRepo.Setup(repo => repo.FindAsync(testId))
                .ReturnsAsync((VehicleMakeViewModel)null);
            var controller = new VehicleMakesController(mockRepo.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.PutVehicleMake(testId, vehicleMake);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(testId, notFoundObjectResult.Value);
        } */
    }


}
