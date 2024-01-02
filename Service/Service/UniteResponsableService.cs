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
    public class UniteResponsableService : ServiceAsync<UniteResponsable, UniteResponsableDto>, IUniteResponsableService
    {
        
        private readonly IRepositoryAsync<UniteResponsable> UniteResponsableRepository;
        private readonly IServiceAsync<UniteResponsable,UniteResponsableDto> srvUniteResponsable;
        private readonly IMapper mapper;
        

        

            

        public UniteResponsableService(IRepositoryAsync<UniteResponsable> UniteResponsableRepository,
             IServiceAsync<UniteResponsable, UniteResponsableDto> srvUniteResponsable,
             IMapper mapper)
            : base(UniteResponsableRepository, mapper)
        {

            this.UniteResponsableRepository = UniteResponsableRepository;
            this.srvUniteResponsable = srvUniteResponsable;
            this.mapper = mapper;
            
            

        }

        
       

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<UniteResponsableDto> GetUniteResponsables()
        {
            return this.srvUniteResponsable.GetAll();
             
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodeUniteResponsable"></param>
        /// <returns></returns>
        public async Task<UniteResponsableDto> GetUniteResponsable(string CodeUniteResponsable)
        {
            return await this.srvUniteResponsable.GetById(CodeUniteResponsable);
        }

             

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UniteResponsable"></param>
        /// <returns></returns>
        public async Task<bool> AddUniteResponsable(UniteResponsableDto UniteResponsable)
        {
            await srvUniteResponsable.Add(UniteResponsable);
            return true;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UniteResponsable"></param>
        /// <returns></returns>
        public async Task<bool> UpdUniteResponsable(UniteResponsableDto UniteResponsable)
        {

            await srvUniteResponsable.Update(UniteResponsable);
            return true;
            
            
        }

           

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodeUniteResponsable"></param>
        /// <returns></returns>
        public async Task<bool> DelUniteResponsable(string CodeUniteResponsable)
        {

            await srvUniteResponsable.Delete(CodeUniteResponsable);
            return true;
                
        }

        
    }
}