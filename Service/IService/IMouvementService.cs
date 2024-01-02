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
    public  interface IMouvementService : IServiceAsync<Mouvement, MouvementDto>
    {
        IQueryable<MouvementDto> GetMouvements();
        Task<MouvementDto> GetMouvement(string CodeMouvement);


        /// Operation de MAJ        
        Task<bool> AddMouvement(MouvementDto Mouvement);
        Task<bool> UpdMouvement(MouvementDto Mouvement);
        Task<bool> DelMouvement(string CodeMouvement);

        




    }
}
