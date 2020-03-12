using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Model.Model;
using Project.Service.Interfaces;

namespace Mono_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMakesController : ControllerBase
    {
        private readonly IVehicleMakeService _vehicleMakeService;

        public VehicleMakesController(IVehicleMakeService vehicleMakeService)
        {
            _vehicleMakeService = vehicleMakeService;
        }

        // GET: api/VehicleMakes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleMake>>> GetVehicleMake()
        {
            return await _vehicleMakeService.GetAllAsync();
        }

        // GET: api/VehicleMakes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleMake>> GetVehicleMake(int id)
        {
            var vehicleMake = await _vehicleMakeService.FindAsync(id);

            if (vehicleMake == null)
            {
                return NotFound();
            }

            return vehicleMake;
        }

        // PUT: api/VehicleMakes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleMake(int id, VehicleMake vehicleMake)
        {
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
                    if (!_vehicleMakeService.VehicleMakeExists(vehicleMake.Id))
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
        public async Task<ActionResult<VehicleMake>> PostVehicleMake(VehicleMake vehicleMake)
        {
            await _vehicleMakeService.CreateAsync(vehicleMake);
           

            return CreatedAtAction("GetVehicleMake", new { id = vehicleMake.Id }, vehicleMake);
        }

        // DELETE: api/VehicleMakes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleMake>> DeleteVehicleMake(int? id)
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

            await _vehicleMakeService.DeleteAsync(vehicleMake);

            return vehicleMake;
        }

        
    }
}
