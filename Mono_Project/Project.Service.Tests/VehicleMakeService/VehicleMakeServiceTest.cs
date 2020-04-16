using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Moq;
using Project.Common;
using Project.DAL.Context;
using Project.Model.Model;
using Project.Repository.API;
using Project.Repository.Common.Interfaces.API;
using Project.Repository.Repository.API;
using Project.Service.Common.Interfaces.API;
using Project.Service.Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Project.Service.Tests.VehicleMakeService;
using MockQueryable.Moq;
using FluentAssertions;
using System.Threading.Tasks;

namespace Project.Service.Tests.VehicleMakeService
{
    public class VehicleMakeServiceTest
    {
        // CreatedAsync
        [Fact]
        public async Task CreatedAsync_TestCreating_ReturnTrue()
        {
            // Arrange
            var testObject = new VehicleMake() { Id = 1, Name = "Test", Abrv = "T", VehicleModels = null };
            var testList = new List<VehicleMake>() { testObject };

            var UoW = new Mock<IUnitOfWork>(); //{ CallBase = true }
            UoW.Setup(x => x.VehicleMake.Create(testObject)).ReturnsAsync(true);

            // Act
            var serviceVehicleMake = new Services.API.VehicleMakeService(UoW.Object);
            var result = await serviceVehicleMake.CreateAsync(testObject);

            // Assert
            var okResult = result.Should().BeTrue();
        }

        // DeleteAsync
        [Fact]
        public async Task DeleteAsync_TestDelete_ReturnTrue()
        {
            // Arrange
            var testObject = new VehicleMake() { Id = 1, Name = "Test", Abrv = "T", VehicleModels = null };
            var testList = new List<VehicleMake>() { testObject };

            var UoW = new Mock<IUnitOfWork>(); //{ CallBase = true }
            UoW.Setup(x => x.VehicleMake.Delete(testObject)).ReturnsAsync(true); ;

            // Act
            var serviceVehicleMake = new Services.API.VehicleMakeService(UoW.Object);
            var result = await serviceVehicleMake.DeleteAsync(testObject);

            // Assert
            var okResult = result.Should().BeTrue();
        }

        // FindAsync
        [Fact]
        public void FindAsync_TestFind_ReturnVehicleMake()
        {
            // Arrange
            var testObject = new VehicleMake() { Id = 1, Name = "Test", Abrv = "T", VehicleModels = null };
            var testList = new List<VehicleMake>() { testObject };

            var mockedDbContext = new Mock<ApplicationContext>();
            var mockDbSet = testList.AsQueryable().BuildMockDbSet();

            var UoW = new Mock<IUnitOfWork>(); //{ CallBase = true }
            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());
            //UoW.Setup(x => x.VehicleMake.FindByCondition(x => x.Id == 1)).Returns(testList.AsQueryable());

            // Act
            var serviceVehicleMake = new Services.API.VehicleMakeService(UoW.Object);
            var result = serviceVehicleMake.FindAsync(1);

            // Assert
            var okResult = result.IsCompleted.Should().BeTrue();
        }

        [Fact]
        public void FindAsync_TestFind_ReturnVehicleMakeNull()
        {
            // Arrange
            var testObject = new VehicleMake() { Id = 1, Name = "Test", Abrv = "T", VehicleModels = null };
            var testList = new List<VehicleMake>() { testObject };

            var UoW = new Mock<IUnitOfWork>(); //{ CallBase = true }
            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());
            UoW.Setup(x => x.VehicleMake.FindByCondition(m => m.Id == testObject.Id)); 

            // Act
            var serviceVehicleMake = new Services.API.VehicleMakeService(UoW.Object); 
            var result = serviceVehicleMake.FindAsync(5); // testObject.Id != 5

            // Assert
            var okResult = result.IsCompleted.Should().BeTrue();
        }

        // GetAllAsync
        [Fact]
        public void GetAsync_TestGetAsync_ReturnAllVehicleMakes()
        {
            // Arrange
            var testObject = new VehicleMake() { Id = 1, Name = "Test", Abrv = "T", VehicleModels = null };
            var testList = new List<VehicleMake>() { testObject };
            var pagingDataTest = new PagingData() { Count = 10, Page = 0, SearchString = null, SortOrder = null, VehicleMakeId = null };
            
            var mockedDbContext = new Mock<ApplicationContext>();
            var mockDbSet = testList.AsQueryable().BuildMockDbSet();

            var UoW = new Mock<IUnitOfWork>(); //{ CallBase = true }
            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());
            UoW.Setup(x => x.VehicleMake.FindAll()).Returns(mockDbSet.Object);

            // Act
            var serviceVehicleMake = new Services.API.VehicleMakeService(UoW.Object);
            var result = serviceVehicleMake.GetAllAsync(pagingDataTest);

            // Assert
            //UoW.Verify();
            //Assert.True(result.IsCompleted);
            //Assert.True(result.IsCompletedSuccessfully);
            //Assert.False(result.IsFaulted);
            var okResult = result.Should().Equals(testList);
            result.IsCompletedSuccessfully.Should().BeTrue();
        }
        [Fact]
        public void GetAsync_TestGetAsyncIfPagingDataNull_ReturnAllVehicleMakes()
        {
            // Arrange
            var testObject = new VehicleMake() { Id = 1, Name = "Test", Abrv = "T", VehicleModels = null };
            var testList = new List<VehicleMake>() { testObject };
            var pagingDataTest = new PagingData() { Count = 10, Page = 0, SearchString = null, SortOrder = null, VehicleMakeId = null };

            var mockedDbContext = new Mock<ApplicationContext>();
            var mockDbSet = testList.AsQueryable().BuildMockDbSet();

            var UoW = new Mock<IUnitOfWork>(); //{ CallBase = true }
            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());
            UoW.Setup(x => x.VehicleMake.FindAll()).Returns(mockDbSet.Object);

            // Act
            var serviceVehicleMake = new Services.API.VehicleMakeService(UoW.Object);
            var result = serviceVehicleMake.GetAllAsync();

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
            var testObject = new VehicleMake() { Id = 1, Name = "Test", Abrv = "T", VehicleModels = null };
            var testList = new List<VehicleMake>() { testObject };
            var pagingDataTest = new PagingData() { Count = 10, Page = 0, SearchString = "test", SortOrder = null, VehicleMakeId = null };

            var mockedDbContext = new Mock<ApplicationContext>();
            var mockDbSet = testList.AsQueryable().BuildMockDbSet();

            var UoW = new Mock<IUnitOfWork>(); //{ CallBase = true }

            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());
            UoW.Setup(x => x.VehicleMake.FindAll()).Returns(mockDbSet.Object);

            // Act
            var serviceVehicleMake = new Services.API.VehicleMakeService(UoW.Object);
            var result = serviceVehicleMake.GetAllAsync(pagingDataTest);

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
            var testObject = new VehicleMake() { Id = 1, Name = "Test", Abrv = "T", VehicleModels = null };
            var testList = new List<VehicleMake>() { testObject };

            var UoW = new Mock<IUnitOfWork>(); //{ CallBase = true }
            UoW.Setup(x => x.VehicleMake.Update(testObject)).ReturnsAsync(true); 

            // Act
            var serviceVehicleMake = new Services.API.VehicleMakeService(UoW.Object);
            var result = await serviceVehicleMake.UpdateAsync(testObject);

            // Assert
            var okResult = result.Should().BeTrue();
        }

        //VehicleMakeExists
        [Fact]
        public void VehicleMakeExists_TestExists_ReturnVehicleMake()
        {
            // Arrange
            var testObject = new VehicleMake() { Id = 1, Name = "Test", Abrv = "T", VehicleModels = null };
            var testList = new List<VehicleMake>() { testObject };

            //var UoW = new Mock<IUnitOfWork>(); //{ CallBase = true }
            //UoW.Setup(x => x.VehicleMake.FindByCondition(m => m.Id == m.Id));
            var mockedDbContext = new Mock<ApplicationContext>();
            var mockDbSet = testList.AsQueryable().BuildMockDbSet();

            var UoW = new Mock<IUnitOfWork>(); //{ CallBase = true }

            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            UoW.As<IQueryable<VehicleMake>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());
            //UoW.Setup(x => x.VehicleMake.FindByCondition(m => m.Id == testObject.Id)).Returns(mockDbSet.Object);


            // Act
            var serviceVehicleMake = new Services.API.VehicleMakeService(UoW.Object);
            var result = serviceVehicleMake.VehicleMakeExists(testObject.Id); 

            // Assert
            UoW.Verify();
            Assert.True(result.IsCompleted);
        }
    }
}
