using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Model.Model;
using Project.Service.Common.Interfaces;
using Project.Service.Interfaces;

namespace Mono_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleModelsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/VehicleModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleModel>>> GetVehicleModel()
        {
            var vehicleModelAll = await _unitOfWork.VehicleModel.FindAll().ToListAsync();

            return Ok(vehicleModelAll);
        }

        // GET: api/VehicleModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleModel>> GetVehicleModel(int id)
        {
            var vehicleModel = await _unitOfWork.VehicleModel.FindByCondition(m => m.Id == id).ToListAsync();

            if (vehicleModel == null || vehicleModel.Count == 0)
            {
                return NotFound();
            }

            return Ok(vehicleModel);
        }

        // PUT: api/VehicleModels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleModel(int id, VehicleModel vehicleModel)
        {
            if (id != vehicleModel.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.VehicleModel.Update(vehicleModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    /*if (!_vehicleModelService.VehicleModelExists(vehicleModel.Id))
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
        public async Task<ActionResult<VehicleModel>> Create(VehicleModel vehicleModel)
        {
            await _unitOfWork.VehicleModel.Create(vehicleModel);

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
            var vehicleModel = await _unitOfWork.VehicleModel.FindByCondition(m => m.Id == id).ToListAsync();

            if (vehicleModel == null)
            {
                return NotFound();
            }
            await _unitOfWork.VehicleModel.Delete(vehicleModel[0]);

            return Ok();
        }

       
    }
}
