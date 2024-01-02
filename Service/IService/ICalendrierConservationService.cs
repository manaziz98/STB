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
    public  interface ICalendrierConservationService : IServiceAsync<CalendrierConservation, CalendrierConservationDto>
    {
        IQueryable<CalendrierConservationDto> GetCalendrierConservations();
        Task<CalendrierConservationDto> GetCalendrierConservation(string CodeCalendrierConservation);


        /// Operation de MAJ        
        Task<bool> AddCalendrierConservation(CalendrierConservationDto CalendrierConservation);
        Task<bool> UpdCalendrierConservation(CalendrierConservationDto CalendrierConservation);
        Task<bool> DelCalendrierConservation(string CodeCalendrierConservation);

        




    }
}
