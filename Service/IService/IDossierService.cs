using Core.Entities;
using Microsoft.AspNetCore.Http;
using Service.DTO;
 

 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace Service.IService
{
    public interface IDossierService
    {
        IQueryable<DossierDto> GetDossiers();

        Task<DossierDto> GetDossier(string IdDossier);

        Task<IEnumerable<DossierDto>> GetDossiersByIdUnite(string idUniteResponsable);

        Task<IEnumerable<DossierDto>> GetDossiersByDate(DateTime date);

        Task<IEnumerable<DossierDto>> GetDossiersByIdLocal(string idLocal);

        Task<IEnumerable<DossierDto>> SearchDossiers(string codeDossier = null, DateTime? date = null, string idLocal = null, string idUniteResponsable = null);
        Task<bool> AddDossier(DossierDto dossierDto);
    }
}
