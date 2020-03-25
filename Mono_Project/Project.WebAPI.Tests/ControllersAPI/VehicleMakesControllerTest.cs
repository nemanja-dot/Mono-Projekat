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
using System.Linq;

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
        private VehicleMakeViewModel GetTestMakesViewModel()
        {
            var vehicleMakeViewModel = new VehicleMakeViewModel()
            {
                Id = 2,
                Name = "Test",
                Abrv = "T",
            };
            return vehicleMakeViewModel;
        }

        private VehicleMake GetTestMake()
        {
            var vehicleMake = new VehicleMake()
            {
                Id = 2,
                Name = "Test",
                Abrv = "T",
                VehicleModels = null
            };
            return vehicleMake;
        }


        private PagingData PagingDataTest()
        {
            var pagingData = new PagingData
            {
                Count = 0,
                Page = 0,
                SearchString = null,
                SortOrder = null,
                VehicleMakeId = 0

            };
            return pagingData;
        }
        private PagingDataList<VehicleMake> pagingDataList() 
        {
            var results = new List<VehicleMake>
            {
                new VehicleMake()
                {
                    Id = 2,
                    Name = "Test",
                    Abrv = "T",
                    VehicleModels = null
                    }
            };
            var count = 10;
            var currentPage = 0;
            var take = 10;



            return new PagingDataList<VehicleMake>(results, count, currentPage, take);
        }


        // GET: api/VehicleMakes
        [Fact]
        public async Task GetVehicleMake_ReturnsOkObjectResult_ForGetVehicleMake()
        {
            // Arrange
            var pagingData = PagingDataTest();
            var pagingDataList = this.pagingDataList();
            var itemServiceMock = new Mock<IVehicleMakeServiceAPI>();
            itemServiceMock.Setup(service => service.GetAllAsync(pagingData))
                .ReturnsAsync(pagingDataList);

            var controller = new VehicleMakesController(itemServiceMock.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.GetVehicleMake(pagingData);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        // GET: api/VehicleMakes/5
        [Fact]
        public async Task GetVehicleMake_ReturnsHttpNotFound_ForVehicleMakeNull()
        {
            // Arrange
            int testId = GetTestMake().Id;
            var mockRepo = new Mock<IVehicleMakeServiceAPI>();
            mockRepo.Setup(repo => repo.FindAsync(testId))
                .ReturnsAsync((VehicleMake)null);
            var controller = new VehicleMakesController(mockRepo.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.GetVehicleMake(testId);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            mockRepo.Verify();
            Assert.Equal(404, notFoundObjectResult.StatusCode);
            Assert.Equal(testId, notFoundObjectResult.Value);
        }
        [Fact]
        public async Task GetVehicleMake_ReturnsVehicleMakeViewModel_ForGetVehicleMake()
        {
            // Arrange
            int testId = GetTestMake().Id;
            var testVehicleMake = GetTestMake();
            var mockRepo = new Mock<IVehicleMakeServiceAPI>();
            mockRepo.Setup(repo => repo.FindAsync(testId))
                .ReturnsAsync(testVehicleMake);
            var controller = new VehicleMakesController(mockRepo.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.GetVehicleMake(testId);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var returnVehicleMake = Assert.IsType<VehicleMakeViewModel>(okObjectResult.Value);
            mockRepo.Verify();
            Assert.Equal(testVehicleMake.Name, returnVehicleMake.Name);
            Assert.Equal(testVehicleMake.Id, returnVehicleMake.Id);
            Assert.Equal(testVehicleMake.Abrv, returnVehicleMake.Abrv);
        }

        // PUT: api/VehicleMakes/5 
        [Fact]
        public async Task PutVehicleMake_ReturnsBadRequest_ForInvalidId()
        {
            // Arrange
            int testId = 5; // testId != GetTestMakesViewModel().Id
            var testVehicleMake = GetTestMakesViewModel();
            var mockRepo = new Mock<IVehicleMakeServiceAPI>();
            mockRepo.Setup(repo => repo.FindAsync(testId))
                .ReturnsAsync(GetTestMake());
            var controller = new VehicleMakesController(mockRepo.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.PutVehicleMake(testId, GetTestMakesViewModel());

            // Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
            mockRepo.Verify();
            Assert.Equal(400, badRequestResult.StatusCode);
        }
        [Fact]
        public async Task PutVehicleMake_Update_ForValidId()
        {
            // Arrange
            int testId = GetTestMakesViewModel().Id;
            var testVehicleMake = GetTestMakesViewModel();
            var mockRepo = new Mock<IVehicleMakeServiceAPI>();
            mockRepo.Setup(repo => repo.FindAsync(testId))
                .ReturnsAsync(GetTestMake());
            var controller = new VehicleMakesController(mockRepo.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.PutVehicleMake(testId, GetTestMakesViewModel());

            // Assert
            var noContentResult = Assert.IsType<NoContentResult>(result);
            mockRepo.Verify();
            Assert.Equal(204, noContentResult.StatusCode);
        }

        // POST: api/VehicleMakes
        [Fact]
        public async Task PostVehicleMake_Create_ForModelIsValid()
        {
            // Arrange
            int testId = GetTestMakesViewModel().Id;
            var testVehicleMake = GetTestMakesViewModel();
            var mockRepo = new Mock<IVehicleMakeServiceAPI>();
            mockRepo.Setup(repo => repo.FindAsync(testId))
                .ReturnsAsync(GetTestMake());
            var controller = new VehicleMakesController(mockRepo.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.PostVehicleMake(GetTestMakesViewModel());

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            mockRepo.Verify();
            Assert.Equal(201, createdAtActionResult.StatusCode);
        }

        // DELETE: api/VehicleMakes/5
        [Fact]
        public async Task DeleteVehicleMake_ReturnsHttpNotFound_ForIdNull()
        {
            // Arrange
            int? testId = null;
            var testVehicleMake = GetTestMake();
            var mockRepo = new Mock<IVehicleMakeServiceAPI>();
            mockRepo.Setup(repo => repo.FindAsync(testId))
                .ReturnsAsync(GetTestMake());
            var controller = new VehicleMakesController(mockRepo.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.DeleteVehicleMake(testId);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            mockRepo.Verify();
            Assert.Equal(404, notFoundObjectResult.StatusCode);
            Assert.Equal(testId, notFoundObjectResult.Value);
        }
        [Fact]
        public async Task DeleteVehicleMake_ReturnsHttpNotFound_ForVehicleMakeNull()
        {
            // Arrange
            int testId = GetTestMake().Id;
            var testVehicleMake = GetTestMake();
            var mockRepo = new Mock<IVehicleMakeServiceAPI>();
            mockRepo.Setup(repo => repo.FindAsync(testId))
                .ReturnsAsync((VehicleMake)null);
            var controller = new VehicleMakesController(mockRepo.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.DeleteVehicleMake(testId);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            mockRepo.Verify();
            Assert.Equal(404, notFoundObjectResult.StatusCode);
            Assert.Equal(testId, notFoundObjectResult.Value);
        }
        [Fact]
        public async Task DeleteVehicleMake_ReturnsVehicleMakeViewModel_ForDeleteVehicleMake()
        {
            // Arrange
            int testId = GetTestMake().Id;
            var testVehicleMake = GetTestMake();
            var mockRepo = new Mock<IVehicleMakeServiceAPI>();
            mockRepo.Setup(repo => repo.FindAsync(testId))
                .ReturnsAsync(testVehicleMake);
            var controller = new VehicleMakesController(mockRepo.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.DeleteVehicleMake(testId);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            mockRepo.Verify();
            Assert.Equal(200, okObjectResult.StatusCode);
        }

        
        

    }


}
