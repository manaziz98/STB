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
    public  interface ILocalService : IServiceAsync<Local, LocalDto>
    {
        IQueryable<LocalDto> GetLocals();
        Task<LocalDto> GetLocal(string IdLocal);


        /// Operation de MAJ        
        Task<bool> AddLocal(LocalDto Local);
        Task<bool> UpdLocal(LocalDto Local);
        Task<bool> DelLocal(string IdLocal);
        Task<string> GetGPSCoordinates(string IdLocal);




    }
}
