using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mono_Project_API.Models;
using Project.Common;
using Project.Model.Model;
using Project.Service.Common.Interfaces.API;

namespace Mono_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMakesController : ControllerBase
    {
        // VehicleMakeServiceAPI
        private readonly IVehicleMakeServiceAPI _vehicleMakeService;

        // AutoMapper
        private readonly IMapper _mapper;

        public VehicleMakesController(IVehicleMakeServiceAPI vehicleMakeService, IMapper mapper)
        {
            _vehicleMakeService = vehicleMakeService;
            _mapper = mapper;
        }

        // GET: api/VehicleMakes
        [HttpGet]
        public async Task<ActionResult> GetVehicleMake()
        {

            //pagingData.Page ??= 0;
            //pagingData.Count ??= 10;

            var allVehicleMakes = await _vehicleMakeService.GetAllAsync();
            var vehicleMakeViewModel = _mapper.Map<List<VehicleMakeViewModel>>(allVehicleMakes);

            // vehicleMakeViewModel.Items.ForEach(m => 
               // m.ModelCount = allVehicleMakes.First(d => d.Id == m.Id).VehicleModels.Count);

            return Ok(vehicleMakeViewModel);
        }

        // GET: api/VehicleMakes/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetVehicleMake(int id)
        {
            var vehicleMake = await _vehicleMakeService.FindAsync(id);

            if (vehicleMake == null)
            {
                return NotFound(id);
            }

          var vehicleMakeViewModel = _mapper.Map<VehicleMakeViewModel>(vehicleMake);

            return Ok(vehicleMakeViewModel);
        }
        

        // PUT: api/VehicleMakes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleMake(int id, VehicleMakeViewModel vehicleMakeViewModel)
        {
           var vehicleMake = _mapper.Map<VehicleMake>(vehicleMakeViewModel);

            if (id != vehicleMake.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _vehicleMakeService.UpdateAsync(vehicleMake);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _vehicleMakeService.VehicleMakeExists(vehicleMake.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    } 
                } 
            }

            return NoContent();
        }

        // POST: api/VehicleMakes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult> PostVehicleMake(VehicleMakeViewModel vehicleMakeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicleMake = _mapper.Map<VehicleMake>(vehicleMakeViewModel);

            await _vehicleMakeService.CreateAsync(vehicleMake);
           

            return CreatedAtAction("GetVehicleMake", new { id = vehicleMakeViewModel.Id }, vehicleMakeViewModel);
        }
        
        // DELETE: api/VehicleMakes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVehicleMake(int? id)
        {
            if (id == null)
            {
                return NotFound(id);
            }

            var vehicleMakeViewModel = await _vehicleMakeService.FindAsync(id);
            
            if (vehicleMakeViewModel == null)
            {
                return NotFound(id);
            }

         var vehicleMake = _mapper.Map<VehicleMake>(vehicleMakeViewModel);

         var deleteVehicleMake = await _vehicleMakeService.DeleteAsync(vehicleMake);

         return Ok(deleteVehicleMake);
        }
        

    }
}
