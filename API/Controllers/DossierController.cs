using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.DTO;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Service.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using AutoMapper;

namespace VotreNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DossierController : ControllerBase
    {
        private readonly IDossierService _dossierService;
        private readonly ILocalService _localService;
        private readonly IUniteResponsableService _uniteResponsableService;
        private readonly IMapper _mapper;
        private readonly Serilog.ILogger _logger;

        public DossierController(IDossierService dossierService, IUniteResponsableService uniteResponsableService,  ILocalService localService, Serilog.ILogger logger, IMapper mapper)
        {
            _dossierService = dossierService;
            _localService = localService;
            _uniteResponsableService = uniteResponsableService;
            _logger = logger;
            _mapper = mapper;
        }

        // Endpoint pour récupérer tous les dossiers
        [HttpGet]
        public IActionResult GetDossiers()
        {
            var dossiers = _dossierService.GetDossiers();
            if (dossiers != null)
            {
                return Ok(dossiers);
            }
            return BadRequest("Failed to add local");
            
        }
        //public async Task<ActionResult<IEnumerable<DossierDto>>> GetDossiers()
        //{
        //    try
        //    {
        //        var dossiers = await _dossierService.GetDossiers().ToListAsync().ConfigureAwait(false);
        //        return Ok(dossiers);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.Error("Erreur GetDossiers <==> " + ex.ToString());
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}


        // Endpoint pour ajouter un dossier
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> AddDossier([FromForm] DossierDto dossierDto)
        {
            try
            {
                _logger.Information("this idLocal: " +  dossierDto.IdLocal);
                if (dossierDto.File != null && dossierDto.File.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await dossierDto.File.CopyToAsync(ms);
                        dossierDto.ScanDossier = ms.ToArray(); // Convert to byte array
                    }
                }

                dossierDto.IdLocalNavigation ??= new LocalDto();
                dossierDto.IdUniteResponsableNavigation ??= new UniteResponsableDto();


                var added = await _dossierService.AddDossier(dossierDto);
                return Ok(added);
            }
            catch (Exception ex)
            {
                _logger.Error("Erreur AddDossier <==> " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        // Endpoint pour récupérer un dossier par son IdDossier
        [HttpGet("{IdDossier}")]
        public async Task<ActionResult<DossierDto>> GetDossier(string IdDossier)
        {
            try
            {
                var dossier = await _dossierService.GetDossier(IdDossier).ConfigureAwait(false);
                if (dossier != null)
                    return Ok(dossier);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.Error("Erreur GetDossier <==> " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // Endpoint pour rechercher des dossiers avec différents critères
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<DossierDto>>> SearchDossiers(string codeDossier = null, DateTime? date = null, string idLocal = null, string idUniteResponsable = null)
        {
            try
            {
                var dossiers = await _dossierService.SearchDossiers(codeDossier, date, idLocal, idUniteResponsable).ConfigureAwait(false);
                return Ok(dossiers);
            }
            catch (Exception ex)
            {
                _logger.Error("Erreur SearchDossiers <==> " + ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
