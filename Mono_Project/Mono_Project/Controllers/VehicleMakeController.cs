using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mono_Project.Models;
using Project.Service.Context;
using Project.Service.Interfaces;
using Project.Service.Model;

namespace Mono_Project.Controllers
{
    public class VehicleMakeController : Controller
    {
        private readonly IVehicleMakeService _vehicleMakeService;
        private readonly IMapper _mapper;

        public VehicleMakeController(IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            _vehicleMakeService = vehicleMakeService;
            _mapper = mapper;
        }

        // GET: VehicleMake
        public async Task<IActionResult> Index(PagingData pagingData)
        {

            ViewData["CurrentSort"] = pagingData.SortOrder;
            ViewData["Count"] = pagingData.Count;
            ViewData["CurrentFilter"] = pagingData.SearchString;
            ViewData["NameSortParm"] = pagingData.SortOrder;

            pagingData.Page ??= 0;
            pagingData.Count ??= 10;

            var allVehicleMakes = await _vehicleMakeService.GetAllAsync(pagingData);


            return View(allVehicleMakes);
          
        }

        // GET: VehicleMake/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleMake = await _vehicleMakeService.FindAsync(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            var vehicleMakeViewModel = _mapper.Map<VehicleMakeViewModel>(vehicleMake);

            return View(vehicleMakeViewModel);
        }

        // GET: VehicleMake/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleMake/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Abrv")] VehicleMakeViewModel vehicleMake)
        {
            if (ModelState.IsValid)
            {
                var vehicleMakeViewModel = _mapper.Map<VehicleMake>(vehicleMake);

                await _vehicleMakeService.CreateAsync(vehicleMakeViewModel);
                return RedirectToAction(nameof(Index));
            }

            var allvehicleMakeViewModel = _mapper.Map<VehicleMakeViewModel>(vehicleMake);

            return View(allvehicleMakeViewModel);
        }

        // GET: VehicleMake/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleMake = await _vehicleMakeService.FindAsync(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            var vehicleMakeViewModel = _mapper.Map<VehicleMakeViewModel>(vehicleMake);

            return View(vehicleMakeViewModel);

        }

        // POST: VehicleMake/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Abrv")] VehicleMakeViewModel vehicleMake)
        {

            var vehicleMakeViewModel = _mapper.Map<VehicleMake>(vehicleMake);

            if (id != vehicleMake.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _vehicleMakeService.UpdateAsync(vehicleMakeViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_vehicleMakeService.VehicleMakeExists(vehicleMakeViewModel.Id))
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
            return View(vehicleMakeViewModel);
        }

        // GET: VehicleMake/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleMake = await _vehicleMakeService.FindAsync(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            var vehicleMakeViewModel = _mapper.Map<VehicleMakeViewModel>(vehicleMake);

            return View(vehicleMakeViewModel);
        }

        // POST: VehicleMake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var vehicleMake = await _vehicleMakeService.FindAsync(id);

            var vehicleMakeViewModel = _mapper.Map<VehicleMake>(vehicleMake);

            await _vehicleMakeService.DeleteAsync(vehicleMakeViewModel);
            return RedirectToAction(nameof(Index));
        }
    }
}
