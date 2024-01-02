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
    public  interface IAgenceService : IServiceAsync<Agence, AgenceDto>
    {
        IQueryable<AgenceDto> GetAgences();
        Task<AgenceDto> GetAgence(string CodeAgence);


        /// Operation de MAJ        
        Task<bool> AddAgence(AgenceDto Agence);
        Task<bool> UpdAgence(AgenceDto Agence);
        Task<bool> DelAgence(string CodeAgence);

        




    }
}
