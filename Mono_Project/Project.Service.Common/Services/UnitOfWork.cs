using Project.DAL.Context;
using Project.Repository.Common.Interfaces;
using Project.Repository.Common.Services;
using Project.Service.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Common.Services
{
   public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext _applicationContext;
        private IVehicleMakeRepository _makeRepository;
        private IVehicleModelRepository _modelRepository;

        public IVehicleMakeRepository VehicleMake {
            get {
                if (_makeRepository == null)
                {
                    _makeRepository = new VehicleMakeRepository(_applicationContext);
                }

                return _makeRepository;
                    }
        }

        public IVehicleModelRepository VehicleModel
        {
            get
            {
                if (_modelRepository == null)
                {
                    _modelRepository = new VehicleModelRepository(_applicationContext);
                }

                return _modelRepository;
            }
        }

        public UnitOfWork(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Save()
        {
            _applicationContext.SaveChanges();
        }

    }
}
