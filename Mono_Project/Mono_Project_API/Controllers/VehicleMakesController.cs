using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Model.Model;
using Project.Service.Common.Interfaces;
using Project.Service.Interfaces;

namespace Mono_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMakesController : ControllerBase
    {
        // private readonly IVehicleMakeService _vehicleMakeService;

        // UnitOfWork
        private readonly IUnitOfWork _unitOfWork;

        public VehicleMakesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/VehicleMakes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleMake>>> GetVehicleMake()
        {
            return await _unitOfWork.VehicleMake.FindAll().ToListAsync();
        }

        // GET: api/VehicleMakes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleMake>> GetVehicleMake(int id)
        {
            var vehicleMake = await _unitOfWork.VehicleMake.FindByCondition(m => m.Id == id).ToListAsync();

            if (vehicleMake == null || vehicleMake.Count == 0)
            {
                return NotFound();
            }

            return Ok(vehicleMake);
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
                    await _unitOfWork.VehicleMake.Update(vehicleMake);
                }
                catch (DbUpdateConcurrencyException)
                {
                    /*if (!_unitOfWork.VehicleMake.VehicleMakeExists(vehicleMake.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }*/
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
            await _unitOfWork.VehicleMake.Create(vehicleMake);
           

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

            var vehicleMake = await _unitOfWork.VehicleMake.FindByCondition((m) => m.Id == id).ToListAsync();
            if (vehicleMake == null || vehicleMake.Count == 0)
            {
                return NotFound();
            }

            return Ok(await _unitOfWork.VehicleMake.Delete(vehicleMake[0]));
        }

        
    }
}
