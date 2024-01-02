using AutoMapper;
using Core.Entities;
using Core.Utilitaires;
using DAL;
using DAL.IRepository;

using Microsoft.EntityFrameworkCore;
using Npgsql;
using Service.DTO;
using Service.IService;
//using Service.Modeles;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace Service.Service
{
    public class CalendrierConservationService : ServiceAsync<CalendrierConservation, CalendrierConservationDto>, ICalendrierConservationService
    {
        
        private readonly IRepositoryAsync<CalendrierConservation> CalendrierConservationRepository;
        private readonly IServiceAsync<CalendrierConservation,CalendrierConservationDto> srvCalendrierConservation;
        private readonly IMapper mapper;
        

        

            

        public CalendrierConservationService(IRepositoryAsync<CalendrierConservation> CalendrierConservationRepository,
             IServiceAsync<CalendrierConservation, CalendrierConservationDto> srvCalendrierConservation,
             IMapper mapper)
            : base(CalendrierConservationRepository, mapper)
        {

            this.CalendrierConservationRepository = CalendrierConservationRepository;
            this.srvCalendrierConservation = srvCalendrierConservation;
            this.mapper = mapper;
            
            

        }

        
       

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<CalendrierConservationDto> GetCalendrierConservations()
        {
            return this.srvCalendrierConservation.GetAll();
             
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodeCalendrierConservation"></param>
        /// <returns></returns>
        public async Task<CalendrierConservationDto> GetCalendrierConservation(string CodeCalendrierConservation)
        {
            return await this.srvCalendrierConservation.GetById(CodeCalendrierConservation);
        }

             

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CalendrierConservation"></param>
        /// <returns></returns>
        public async Task<bool> AddCalendrierConservation(CalendrierConservationDto CalendrierConservation)
        {
            await srvCalendrierConservation.Add(CalendrierConservation);
            return true;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CalendrierConservation"></param>
        /// <returns></returns>
        public async Task<bool> UpdCalendrierConservation(CalendrierConservationDto CalendrierConservation)
        {

            await srvCalendrierConservation.Update(CalendrierConservation);
            return true;
            
            
        }

           

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodeCalendrierConservation"></param>
        /// <returns></returns>
        public async Task<bool> DelCalendrierConservation(string CodeCalendrierConservation)
        {

            await srvCalendrierConservation.Delete(CodeCalendrierConservation);
            return true;
                
        }

        
    }
}