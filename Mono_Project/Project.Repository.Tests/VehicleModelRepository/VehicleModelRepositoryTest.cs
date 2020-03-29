using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Project.DAL.Context;
using Project.Model.Model;
using Project.Repository.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Project.Repository.Tests.VehicleModelRepository
{
    public class VehicleModelRepositoryTest
    {
        // FindAll
        [Fact]
        public void FindAll_FindAllVehicles_ReturnTestList()
        {
            // Arrange
            var testObject = new VehicleModel() { Id = 1, Name = "Test", Abrv = "T" };
            var testList = new List<VehicleModel>() { testObject };

            var dbSetMock = new Mock<DbSet<VehicleModel>>();
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());
            dbSetMock.Setup(x => x.AsQueryable()).Returns(testList.AsQueryable);

            var context = new Mock<ApplicationContext>();
            context.Setup(x => x.Set<VehicleModel>()).Returns(dbSetMock.Object);

            // Act
            var repository = new RepositoryBase<VehicleModel>(context.Object);
            var result = repository.FindAll();

            // Assert
            // Assert.Equal(testList, result.ToList());
            var okResult = result.Should().Equal(testList);
        }

        // FindByCondition
        [Fact]
        public void FindAll_FindVehicleModel_ReturnFindVehicleModel()
        {
            // Arrange

            var testObject = new VehicleModel() { Id = 1, Name = "Test", Abrv = "T" };
            var testList = new List<VehicleModel>() { testObject };

            var dbSetMock = new Mock<DbSet<VehicleModel>>();
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());


            var dbContextMock = new Mock<ApplicationContext>();
            dbContextMock.Setup(s => s.Set<VehicleModel>()).Returns(dbSetMock.Object);


            // Act
            var repository = new RepositoryBase<VehicleModel>(dbContextMock.Object);
            var result = repository.FindByCondition(x => x.Id == testObject.Id);


            //Assert
            //Assert.Equal(testList, vehicleMakes.ToList());
            var okResult = result.Should().Equal(testList);
        }
        [Fact]
        public void FindAll_FindVehicleModel_ReturnNoFoundVehicleModel()
        {
            // Arrange

            var testObject = new VehicleModel() { Id = 1, Name = "Test", Abrv = "T" };
            var testList = new List<VehicleModel>() { testObject };

            var dbSetMock = new Mock<DbSet<VehicleModel>>();
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());


            var dbContextMock = new Mock<ApplicationContext>();
            dbContextMock.Setup(s => s.Set<VehicleModel>()).Returns(dbSetMock.Object);


            // Act
            var repository = new RepositoryBase<VehicleModel>(dbContextMock.Object);
            var result = repository.FindByCondition(x => x.Id == 5); // !=  testObject.Id


            //Assert
            //Assert.Equal(testList, vehicleMakes.ToList());
            var okResult = result.Should().BeEmpty();
        }

        // Created
        [Fact]
        public void Created_CreatedVehicleModel_ReturnTrue()
        {
            // Arrange

            var testObject = new VehicleModel() { Id = 1, Name = "Test", Abrv = "T" };
            var testList = new List<VehicleModel>() { testObject };

            var dbSetMock = new Mock<DbSet<VehicleModel>>();
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());
            dbSetMock.Setup(x => x.Add(testObject));

            var dbContextMock = new Mock<ApplicationContext>();
            dbContextMock.Setup(s => s.Set<VehicleModel>()).Returns(dbSetMock.Object);

            // Act
            var repository = new RepositoryBase<VehicleModel>(dbContextMock.Object);
            var result = repository.Create(testObject);


            //Assert
            // Assert.True(result.IsCompletedSuccessfully);
            var okResult = result.Should().NotBeNull();
            result.IsCompletedSuccessfully.Should().BeTrue();
        }

        //Update
        [Fact]
        public void Update_UpdateVehicleModel_ReturnTrue()
        {
            // Arrange

            var testObject = new VehicleModel() { Id = 1, Name = "Test", Abrv = "T" };
            var testList = new List<VehicleModel>() { testObject };


            var dbSetMock = new Mock<DbSet<VehicleModel>>();
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());
            dbSetMock.Setup(x => x.Update(testObject));

            var dbContextMock = new Mock<ApplicationContext>();
            dbContextMock.Setup(s => s.Set<VehicleModel>()).Returns(dbSetMock.Object);


            // Act
            var repository = new RepositoryBase<VehicleModel>(dbContextMock.Object);
            var result = repository.Update(testObject);


            //Assert
            //Assert.True(result.IsCompletedSuccessfully);
            var okResult = result.Should().NotBeNull();
            result.IsCompletedSuccessfully.Should().BeTrue();
        }

        // Delete
        [Fact]
        public void Deleted_DeletedVehicleModel_ReturnTrue()
        {
            // Arrange

            var testObject = new VehicleModel() { Id = 1, Name = "Test", Abrv = "T" };
            var testList = new List<VehicleModel>() { testObject };

            
            var dbSetMock = new Mock<DbSet<VehicleModel>>();
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<VehicleModel>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());


            var dbContextMock = new Mock<ApplicationContext>();
            dbContextMock.Setup(s => s.Set<VehicleModel>()).Returns(dbSetMock.Object);

            // Act
            var repository = new RepositoryBase<VehicleModel>(dbContextMock.Object);
            var result = repository.Delete(testObject);


            //Assert
            //Assert.True(result.IsCompletedSuccessfully);
            var okResult = result.Should().NotBeNull();
            result.IsCompletedSuccessfully.Should().BeTrue();
        }
    }
}
