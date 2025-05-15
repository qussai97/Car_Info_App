using Microsoft.AspNetCore.Mvc;
using CarInfoApp.Application.Interfaces;
namespace CarInfoApp.API.Controllers
{
  

        [ApiController]
        [Route("api/[controller]")]
        public class NhtsaController : ControllerBase
        {
            private readonly INhtsaService _nhtsaService;

            public NhtsaController(INhtsaService nhtsaService)
            {
                _nhtsaService = nhtsaService;
            }

            [HttpGet("makes")]
            public async Task<IActionResult> GetMakes()
            {
                var makes = await _nhtsaService.GetAllMakesAsync();
                return Ok(makes);
            }

            [HttpGet("vehicle-types/{makeId}")]
            public async Task<IActionResult> GetVehicleTypes(int makeId)
            {
                var types = await _nhtsaService.GetVehicleTypesForMakeIdAsync(makeId);
                return Ok(types);
            }

            [HttpGet("models")]
            public async Task<IActionResult> GetModels(int makeId, int year)
            {
                var models = await _nhtsaService.GetModelsForMakeIdAndYearAsync(makeId, year);
                return Ok(models);
            }
        }
    
}
