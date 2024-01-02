using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.IService;
using Serilog;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgenceController : ControllerBase
    {

        private readonly IAgenceService _service;
        private readonly Serilog.ILogger _logger;

        public AgenceController(IAgenceService service, Serilog.ILogger logger)
        {
            _service = service;
            _logger = logger;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodeAgence"></param>
        /// <returns></returns>
        [HttpGet("{CodeAgence}")]
        public async Task<ActionResult<AgenceDto>> GetBanque(string CodeAgence)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                var Age = await _service.GetAgence(CodeAgence).ConfigureAwait(false);
                _logger.Error("Erreur GetAgence <==> ");
                if (Age != null)
                {
                    return new OkObjectResult(Age);
                }
                else
                {
                    var showmessage = "Agence inexistant";
                    dict.Add("Message", showmessage);
                    return NotFound(dict);

                }

            }
            catch (Exception ex)
            {
                _logger.Error("Erreur GetAgence <==> " + ex.ToString());
                var showmessage = "Erreur" + ex.Message;
                dict.Add("Message", showmessage);
                return BadRequest(dict);
            }
        }




    }
}
