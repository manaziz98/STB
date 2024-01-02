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
    public class AgenceService : ServiceAsync<Agence, AgenceDto>, IAgenceService
    {
        
        private readonly IRepositoryAsync<Agence> AgenceRepository;
        private readonly IServiceAsync<Agence,AgenceDto> srvAgence;
        private readonly IMapper mapper;
        

        

            

        public AgenceService(IRepositoryAsync<Agence> AgenceRepository,
             IServiceAsync<Agence, AgenceDto> srvAgence,
             IMapper mapper)
            : base(AgenceRepository, mapper)
        {

            this.AgenceRepository = AgenceRepository;
            this.srvAgence = srvAgence;
            this.mapper = mapper;
            
            

        }

        
       

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<AgenceDto> GetAgences()
        {
            return this.srvAgence.GetAll();
             
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodeAgence"></param>
        /// <returns></returns>
        public async Task<AgenceDto> GetAgence(string CodeAgence)
        {
            var Age = await  srvAgence.GetFirstOrDefault(predicate: (i => i.CodeAgence == CodeAgence),
                                          orderBy: (i => i.OrderBy(a => a.CodeAgence)),
                                          include: (s => s.Include(s1 => s1.UniteResponsables)),
                                          true);
            //return await this.srvAgence.GetById(CodeAgence);
            return Age;
        }

             

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Agence"></param>
        /// <returns></returns>
        public async Task<bool> AddAgence(AgenceDto Agence)
        {
            await srvAgence.Add(Agence);
            return true;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Agence"></param>
        /// <returns></returns>
        public async Task<bool> UpdAgence(AgenceDto Agence)
        {

            await srvAgence.Update(Agence);
            return true;
            
            
        }

           

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodeAgence"></param>
        /// <returns></returns>
        public async Task<bool> DelAgence(string CodeAgence)
        {

            await srvAgence.Delete(CodeAgence);
            return true;
                
        }

        
    }
}