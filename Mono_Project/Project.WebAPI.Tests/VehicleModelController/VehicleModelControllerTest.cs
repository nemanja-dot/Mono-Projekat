using FluentAssertions;
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

namespace Project.WebAPI.Tests.ControllersAPI
{
    public class VehicleModelControllerTest
    {
        private VehicleModelViewModel GetTestModelViewModel()
        {
            var vehicleModelViewModel = new VehicleModelViewModel()
            {
                Id = 2,
                Name = "Test",
                Abrv = "T",
            };
            return vehicleModelViewModel;
        }

        private VehicleModel GetTestModel()
        {
            var vehicleModel = new VehicleModel()
            {
                Id = 2,
                Name = "Test",
                Abrv = "T",
                VehicleMakeId = 0,
                VehicleMake = null

            };
            return vehicleModel;
        }


        private PagingData PagingDataTest()
        {
            var pagingData = new PagingData
            {
                Count = 0,
                Page = 0,
                SearchString = null,
                SortOrder = null

            };
            return pagingData;
        }
        private PagingDataList<VehicleModel> pagingDataList()
        {
            var results = new List<VehicleModel>
            {
                new VehicleModel()
                {
                    Id = 2,
                    Name = "Test",
                    Abrv = "T"
                    }
            };
            var count = 10;
            var currentPage = 0;
            var take = 10;



            return new PagingDataList<VehicleModel>(results, count, currentPage, take);
        }

        // GET: api/VehicleModel
        [Fact]
        public async Task GetVehicleModel_GetAllVehicleModel_ReturnOkObjectResult()
        {
            // Arrange
            var pagingData = PagingDataTest();
            var pagingDataList = this.pagingDataList();
            var itemServiceMock = new Mock<IVehicleModelServiceAPI>();
            itemServiceMock.Setup(service => service.GetAllAsync(pagingData)).ReturnsAsync(pagingDataList);

            var controller = new VehicleModelsController(itemServiceMock.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.GetVehicleModel(pagingData);

            // Assert
            // Assert.IsType<OkObjectResult>(result);
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        }
        // GET: api/VehicleModel/5
        [Fact]
        public async Task GetVehicleModel_GetVehicleModelNull_ReturnNotFound()
        {
            // Arrange
            int testId = GetTestModel().Id;
            var mockService = new Mock<IVehicleModelServiceAPI>();
            mockService.Setup(repo => repo.FindAsync(testId))
                .ReturnsAsync((VehicleModel)null);
            var controller = new VehicleModelsController(mockService.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.GetVehicleModel(testId);

            // Assert
            // var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            // mockRepo.Verify();
            // Assert.Equal(404, notFoundObjectResult.StatusCode);
            // Assert.Equal(testId, notFoundObjectResult.Value);
            var okResult = result.Should().BeOfType<NotFoundObjectResult>().Subject;
        }
        [Fact]
        public async Task GetVehicleModel_GetVehicleModelViewModel_ReturnOkObjectResult()
        {
            // Arrange
            int testId = GetTestModel().Id;
            var testVehicleModel = GetTestModel();
            var mockService = new Mock<IVehicleModelServiceAPI>();
            mockService.Setup(repo => repo.FindAsync(testId))
                .ReturnsAsync(testVehicleModel);
            var controller = new VehicleModelsController(mockService.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.GetVehicleModel(testId);

            // Assert
            //var okObjectResult = Assert.IsType<OkObjectResult>(result);
            //var returnVehicleMake = Assert.IsType<VehicleMakeViewModel>(okObjectResult.Value);
            //mockRepo.Verify();
            //Assert.Equal(testVehicleMake.Name, returnVehicleMake.Name);
            //Assert.Equal(testVehicleMake.Id, returnVehicleMake.Id);
            //Assert.Equal(testVehicleMake.Abrv, returnVehicleMake.Abrv);
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            result.Should().Equals(testVehicleModel);
        }

        // PUT: api/VehicleModels/5 
        [Fact]
        public async Task PutVehicleModel_ForInvalidId_ReturnsBadRequest()
        {
            // Arrange
            int testId = 5; // testId != GetTestModelViewModel().Id
            var testVehicleModel = GetTestModelViewModel();
            var mockService = new Mock<IVehicleModelServiceAPI>();

            var controller = new VehicleModelsController(mockService.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.PutVehicleModel(testId, testVehicleModel);

            // Assert
            //var badRequestResult = Assert.IsType<BadRequestResult>(result);
            //mockService.Verify();
            //Assert.Equal(400, badRequestResult.StatusCode);
            var okResult = result.Should().BeOfType<BadRequestResult>().Subject;
        }
        [Fact]
        public async Task PutVehicleModel_ForValidModelState_ReturnNoContent()
        {
            // Arrange
            int testId = GetTestModelViewModel().Id;
            var testVehicleModel = GetTestModelViewModel();
            var mockService = new Mock<IVehicleModelServiceAPI>();

            var controller = new VehicleModelsController(mockService.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.PutVehicleModel(testId, testVehicleModel);

            // Assert
            //var noContentResult = Assert.IsType<NoContentResult>(result);
            //mockService.Verify();
            //Assert.Equal(204, noContentResult.StatusCode);
            var okResult = result.Should().BeOfType<NoContentResult>().Subject;
        }

        // POST: api/VehicleModels
        [Fact]
        public async Task PostVehicleModels_Create_ReturnCreatedAtAction()
        {
            // Arrange
            int testId = GetTestModelViewModel().Id;
            var testVehicleModel = GetTestModelViewModel();
            var mockService = new Mock<IVehicleModelServiceAPI>();
            var controller = new VehicleModelsController(mockService.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.Create(testVehicleModel);

            // Assert
            //var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            //mockService.Verify();
            //Assert.Equal(201, createdAtActionResult.StatusCode);
            var okResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
        }

        // DELETE: api/VehicleModel/5
        [Fact]
        public async Task DeleteVehicleModels_ForIdNull_ReturnNotFound()
        {
            // Arrange
            int? testId = null;
            var testVehicleModel = GetTestModel();
            var mockService = new Mock<IVehicleModelServiceAPI>();
            mockService.Setup(repo => repo.FindAsync(testId))
                .ReturnsAsync(GetTestModel());
            var controller = new VehicleModelsController(mockService.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.DeleteVehicleModel(testId);

            // Assert
            //var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            //mockService.Verify();
            //Assert.Equal(404, notFoundObjectResult.StatusCode);
            //Assert.Equal(testId, notFoundObjectResult.Value);
            var okResult = result.Should().BeOfType<NotFoundObjectResult>().Subject;
        }
        [Fact]
        public async Task DeleteVehicleModel_ForVehicleModelNull_ReturnNotFound()
        {
            // Arrange
            int testId = GetTestModel().Id;
            var testVehicleModel = GetTestModel();
            var mockService = new Mock<IVehicleModelServiceAPI>();
            mockService.Setup(repo => repo.FindAsync(testId))
                .ReturnsAsync((VehicleModel)null);
            var controller = new VehicleModelsController(mockService.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.DeleteVehicleModel(testId);

            // Assert
            //var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            //mockService.Verify();
            //Assert.Equal(404, notFoundObjectResult.StatusCode);
            //Assert.Equal(testId, notFoundObjectResult.Value);
            var okResult = result.Should().BeOfType<NotFoundObjectResult>().Subject;
        }
        [Fact]
        public async Task DeleteVehicleModel_ForDeleteVehicleModel_ReturnOkObjectResult()
        {
            // Arrange
            int testId = GetTestModel().Id;
            var testVehicleModel = GetTestModel();
            var mockService = new Mock<IVehicleModelServiceAPI>();
            mockService.Setup(repo => repo.FindAsync(testId))
                .ReturnsAsync(testVehicleModel);
            var controller = new VehicleModelsController(mockService.Object, AutomapperTest.Mapper);

            // Act
            var result = await controller.DeleteVehicleModel(testId);

            // Assert
            //var okObjectResult = Assert.IsType<OkObjectResult>(result);
            //mockService.Verify();
            //Assert.Equal(200, okObjectResult.StatusCode);
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        }
    }
}
