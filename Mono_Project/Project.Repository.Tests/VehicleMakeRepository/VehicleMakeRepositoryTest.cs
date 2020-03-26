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

namespace Project.Repository.Tests.VehicleMakeRepository
{
    public class VehicleMakeRepositoryTest
    {
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

        // FindAll
        [Fact]
        public void GetAll_TestClassObjectPassed_ProperMethodCalled()
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
            Assert.Equal(testList, result.ToList());
        }

        // FindByCondition
        [Fact]
        public void FindAll_ReturnsFindVehicleMake_FindVehicleMake()
        {
            // Arrange

            var testObject = new List<VehicleMake>
            {
                new VehicleMake()
                {
                    Id = 2,
                    Name = "Test",
                    Abrv = "T",
                    VehicleModels = null,
                    }
            };

            int testId = 2;
            var testObject1 = new VehicleMake() { Id = 1 };
            var testList = new List<VehicleMake>() {testObject1};

            // Act
            var dbContextMock = new Mock<ApplicationContext>();
            var dbSetMock = new Mock<DbSet<VehicleMake>>();

            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<VehicleMake>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());

            dbContextMock.Setup(s => s.Set<VehicleMake>()).Returns(dbSetMock.Object);
            //dbSetMock.Setup(x => x.AsQueryable()).Returns(testObject.AsQueryable);
            // dbSetMock.Setup(x => x.Where(testObject => testObject.Id == testId)).Returns(testObject.AsQueryable());


            // Act
            var vehicleMakeRepository = new RepositoryBase<VehicleMake>(dbContextMock.Object);
            var vehicleMakes = vehicleMakeRepository.FindByCondition(x => x.Id == 1);


            //Assert
            Assert.Equal(testList, vehicleMakes.ToList());
            // dbContextMock.Verify(x => x.Set<VehicleMake>());
            // dbSetMock.Verify(x => x.AsQueryable());
        }

        // Created
        [Fact]
        public void Created_Returns_CreatedVehicleMake()
        {
            // Arrange

            var testObject = new List<VehicleMake>
            {
                new VehicleMake()
                {
                    Id = 2,
                    Name = "Test",
                    Abrv = "T",
                    VehicleModels = null,
                    }
            };

            int testId = 2;
            var testObject1 = new VehicleMake();

            // Act
            var dbContextMock = new Mock<ApplicationContext>();
            var dbSetMock = new Mock<DbSet<VehicleMake>>();

            dbContextMock.Setup(s => s.Set<VehicleMake>()).Returns(dbSetMock.Object);
            // dbSetMock.Setup(x => x.AsQueryable()).Returns(testObject.AsQueryable);
            // dbSetMock.Setup(x => x.Where(testObject => testObject.Id == testId)).Returns(testObject.AsQueryable());
            dbSetMock.Setup(x => x.Add(testObject1));

            // Act
            var vehicleMakeRepository = new RepositoryBase<VehicleMake>(dbContextMock.Object);
            var vehicleMakes = vehicleMakeRepository.Create(testObject1);


            //Assert
            dbContextMock.Verify(x => x.Set<VehicleMake>());
            dbSetMock.Verify(x => x.Add(It.Is<VehicleMake>(y => y == testObject1)));
        }

        //Update
        [Fact]
        public void Update_Returns_UpdateVehicleMake()
        {
            // Arrange

            var testObject = new List<VehicleMake>
            {
                new VehicleMake()
                {
                    Id = 2,
                    Name = "Test",
                    Abrv = "T",
                    VehicleModels = null,
                    }
            };

            int testId = 2;
            var testObject1 = new VehicleMake();

            // Act
            var dbContextMock = new Mock<ApplicationContext>();
            var dbSetMock = new Mock<DbSet<VehicleMake>>();

            dbContextMock.Setup(s => s.Set<VehicleMake>()).Returns(dbSetMock.Object);
            // dbSetMock.Setup(x => x.AsQueryable()).Returns(testObject.AsQueryable);
            // dbSetMock.Setup(x => x.Where(testObject => testObject.Id == testId)).Returns(testObject.AsQueryable());
            dbSetMock.Setup(x => x.Update(testObject1));

            // Act
            var vehicleMakeRepository = new RepositoryBase<VehicleMake>(dbContextMock.Object);
            var vehicleMakes = vehicleMakeRepository.Update(testObject1);


            //Assert
            dbContextMock.Verify(x => x.Set<VehicleMake>());
            dbSetMock.Verify(x => x.Update(It.Is<VehicleMake>(y => y == testObject1)));
        }



        // Delete
        [Fact]
        public void Deleted_Returns_DeletedVehicleMake()
        {
            // Arrange

            var testObject = new List<VehicleMake>
            {
                new VehicleMake()
                {
                    Id = 2,
                    Name = "Test",
                    Abrv = "T",
                    VehicleModels = null,
                    }
            };

            int testId = 2;
            var testObject1 = new VehicleMake();

            // Act
            var dbContextMock = new Mock<ApplicationContext>();
            var dbSetMock = new Mock<DbSet<VehicleMake>>();

            dbContextMock.Setup(s => s.Set<VehicleMake>()).Returns(dbSetMock.Object);
            // dbSetMock.Setup(x => x.AsQueryable()).Returns(testObject.AsQueryable);
            // dbSetMock.Setup(x => x.Where(testObject => testObject.Id == testId)).Returns(testObject.AsQueryable());
            dbSetMock.Setup(x => x.Remove(testObject1));

            // Act
            var vehicleMakeRepository = new RepositoryBase<VehicleMake>(dbContextMock.Object);
            var vehicleMakes = vehicleMakeRepository.Delete(testObject1);


            //Assert
            dbContextMock.Verify(x => x.Set<VehicleMake>());
            dbSetMock.Verify(x => x.Remove(It.Is<VehicleMake>(y => y == testObject1)));
        }

        /*
        [Fact]
        public void FindAll_Returns_Product()
        {
            //Setup DbContext and DbSet mock
            var dbContextMock = new Mock<ApplicationContext>();
            var dbSetMock = new Mock<DbSet<VehicleMake>>();
            dbSetMock.Setup(s => s.AsQueryable());
            dbContextMock.Setup(s => s.Set<VehicleMake>()).Returns(dbSetMock.Object);

            //Execute method of SUT 
            var vehicleMakeRepository = new API.VehicleMakeRepository(dbContextMock.Object);
            var product = vehicleMakeRepository.FindAll();

            //Assert
            Assert.NotNull(product);
            Assert.IsAssignableFrom<VehicleMake>(product);
        } 
        

        [Fact]
        public void Add_WhenHaveNoEmail()
        {
            IVehicleMakeRepository sut = GetInMemoryPersonRepository();
            VehicleMake vehicleMake = new VehicleMake()
            {
               Id = 2,
               Name = "TestRepo",
               Abrv = "TRepo",
               VehicleModels = null
            };

            VehicleMake savedPerson = sut.Create.(entity);


            Assert.Equal(2, savedPerson.Id);
            Assert.Equal("TestRepo", savedPerson.Name);
            Assert.Equal("TRepo", savedPerson.Abrv);
            Assert.Null(savedPerson.VehicleModels);
        }

        private IVehicleMakeRepository GetInMemoryPersonRepository()
        {
            throw new NotImplementedException();
        }*/
    }
}
