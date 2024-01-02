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
    public  interface IUniteResponsableService : IServiceAsync<UniteResponsable, UniteResponsableDto>
    {
        IQueryable<UniteResponsableDto> GetUniteResponsables();
        Task<UniteResponsableDto> GetUniteResponsable(string CodeUniteResponsable);


        /// Operation de MAJ        
        Task<bool> AddUniteResponsable(UniteResponsableDto UniteResponsable);
        Task<bool> UpdUniteResponsable(UniteResponsableDto UniteResponsable);
        Task<bool> DelUniteResponsable(string CodeUniteResponsable);

        




    }
}
