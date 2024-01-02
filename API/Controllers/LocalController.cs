using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.DTO;
using System.Threading.Tasks;

namespace VotreNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalController : ControllerBase
    {
        private readonly ILocalService _localService;

        public LocalController(ILocalService localService)
        {
            _localService = localService;
        }

        [HttpGet]
        public IActionResult GetLocals()
        {
            var locals = _localService.GetLocals();
            return Ok(locals);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetLocal(string code)
        {
            var local = await _localService.GetLocal(code);
            if (local == null)
            {
                return NotFound();
            }
            return Ok(local);
        }

        [HttpPost]
        public async Task<IActionResult> AddLocal([FromBody] LocalDto localDto)
        {
            var result = await _localService.AddLocal(localDto);
            if (result)
            {
                return Ok("Local added successfully");
            }
            return BadRequest("Failed to add local");
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateLocal(string code, [FromBody] LocalDto localDto)
        {
            // Check if the provided code matches the code in the DTO
            if (code != localDto.IdLocal)
            {
                return BadRequest("Code mismatch");
            }

            var result = await _localService.UpdLocal(localDto);
            if (result)
            {
                return Ok("Local updated successfully");
            }
            return BadRequest("Failed to update local");
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteLocal(string code)
        {
            var result = await _localService.DelLocal(code);
            if (result)
            {
                return Ok("Local deleted successfully");
            }
            return BadRequest("Failed to delete local");
        }

        [HttpGet("{code}/coordinates")]
        public async Task<IActionResult> GetGPSCoordinates(string code)
        {
            var gpsCoordinates = await _localService.GetGPSCoordinates(code);
            if (gpsCoordinates == null)
            {
                return NotFound("Coordinates not found");
            }
            return Ok(gpsCoordinates);
        }
    }
}
