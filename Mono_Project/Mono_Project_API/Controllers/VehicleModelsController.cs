using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mono_Project_API.Models;
using Project.Model.Model;
using Project.Service.Common.Interfaces.API;

namespace Mono_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelsController : ControllerBase
    {
        // VehicleModelServiceAPI
        private readonly IVehicleModelServiceAPI _vehicleModelServiceAPI;

        // AutoMapper
        private readonly IMapper _mapper;

        public VehicleModelsController(IVehicleModelServiceAPI vehicleModelServiceAPI, IMapper mapper)
        {
            _vehicleModelServiceAPI = vehicleModelServiceAPI;
            _mapper = mapper;
        }

        // GET: api/VehicleModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleModelViewModel>>> GetVehicleModel()
        {
            var vehicleModelAll = await _vehicleModelServiceAPI.GetAllAsync();

            var vehicleMoldelsAllView = _mapper.Map<List<VehicleModelViewModel>>(vehicleModelAll);
            return Ok(vehicleMoldelsAllView);
        }

        // GET: api/VehicleModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleModelViewModel>> GetVehicleModel(int id)
        {
            var vehicleModel = await _vehicleModelServiceAPI.FindAsync(id);

            if (vehicleModel == null)
            {
                return NotFound();
            }

            var vehicleModelViewModel = _mapper.Map<VehicleModelViewModel>(vehicleModel);

            return Ok(vehicleModelViewModel);
        }

        // PUT: api/VehicleModels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleModel(int id, VehicleModelViewModel vehicleModel)
        {
            var vehicleModelViewModel = _mapper.Map<VehicleModel>(vehicleModel);

            if (id != vehicleModel.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _vehicleModelServiceAPI.UpdateAsync(vehicleModelViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    /*if (!_vehicleModelServiceAPI.VehicleModelExists(vehicleModel.Id))
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

        // POST: api/VehicleModels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<VehicleModel>> Create(VehicleModelViewModel vehicleModel)
        {
            var vehicleModelViewModel = _mapper.Map<VehicleModel>(vehicleModel);

            await _vehicleModelServiceAPI.CreateAsync(vehicleModelViewModel);

            return CreatedAtAction("GetVehicleModel", new { id = vehicleModel.Id }, vehicleModel);
        }

        // DELETE: api/VehicleModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleModel>> DeleteVehicleModel(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }
            var vehicleModel = await _vehicleModelServiceAPI.FindAsync(id);

            if (vehicleModel == null)
            {
                return NotFound();
            }

            var vehicleModelViewModel = _mapper.Map<VehicleModel>(vehicleModel);

            await _vehicleModelServiceAPI.DeleteAsync(vehicleModelViewModel);

            return Ok();
        }

       
    }
}
