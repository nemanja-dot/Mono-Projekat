using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Service.Context;
using Project.Service.Model;
using Project.Service.Interfaces;
using AutoMapper;
using Mono_Project.Models;

namespace Mono_Project.Controllers
{
    public class VehicleModelController : Controller
    {
        private readonly IVehicleModelService _vehicleModelService;
        private readonly IVehicleMakeService _vehicleMakeService;
        private readonly IMapper _mapper;

        public VehicleModelController(IVehicleModelService vehicleModelService, IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            _vehicleModelService = vehicleModelService;
            _vehicleMakeService = vehicleMakeService;
            _mapper = mapper;
        }

        // GET: VehicleModel
        public async Task<IActionResult> Index(PagingData pagingData)
        {

            ViewData["CurrentSort"] = pagingData.SortOrder;
            ViewData["Count"] = pagingData.Count;
            ViewData["CurrentFilter"] = pagingData.SearchString;
            ViewData["NameSortParm"] = pagingData.SortOrder;

            pagingData.Page ??= 0;
            pagingData.Count ??= 10;

            var allVehicleModels = await _vehicleModelService.GetAllAsync(pagingData);
            var allVehicleModelsViewModels = _mapper.Map<PagingDataList<VehicleModelViewModel>>(allVehicleModels);

            return View(allVehicleModelsViewModels);
        }

        // GET: VehicleModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _vehicleModelService.FindAsync(id);
                
            if (vehicleModel == null)
            {
                return NotFound();
            }

            var vehicleMadeModel = _mapper.Map<VehicleModelViewModel>(vehicleModel);

            return View(vehicleMadeModel);
        }

        // GET: VehicleModel/Create
        public async Task<IActionResult> Create()
        {
            var model = new VehicleModelViewModel();

            var allVehicleMakes = await _vehicleMakeService.GetAllAsync();

            model.VehicleMakes = allVehicleMakes.Select(m => new SelectListItem(m.Name, m.Id.ToString())).ToList();

            return View(model);
        }

        // POST: VehicleModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VehicleMakeId,Name,Abrv")] VehicleModelViewModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                var vehicleMadeViewModel = _mapper.Map<VehicleModel>(vehicleModel);

                await _vehicleModelService.CreateAsync(vehicleMadeViewModel);
                return RedirectToAction(nameof(Index));
            }

            var allvehicleMadeViewModel = _mapper.Map<VehicleModelViewModel>(vehicleModel);

            return View(allvehicleMadeViewModel);

        }

        // GET: VehicleModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _vehicleModelService.FindAsync(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            var vehicleModelViewModel = _mapper.Map<VehicleModelViewModel>(vehicleModel);

            var allVehicleMakes = await _vehicleMakeService.GetAllAsync();
            vehicleModelViewModel.VehicleMakes = allVehicleMakes.Select(m => new SelectListItem(m.Name, m.Id.ToString())).ToList();

            return View(vehicleModelViewModel);

        }

        // POST: VehicleModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VehicleMakeId,Name,Abrv")] VehicleModelViewModel vehicleModel)
        {

            var vehicleModelViewModel = _mapper.Map<VehicleModel>(vehicleModel);

            if (id != vehicleModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _vehicleModelService.UpdateAsync(vehicleModelViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_vehicleModelService.VehicleModelExists(vehicleModelViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }


            var allVehicleMakes = await _vehicleMakeService.GetAllAsync();
            vehicleModel.VehicleMakes = allVehicleMakes.Select(m => new SelectListItem(m.Name, m.Id.ToString())).ToList();

            return View(vehicleModel);
        }

        // GET: VehicleModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _vehicleModelService.FindAsync(id);
               
            if (vehicleModel == null)
            {
                return NotFound();
            }

            var vehicleModelViewModel = _mapper.Map<VehicleModelViewModel>(vehicleModel);

            return View(vehicleModelViewModel);
        }

        // POST: VehicleModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleModel = await _vehicleModelService.FindAsync(id);

            var vehicleModelViewModel = _mapper.Map<VehicleModel>(vehicleModel);

            await _vehicleModelService.DeleteAsync(vehicleModelViewModel);
            return RedirectToAction(nameof(Index));
        }
    }
}
