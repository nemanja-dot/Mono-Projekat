using Microsoft.EntityFrameworkCore;
using Moq;
using Project.DAL.Context;
using Project.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Project.Repository.API;
using Project.Repository.Common.Interfaces.API;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FluentAssertions;

namespace Project.Repository.Tests.VehicleMakeRepository
{
    public class VehicleMakeRepositoryTest
    {
        /*
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
        */

        // FindAll
        [Fact]
        public void FindAll_FindAllVehicles_ReturnTestList()
        {
            // Arrange
            var testObject = new VehicleMake() { Id = 1, Name = "Test", Abrv = "T", VehicleModels = null };
            var testList = new List<VehicleMake>() { testObject };

            var dbSetMock = new Mock<DbSet<VehicleMake>>();
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());
            dbSetMock.Setup(x => x.AsQueryable()).Returns(testList.AsQueryable);

            var context = new Mock<ApplicationContext>();
            context.Setup(x => x.Set<VehicleMake>()).Returns(dbSetMock.Object);

            // Act
            var repository = new RepositoryBase<VehicleMake>(context.Object);
            var result = repository.FindAll();

            // Assert
            // Assert.Equal(testList, result.ToList());
            var okResult = result.Should().Equal(testList);

        }

        // FindByCondition
        [Fact]
        public void FindAll_FindVehicleMake_ReturnFindVehicleMake()
        {
            // Arrange

            var testObject = new VehicleMake() { Id = 1, Name = "Test", Abrv = "T", VehicleModels = null };
            var testList = new List<VehicleMake>() { testObject };
           
            var dbSetMock = new Mock<DbSet<VehicleMake>>();
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());


            var dbContextMock = new Mock<ApplicationContext>();
            dbContextMock.Setup(s => s.Set<VehicleMake>()).Returns(dbSetMock.Object);


            // Act
            var repository = new RepositoryBase<VehicleMake>(dbContextMock.Object);
            var result = repository.FindByCondition(x => x.Id == testObject.Id);


            //Assert
            //Assert.Equal(testList, vehicleMakes.ToList());
            var okResult = result.Should().Equal(testList);
        }
        [Fact]
        public void FindAll_FindVehicleMake_ReturnNoFoundVehicleMake()
        {
            // Arrange

            var testObject = new VehicleMake() { Id = 1, Name = "Test", Abrv = "T", VehicleModels = null };
            var testList = new List<VehicleMake>() { testObject };

            var dbSetMock = new Mock<DbSet<VehicleMake>>();
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());


            var dbContextMock = new Mock<ApplicationContext>();
            dbContextMock.Setup(s => s.Set<VehicleMake>()).Returns(dbSetMock.Object);


            // Act
            var repository = new RepositoryBase<VehicleMake>(dbContextMock.Object);
            var result = repository.FindByCondition(x => x.Id == 5); // !=  testObject.Id


            //Assert
            //Assert.Equal(testList, vehicleMakes.ToList());
            var okResult = result.Should().BeEmpty();
        }

        // Created
        [Fact]
        public void Created_CreatedVehicleMake_ReturnTrue()
        {
            // Arrange

            var testObject = new VehicleMake() { Id = 1, Name = "Test", Abrv = "T", VehicleModels = null };
            var testList = new List<VehicleMake>() { testObject };

            // Act
            
            var dbSetMock = new Mock<DbSet<VehicleMake>>();
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());
            dbSetMock.Setup(x => x.Add(testObject));

            var dbContextMock = new Mock<ApplicationContext>();
            dbContextMock.Setup(s => s.Set<VehicleMake>()).Returns(dbSetMock.Object);

            // Act
            var repository = new RepositoryBase<VehicleMake>(dbContextMock.Object);
            var result = repository.Create(testObject);


            //Assert
            // Assert.True(result.IsCompletedSuccessfully);
            var okResult = result.Should().NotBeNull();
        }

        //Update
        [Fact]
        public void Update_UpdateVehicleMake_ReturnTrue()
        {
            // Arrange

            var testObject = new VehicleMake() { Id = 1, Name = "Test", Abrv = "T", VehicleModels = null };
            var testList = new List<VehicleMake>() { testObject };
            
            
            var dbSetMock = new Mock<DbSet<VehicleMake>>();
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());
            dbSetMock.Setup(x => x.Update(testObject));

            var dbContextMock = new Mock<ApplicationContext>();
            dbContextMock.Setup(s => s.Set<VehicleMake>()).Returns(dbSetMock.Object);
            

            // Act
            var repository = new RepositoryBase<VehicleMake>(dbContextMock.Object);
            var result = repository.Update(testObject);


            //Assert
            //Assert.True(result.IsCompletedSuccessfully);
            var okResult = result.Should().NotBeNull();
        }



        // Delete
        [Fact]
        public void Deleted_DeletedVehicleMake_ReturnTrue()
        {
            // Arrange

            var testObject = new VehicleMake() { Id = 1, Name = "Test", Abrv = "T", VehicleModels = null };
            var testList = new List<VehicleMake>() { testObject };

            // Act
            
            var dbSetMock = new Mock<DbSet<VehicleMake>>();
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());


            var dbContextMock = new Mock<ApplicationContext>();
            dbContextMock.Setup(s => s.Set<VehicleMake>()).Returns(dbSetMock.Object);

            // Act
            var repository = new RepositoryBase<VehicleMake>(dbContextMock.Object);
            var result = repository.Delete(testObject);


            //Assert
            //Assert.True(result.IsCompletedSuccessfully);
            var okResult = result.Should().NotBeNull();
        }

        
    }
}
