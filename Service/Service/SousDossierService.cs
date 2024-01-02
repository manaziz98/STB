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
    public class SousDossierService : ServiceAsync<SousDossier, SousDossierDto>, ISousDossierService
    {
        
        private readonly IRepositoryAsync<SousDossier> SousDossierRepository;
        private readonly IServiceAsync<SousDossier,SousDossierDto> srvSousDossier;
        private readonly IMapper mapper;
        

        

            

        public SousDossierService(IRepositoryAsync<SousDossier> SousDossierRepository,
             IServiceAsync<SousDossier, SousDossierDto> srvSousDossier,
             IMapper mapper)
            : base(SousDossierRepository, mapper)
        {

            this.SousDossierRepository = SousDossierRepository;
            this.srvSousDossier = srvSousDossier;
            this.mapper = mapper;
            
            

        }

        
       

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<SousDossierDto> GetSousDossiers()
        {
            return this.srvSousDossier.GetAll();
             
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodeSousDossier"></param>
        /// <returns></returns>
        public async Task<SousDossierDto> GetSousDossier(string CodeSousDossier)
        {
            return await this.srvSousDossier.GetById(CodeSousDossier);
        }

             

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SousDossier"></param>
        /// <returns></returns>
        public async Task<bool> AddSousDossier(SousDossierDto SousDossier)
        {
            await srvSousDossier.Add(SousDossier);
            return true;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SousDossier"></param>
        /// <returns></returns>
        public async Task<bool> UpdSousDossier(SousDossierDto SousDossier)
        {

            await srvSousDossier.Update(SousDossier);
            return true;
            
            
        }

           

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodeSousDossier"></param>
        /// <returns></returns>
        public async Task<bool> DelSousDossier(string CodeSousDossier)
        {

            await srvSousDossier.Delete(CodeSousDossier);
            return true;
                
        }

        
    }
}