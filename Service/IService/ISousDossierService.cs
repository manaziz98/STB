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
    public  interface ISousDossierService : IServiceAsync<SousDossier, SousDossierDto>
    {
        IQueryable<SousDossierDto> GetSousDossiers();
        Task<SousDossierDto> GetSousDossier(string CodeSousDossier);


        /// Operation de MAJ        
        Task<bool> AddSousDossier(SousDossierDto SousDossier);
        Task<bool> UpdSousDossier(SousDossierDto SousDossier);
        Task<bool> DelSousDossier(string CodeSousDossier);

        




    }
}
