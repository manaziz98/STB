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
    public class MouvementService : ServiceAsync<Mouvement, MouvementDto>, IMouvementService
    {
        
        private readonly IRepositoryAsync<Mouvement> MouvementRepository;
        private readonly IServiceAsync<Mouvement,MouvementDto> srvMouvement;
        private readonly IMapper mapper;
        

        

            

        public MouvementService(IRepositoryAsync<Mouvement> MouvementRepository,
             IServiceAsync<Mouvement, MouvementDto> srvMouvement,
             IMapper mapper)
            : base(MouvementRepository, mapper)
        {

            this.MouvementRepository = MouvementRepository;
            this.srvMouvement = srvMouvement;
            this.mapper = mapper;
            
            

        }

        
       

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<MouvementDto> GetMouvements()
        {
            return this.srvMouvement.GetAll();
             
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodeMouvement"></param>
        /// <returns></returns>
        public async Task<MouvementDto> GetMouvement(string CodeMouvement)
        {
            return await this.srvMouvement.GetById(CodeMouvement);
        }

             

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Mouvement"></param>
        /// <returns></returns>
        public async Task<bool> AddMouvement(MouvementDto Mouvement)
        {
            await srvMouvement.Add(Mouvement);
            return true;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Mouvement"></param>
        /// <returns></returns>
        public async Task<bool> UpdMouvement(MouvementDto Mouvement)
        {

            await srvMouvement.Update(Mouvement);
            return true;
            
            
        }

           

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodeMouvement"></param>
        /// <returns></returns>
        public async Task<bool> DelMouvement(string CodeMouvement)
        {

            await srvMouvement.Delete(CodeMouvement);
            return true;
                
        }

        
    }
}