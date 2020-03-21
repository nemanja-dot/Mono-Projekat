using System.Collections.Generic;
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
        public async Task<ActionResult<IEnumerable<VehicleMakeViewModel>>> GetVehicleMake(PagingData pagingData = null)
        {

            pagingData.Page ??= 0;
            pagingData.Count ??= 10;

            var allVehicleMakes = await _vehicleMakeService.GetAllAsync(pagingData);
            var vehicleMakeViewModel = _mapper.Map<IEnumerable<VehicleMakeViewModel>>(allVehicleMakes);

            return Ok(vehicleMakeViewModel);
        }

        // GET: api/VehicleMakes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleMakeViewModel>> GetVehicleMake(int id)
        {
            var vehicleMake = await _vehicleMakeService.FindAsync(id);

            if (vehicleMake == null)
            {
                return NotFound();
            }

            var vehicleMakeViewModel = _mapper.Map<VehicleMakeViewModel>(vehicleMake);

            return Ok(vehicleMakeViewModel);
        }

        // PUT: api/VehicleMakes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleMake(int id, VehicleMakeViewModel vehicleMake)
        {
            var vehicleMakeViewModel = _mapper.Map<VehicleMake>(vehicleMake);

            if (id != vehicleMake.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _vehicleMakeService.UpdateAsync(vehicleMakeViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    /*if (!_vehicleMakeService.VehicleMakeExists(vehicleMake.Id))
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
        public async Task<ActionResult<VehicleMake>> PostVehicleMake(VehicleMakeViewModel vehicleMake)
        {
            var vehicleMakeViewModel = _mapper.Map<VehicleMake>(vehicleMake);

            await _vehicleMakeService.CreateAsync(vehicleMakeViewModel);
           

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

            var vehicleMakeViewModel = _mapper.Map<VehicleMake>(vehicleMake);

            return Ok(await _vehicleMakeService.DeleteAsync(vehicleMakeViewModel));
        }

        
    }
}
