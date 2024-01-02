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
    public class LocalService : ServiceAsync<Local, LocalDto>, ILocalService
    {
        
        private readonly IRepositoryAsync<Local> LocalRepository;
        private readonly IServiceAsync<Local,LocalDto> srvLocal;
        private readonly IMapper mapper;
        

        

            

        public LocalService(IRepositoryAsync<Local> LocalRepository,
             IServiceAsync<Local, LocalDto> srvLocal,
             IMapper mapper)
            : base(LocalRepository, mapper)
        {

            this.LocalRepository = LocalRepository;
            this.srvLocal = srvLocal;
            this.mapper = mapper;
            
            

        }

        
       

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<LocalDto> GetLocals()
        {
            return this.srvLocal.GetAll();
             
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodeLocal"></param>
        /// <returns></returns>
        public async Task<LocalDto> GetLocal(string IdLocal)
        {
            return await this.srvLocal.GetById(IdLocal);
        }

             

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Local"></param>
        /// <returns></returns>
        public async Task<bool> AddLocal(LocalDto Local)
        {
            await srvLocal.Add(Local);
            return true;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Local"></param>
        /// <returns></returns>
        public async Task<bool> UpdLocal(LocalDto Local)
        {

            await srvLocal.Update(Local);
            return true;
            
            
        }

           

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodeLocal"></param>
        /// <returns></returns>
        public async Task<bool> DelLocal(string IdLocal)
        {

            await srvLocal.Delete(IdLocal);
            return true;
                
        }

        public async Task<string> GetGPSCoordinates(string IdLocal)
        {
            var local = await srvLocal.GetById(IdLocal);

            if (local == null || local.Coordonnees == null)
            {
                // Gérer le cas où le local n'existe pas ou n'a pas de coordonnées
                return null;
            }

            var coordinates = local.Coordonnees.Value;

            //  les coordonnées de type NpgsqlPoint soient Latitude et Longitude
          
            var gpsCoordinates = $"Latitude: {coordinates.X}, Longitude: {coordinates.Y}";

            return gpsCoordinates;
        }
    }
}