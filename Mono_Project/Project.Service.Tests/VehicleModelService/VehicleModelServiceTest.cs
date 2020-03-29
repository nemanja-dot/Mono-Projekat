using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using Project.Common;
using Project.DAL.Context;
using Project.Model.Model;
using Project.Repository.Common.Interfaces.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Project.Service.Tests.VehicleModelService
{
    public class VehicleModelServiceTest
    {
        // CreatedAsync
        [Fact]
        public async Task CreatedAsync_TestCreating_ReturnTrue()
        {
            // Arrange
            var testObject = new VehicleModel() { Id = 1, Name = "Test", Abrv = "T" };
            var testList = new List<VehicleModel>() { testObject };

            var UoW = new Mock<IUnitOfWork>(); //{ CallBase = true }
            UoW.Setup(x => x.VehicleModel.Create(testObject)).ReturnsAsync(true);

            // Act
            var serviceVehicleModel = new Services.API.VehicleModelService(UoW.Object);
            var result = await serviceVehicleModel.CreateAsync(testObject);

            // Assert
            var okResult = result.Should().BeTrue();
        }

        // DeleteAsync
        [Fact]
        public async Task DeleteAsync_TestDelete_ReturnTrue()
        {
            // Arrange
            var testObject = new VehicleModel() { Id = 1, Name = "Test", Abrv = "T" };
            var testList = new List<VehicleModel>() { testObject };

            var UoW = new Mock<IUnitOfWork>(); //{ CallBase = true }
            UoW.Setup(x => x.VehicleModel.Delete(testObject)).ReturnsAsync(true); ;

            // Act
            var serviceVehicleModel = new Services.API.VehicleModelService(UoW.Object);
            var result = await serviceVehicleModel.DeleteAsync(testObject);

            // Assert
            var okResult = result.Should().BeTrue();
        }

        // FindAsync
        [Fact]
        public void FindAsync_TestFind_ReturnVehicleMake()
        {
            // Arrange
            var testObject = new VehicleModel() { Id = 1, Name = "Test", Abrv = "T" };
            var testList = new List<VehicleModel>() { testObject };

            var mockedDbContext = new Mock<ApplicationContext>();
            var mockDbSet = testList.AsQueryable().BuildMockDbSet();

            var UoW = new Mock<IUnitOfWork>(); //{ CallBase = true }
            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());
            UoW.Setup(x => x.VehicleModel.FindByCondition(x => x.Id == 1)).Returns(testList.AsQueryable());

            // Act
            var serviceVehicleModel = new Services.API.VehicleModelService(UoW.Object);
            var result = serviceVehicleModel.FindAsync(1);

            // Assert
            var okResult = result.IsCompleted.Should().BeTrue();
        }
        [Fact]
        public void FindAsync_TestFind_ReturnVehicleModelNull()
        {
            // Arrange
            var testObject = new VehicleModel() { Id = 1, Name = "Test", Abrv = "T" };
            var testList = new List<VehicleModel>() { testObject };

            var UoW = new Mock<IUnitOfWork>(); //{ CallBase = true }
            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());
            UoW.Setup(x => x.VehicleModel.FindByCondition(m => m.Id == testObject.Id));

            // Act
            var serviceVehicleModel = new Services.API.VehicleModelService(UoW.Object);
            var result = serviceVehicleModel.FindAsync(5); // testObject.Id != 5

            // Assert
            var okResult = result.IsCompleted.Should().BeTrue();
        }

        // GetAllAsync
        [Fact]
        public void GetAsync_TestGetAsync_ReturnAllVehicleModels()
        {
            // Arrange
            var testObject = new VehicleModel() { Id = 1, Name = "Test", Abrv = "T", };
            var testList = new List<VehicleModel>() { testObject };
            var pagingDataTest = new PagingData() { Count = 10, Page = 0, SearchString = null, SortOrder = null, VehicleMakeId = null };

            var mockedDbContext = new Mock<ApplicationContext>();
            var mockDbSet = testList.AsQueryable().BuildMockDbSet();

            var UoW = new Mock<IUnitOfWork>(); //{ CallBase = true }
            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());
            UoW.Setup(x => x.VehicleModel.FindAll()).Returns(mockDbSet.Object);

            // Act
            var serviceVehicleModel = new Services.API.VehicleModelService(UoW.Object);
            var result = serviceVehicleModel.GetAllAsync(pagingDataTest);

            // Assert
            //UoW.Verify();
            //Assert.True(result.IsCompleted);
            //Assert.True(result.IsCompletedSuccessfully);
            //Assert.False(result.IsFaulted);
            var okResult = result.Should().Equals(testList);
            result.IsCompletedSuccessfully.Should().BeTrue();
        }
        [Fact]
        public void GetAsync_TestGetAsyncIfPagingDataNull_ReturnAllVehicleModels()
        {
            // Arrange
            var testObject = new VehicleModel() { Id = 1, Name = "Test", Abrv = "T", };
            var testList = new List<VehicleModel>() { testObject };
            var pagingDataTest = new PagingData() { Count = 10, Page = 0, SearchString = null, SortOrder = null, VehicleMakeId = null };

            var mockedDbContext = new Mock<ApplicationContext>();
            var mockDbSet = testList.AsQueryable().BuildMockDbSet();

            var UoW = new Mock<IUnitOfWork>(); //{ CallBase = true }
            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());
            UoW.Setup(x => x.VehicleModel.FindAll()).Returns(mockDbSet.Object);

            // Act
            var serviceVehicleModel = new Services.API.VehicleModelService(UoW.Object);
            var result = serviceVehicleModel.GetAllAsync();

            // Assert
            //UoW.Verify();
            //Assert.True(result.IsCompleted);
            //Assert.True(result.IsCompletedSuccessfully);
            //Assert.False(result.IsFaulted);
            var okResult = result.Should().Equals(testList);
            result.IsCompletedSuccessfully.Should().BeTrue();
        }
        [Fact]
        public void GetAsync_TestGetForSearchString_ReturnAllSearchString()
        {
            // Arrange
            var testObject = new VehicleModel() { Id = 1, Name = "Test", Abrv = "T" };
            var testList = new List<VehicleModel>() { testObject };
            var pagingDataTest = new PagingData() { Count = 10, Page = 0, SearchString = "test", SortOrder = null, VehicleMakeId = null };

            var mockedDbContext = new Mock<ApplicationContext>();
            var mockDbSet = testList.AsQueryable().BuildMockDbSet();

            var UoW = new Mock<IUnitOfWork>(); //{ CallBase = true }

            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());
            UoW.Setup(x => x.VehicleModel.FindAll()).Returns(mockDbSet.Object);

            // Act
            var serviceVehicleModel = new Services.API.VehicleModelService(UoW.Object);
            var result = serviceVehicleModel.GetAllAsync(pagingDataTest);

            // Assert
            //UoW.Verify();
            //Assert.True(result.IsCompleted);
            //Assert.True(result.IsCompletedSuccessfully);
            //Assert.False(result.IsFaulted);
            var okResult = result.Should().Equals(testList);
            result.IsCompletedSuccessfully.Should().BeTrue();
        }

        // UpdateAsync
        [Fact]
        public async Task UpdetAsync_TestUpdate_ReturnTrue()
        {
            // Arrange
            var testObject = new VehicleModel() { Id = 1, Name = "Test", Abrv = "T" };
            var testList = new List<VehicleModel>() { testObject };

            var UoW = new Mock<IUnitOfWork>(); //{ CallBase = true }
            UoW.Setup(x => x.VehicleModel.Update(testObject)).ReturnsAsync(true); 

            // Act
            var serviceVehicleModel = new Services.API.VehicleModelService(UoW.Object);
            var result = await serviceVehicleModel.UpdateAsync(testObject);

            // Assert
            var okResult = result.Should().BeTrue();
        }

        //VehicleModelExists
        [Fact]
        public void VehicleModelExists_TestExists_ReturnVehicleModel()
        {
            // Arrange
            var testObject = new VehicleModel() { Id = 1, Name = "Test", Abrv = "T" };
            var testList = new List<VehicleModel>() { testObject };

            var mockedDbContext = new Mock<ApplicationContext>();
            var mockDbSet = testList.AsQueryable().BuildMockDbSet();

            var UoW = new Mock<IUnitOfWork>(); //{ CallBase = true }

            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            UoW.As<IQueryable<VehicleModel>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());
            UoW.Setup(x => x.VehicleModel.FindByCondition(m => m.Id == testObject.Id)).Returns(mockDbSet.Object);


            // Act
            var serviceVehicleModel = new Services.API.VehicleModelService(UoW.Object);
            var result = serviceVehicleModel.VehicleModelExists(testObject.Id);

            // Assert
            UoW.Verify();
            Assert.True(result.IsCompleted);
        }
    }
}
