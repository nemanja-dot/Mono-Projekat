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
        [Route("GetVehicleModel")]
        public async Task<ActionResult> GetVehicleModel([FromQuery] PagingData pagingData)
        {
            pagingData.Page ??= 0;
            pagingData.Count ??= 10;

            var vehicleModelAll = await _vehicleModelServiceAPI.GetAllAsync(pagingData);

            var vehicleMoldelsAllView = _mapper.Map<PagingDataListViewModel<VehicleModelViewModel>>(vehicleModelAll);
            return Ok(vehicleMoldelsAllView);
        }

        // GET: api/VehicleModels/5
        [HttpGet]
        [Route("GetVehicleModelId/{id}")]
        public async Task<ActionResult> GetVehicleModel(int id)
        {
            var vehicleModel = await _vehicleModelServiceAPI.FindAsync(id);

            if (vehicleModel == null)
            {
                return NotFound(id);
            }

            var vehicleModelViewModel = _mapper.Map<VehicleModelViewModel>(vehicleModel);

            return Ok(vehicleModelViewModel);
        }

        // PUT: api/VehicleModels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut]
        [Route("UpdateVehicleModelId")]
        public async Task<IActionResult> PutVehicleModel(VehicleModelViewModel vehicleModelViewModel)
        {
            var vehicleModel = _mapper.Map<VehicleModel>(vehicleModelViewModel);

            /*
            if (id != vehicleModel.Id)
            {
                return BadRequest();
            }
            */

            if (ModelState.IsValid)
            {
                try
                {
                    await _vehicleModelServiceAPI.UpdateAsync(vehicleModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _vehicleModelServiceAPI.VehicleModelExists(vehicleModel.Id))
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

        // POST: api/VehicleModels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Route("CreateVehicleModel")]
        public async Task<ActionResult> Create(VehicleModelViewModel vehicleModelViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicleModel = _mapper.Map<VehicleModel>(vehicleModelViewModel);

            await _vehicleModelServiceAPI.CreateAsync(vehicleModel);

            return CreatedAtAction("GetVehicleModel", new { id = vehicleModel.Id }, vehicleModel);
        }

        // DELETE: api/VehicleModels/5
        [HttpDelete]
        [Route("DeleteVehicleModelId/{id}")]
        public async Task<ActionResult> DeleteVehicleModel(int? id)
        {
            
            if (id == null)
            {
                return NotFound(id);
            }
            var vehicleModelViewModel = await _vehicleModelServiceAPI.FindAsync(id);

            if (vehicleModelViewModel == null)
            {
                return NotFound(id);
            }

            var vehicleModel = _mapper.Map<VehicleModel>(vehicleModelViewModel);

            var deleteVehicleMake = await _vehicleModelServiceAPI.DeleteAsync(vehicleModel);

            return Ok(deleteVehicleMake);
        }

       
    }
}
