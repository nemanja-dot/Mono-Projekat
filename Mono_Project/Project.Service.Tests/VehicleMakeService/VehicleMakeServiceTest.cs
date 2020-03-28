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

namespace Project.Service.Tests.VehicleMakeService
{
    public class VehicleMakeServiceTest
    {
        // CreatedAsync
        [Fact]
        public void CreatedAsync_TestCreating_ReturnTrue()
        {
            // Arrange
            var testObject = new VehicleMake() { Id = 1, Name = "Test", Abrv = "T", VehicleModels = null };
            var testList = new List<VehicleMake>() { testObject };

            var UoW = new Mock<IUnitOfWork>(); //{ CallBase = true }
            UoW.Setup(x => x.VehicleMake.Create(testObject));

            // Act
            var serviceVehicleMake = new Services.API.VehicleMakeService(UoW.Object);
            var result = serviceVehicleMake.CreateAsync(testObject);

            // Assert
            UoW.Verify();
            Assert.True(result.IsCompletedSuccessfully);
        }

        // DeleteAsync
        [Fact]
        public void DeleteAsync_TestDelete_ReturnTrue()
        {
            // Arrange
            var testObject = new VehicleMake() { Id = 1, Name = "Test", Abrv = "T", VehicleModels = null };
            var testList = new List<VehicleMake>() { testObject };

            var UoW = new Mock<IUnitOfWork>(); //{ CallBase = true }
            UoW.Setup(x => x.VehicleMake.Delete(testObject));

            // Act
            var serviceVehicleMake = new Services.API.VehicleMakeService(UoW.Object);
            var result = serviceVehicleMake.DeleteAsync(testObject);

            // Assert
            UoW.Verify();
            Assert.True(result.IsCompletedSuccessfully);
        }

        // FindAsync
        [Fact]
        public void FindAsync_TestFind_ReturnTrue()
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
            UoW.Setup(x => x.VehicleMake.FindByCondition(x => x.Id == 1)).Returns(testList.AsQueryable());

            // Act
            var serviceVehicleMake = new Services.API.VehicleMakeService(UoW.Object);
            var result = serviceVehicleMake.FindAsync(1);

            // Assert
            UoW.Verify();
            Assert.True(result.IsCompleted);
        }

        [Fact]
        public void FindAsync_TestFind_ReturnFalse()
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
            UoW.Verify();
            Assert.True(result.IsCompleted);
            Assert.True(result.IsFaulted);
        }

        // GetAllAsync
        [Fact]
        public void GetAsync_TestGet_ReturnAll()
        {
            // Arrange
            var testObject = new VehicleMake() { Id = 1, Name = "Test", Abrv = "T", VehicleModels = null };
            var testList = new List<VehicleMake>() { testObject };
            var pagingDataTest = new PagingData() { Count = 10, Page = 0, SearchString = null, SortOrder = null, VehicleMakeId = null };
            
            var mockedDbContext = new Mock<ApplicationContext>();
            var mockDbSet = testList.AsQueryable().BuildMockDbSet();

           // mockedDbContext.Setup(db => db.VehicleMake).Returns(mockDbSet.Object);



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
            UoW.Verify();
            Assert.True(result.IsCompleted);
            Assert.True(result.IsCompletedSuccessfully);
            Assert.False(result.IsFaulted);
        }
        [Fact]
        public void GetAsync_TestGet_ReturnAllPagingDataNull()
        {
            // Arrange
            var testObject = new VehicleMake() { Id = 1, Name = "Test", Abrv = "T", VehicleModels = null };
            var testList = new List<VehicleMake>() { testObject };
            var pagingDataTest = new PagingData() { Count = 10, Page = 0, SearchString = null, SortOrder = null, VehicleMakeId = null };

            var mockedDbContext = new Mock<ApplicationContext>();
            var mockDbSet = testList.AsQueryable().BuildMockDbSet();

            // mockedDbContext.Setup(db => db.VehicleMake).Returns(mockDbSet.Object);



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
            UoW.Verify();
            Assert.True(result.IsCompleted);
            Assert.True(result.IsCompletedSuccessfully);
            Assert.False(result.IsFaulted);
        }

        [Fact]
        public void GetAsync_TestGet_ReturnAllSearchString()
        {
            // Arrange
            var testObject = new VehicleMake() { Id = 1, Name = "Test", Abrv = "T", VehicleModels = null };
            var testList = new List<VehicleMake>() { testObject };
            var pagingDataTest = new PagingData() { Count = 10, Page = 0, SearchString = "test", SortOrder = null, VehicleMakeId = null };

            var mockedDbContext = new Mock<ApplicationContext>();
            var mockDbSet = testList.AsQueryable().BuildMockDbSet();

            // mockedDbContext.Setup(db => db.VehicleMake).Returns(mockDbSet.Object);



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
            UoW.Verify();
            Assert.True(result.IsCompleted);
            Assert.True(result.IsCompletedSuccessfully);
            Assert.False(result.IsFaulted);
        }

        // UpdateAsync
        [Fact]
        public void UpdetAsync_TestUpdate_ReturnTrue()
        {
            // Arrange
            var testObject = new VehicleMake() { Id = 1, Name = "Test", Abrv = "T", VehicleModels = null };
            var testList = new List<VehicleMake>() { testObject };

            var UoW = new Mock<IUnitOfWork>(); //{ CallBase = true }
            UoW.Setup(x => x.VehicleMake.Update(testObject));

            // Act
            var serviceVehicleMake = new Services.API.VehicleMakeService(UoW.Object);
            var result = serviceVehicleMake.UpdateAsync(testObject); 

            // Assert
            UoW.Verify();
            Assert.True(result.IsCompleted);
            Assert.True(result.IsCompletedSuccessfully);
            Assert.False(result.IsFaulted);
        }

        //VehicleMakeExists
        [Fact]
        public void VehicleMakeExists_TestFind_ReturnTrue()
        {
            // Arrange
            var testObject = new VehicleMake() { Id = 1, Name = "Test", Abrv = "T", VehicleModels = null };
            var testList = new List<VehicleMake>() { testObject };

            var UoW = new Mock<IUnitOfWork>(); //{ CallBase = true }
            UoW.Setup(x => x.VehicleMake.FindByCondition(m => m.Id == m.Id));

            // Act
            var serviceVehicleMake = new Services.API.VehicleMakeService(UoW.Object);
            var result = serviceVehicleMake.VehicleMakeExists(12); // testObject.Id != 5

            // Assert
            UoW.Verify();
            Assert.True(result.IsCompleted);
        }
    }
}
