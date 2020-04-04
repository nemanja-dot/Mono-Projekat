using Microsoft.AspNetCore.Mvc;
using Mono_Project_API.Controllers;
using Mono_Project_API.Models;
using Moq;
using Project.Common;
using Project.Model.Model;
using Project.Service.Common.Interfaces.API;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

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
        private PagingDataList<VehicleMake> pagingDataListTest() 
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
        /*
        [Fact]
        public async Task GetVehicleMake_GetAllVehicleMakes_ReturnOkObjectResult()
        {
            // Arrange
            var pagingData = PagingDataTest();
            var pagingDataList = this.pagingDataListTest();
            var itemServiceMock = new Mock<IVehicleMakeServiceAPI>();
            itemServiceMock.Setup(service => service.GetAllAsync(pagingData))
                .ReturnsAsync(pagingDataList);

            var controller = new VehicleMakesController(itemServiceMock.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.GetVehicleMake(pagingData);

            // Assert
            // Assert.IsType<OkObjectResult>(result);
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        }
        */
        // GET: api/VehicleMakes/5
        [Fact]
        public async Task GetVehicleMake_GetVehicleMakeNull_ReturnNotFound()
        {
            // Arrange
            int testId = GetTestMake().Id;
            var mockService = new Mock<IVehicleMakeServiceAPI>();
            mockService.Setup(repo => repo.FindAsync(testId))
                .ReturnsAsync((VehicleMake)null);
            var controller = new VehicleMakesController(mockService.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.GetVehicleMake(testId);

            // Assert
            // var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            // mockRepo.Verify();
            // Assert.Equal(404, notFoundObjectResult.StatusCode);
            // Assert.Equal(testId, notFoundObjectResult.Value);
            var okResult = result.Should().BeOfType<NotFoundObjectResult>().Subject;
        }
        [Fact]
        public async Task GetVehicleMake_GetVehicleMakeViewModel_ReturnOkObjectResult()
        {
            // Arrange
            int testId = GetTestMake().Id;
            var testVehicleMake = GetTestMake();
            var mockService = new Mock<IVehicleMakeServiceAPI>();
            mockService.Setup(repo => repo.FindAsync(testId))
                .ReturnsAsync(testVehicleMake);
            var controller = new VehicleMakesController(mockService.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.GetVehicleMake(testId);

            // Assert
            //var okObjectResult = Assert.IsType<OkObjectResult>(result);
            //var returnVehicleMake = Assert.IsType<VehicleMakeViewModel>(okObjectResult.Value);
            //mockRepo.Verify();
            //Assert.Equal(testVehicleMake.Name, returnVehicleMake.Name);
            //Assert.Equal(testVehicleMake.Id, returnVehicleMake.Id);
            //Assert.Equal(testVehicleMake.Abrv, returnVehicleMake.Abrv);
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            result.Should().Equals(testVehicleMake);
        }

        // PUT: api/VehicleMakes/5 
        [Fact]
        public async Task PutVehicleMake_ForInvalidId_ReturnsBadRequest()
        {
            // Arrange
            int testId = 5; // testId != GetTestMakesViewModel().Id
            var testVehicleMake = GetTestMakesViewModel();
            var mockService = new Mock<IVehicleMakeServiceAPI>();

            var controller = new VehicleMakesController(mockService.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.PutVehicleMake(testId, testVehicleMake);

            // Assert
            //var badRequestResult = Assert.IsType<BadRequestResult>(result);
            //mockService.Verify();
            //Assert.Equal(400, badRequestResult.StatusCode);
            var okResult = result.Should().BeOfType<BadRequestResult>().Subject;
        }
        [Fact]
        public async Task PutVehicleMake_ForValidModelState_ReturnNoContent()
        {
            // Arrange
            int testId = GetTestMakesViewModel().Id;
            var testVehicleMake = GetTestMakesViewModel();
            var mockService = new Mock<IVehicleMakeServiceAPI>();

            var controller = new VehicleMakesController(mockService.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.PutVehicleMake(testId, testVehicleMake);

            // Assert
            //var noContentResult = Assert.IsType<NoContentResult>(result);
            //mockService.Verify();
            //Assert.Equal(204, noContentResult.StatusCode);
            var okResult = result.Should().BeOfType<NoContentResult>().Subject;
        }

        // POST: api/VehicleMakes
        [Fact]
        public async Task PostVehicleMake_Create_ReturnCreatedAtAction()
        {
            // Arrange
            int testId = GetTestMakesViewModel().Id;
            var testVehicleMake = GetTestMakesViewModel();
            var mockService = new Mock<IVehicleMakeServiceAPI>();
            var controller = new VehicleMakesController(mockService.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.PostVehicleMake(testVehicleMake);

            // Assert
            //var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            //mockService.Verify();
            //Assert.Equal(201, createdAtActionResult.StatusCode);
            var okResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
        }

        // DELETE: api/VehicleMakes/5
        [Fact]
        public async Task DeleteVehicleMake_ForIdNull_ReturnNotFound()
        {
            // Arrange
            int? testId = null;
            var testVehicleMake = GetTestMake();
            var mockService = new Mock<IVehicleMakeServiceAPI>();
            mockService.Setup(repo => repo.FindAsync(testId))
                .ReturnsAsync(testVehicleMake);
            var controller = new VehicleMakesController(mockService.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.DeleteVehicleMake(testId);

            // Assert
            //var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            //mockService.Verify();
            //Assert.Equal(404, notFoundObjectResult.StatusCode);
            //Assert.Equal(testId, notFoundObjectResult.Value);
            var okResult = result.Should().BeOfType<NotFoundObjectResult>().Subject;
        }
        [Fact]
        public async Task DeleteVehicleMake_ForVehicleMakeNull_ReturnNotFound()
        {
            // Arrange
            int testId = GetTestMake().Id;
            var testVehicleMake = GetTestMake();
            var mockService = new Mock<IVehicleMakeServiceAPI>();
            mockService.Setup(repo => repo.FindAsync(testId))
                .ReturnsAsync((VehicleMake)null);
            var controller = new VehicleMakesController(mockService.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.DeleteVehicleMake(testId);

            // Assert
            //var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            //mockService.Verify();
            //Assert.Equal(404, notFoundObjectResult.StatusCode);
            //Assert.Equal(testId, notFoundObjectResult.Value);
            var okResult = result.Should().BeOfType<NotFoundObjectResult>().Subject;
        }
        [Fact]
        public async Task DeleteVehicleMake_ForDeleteVehicleMake_ReturnOkObjectResult()
        {
            // Arrange
            int testId = GetTestMake().Id;
            var testVehicleMake = GetTestMake();
            var mockService = new Mock<IVehicleMakeServiceAPI>();
            mockService.Setup(repo => repo.FindAsync(testId))
                .ReturnsAsync(testVehicleMake);
            var controller = new VehicleMakesController(mockService.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.DeleteVehicleMake(testId);

            // Assert
            //var okObjectResult = Assert.IsType<OkObjectResult>(result);
            //mockService.Verify();
            //Assert.Equal(200, okObjectResult.StatusCode);
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        }

        
        

    }


}
