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
    public class DossierService : ServiceAsync<Dossier, DossierDto>, IDossierService
    {

        private readonly IRepositoryAsync<Dossier> DossierRepository;
        private readonly IServiceAsync<Dossier, DossierDto> srvDossier;
        private readonly IMapper mapper;






        public DossierService(IRepositoryAsync<Dossier> DossierRepository,
             IServiceAsync<Dossier, DossierDto> srvDossier,
             IMapper mapper)
            : base(DossierRepository, mapper)
        {

            this.DossierRepository = DossierRepository;
            this.srvDossier = srvDossier;
            this.mapper = mapper;



        }




        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<DossierDto> GetDossiers()
        {
            return this.srvDossier.GetAll();

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdDossier"></param>
        /// <returns></returns>
        public async Task<DossierDto> GetDossier(string IdDossier)
        {
            return await this.srvDossier.GetById(IdDossier);
        }


        /// <summary>
        /// 
        /// </summary>
        /// Récupérer des dossiers par IdUniteResponsable
        /// <returns></returns>
        public async Task<IEnumerable<DossierDto>> GetDossiersByIdUnite(string idUniteResponsable)
        {
            return await srvDossier.GetMuliple(d => d.IdUniteResponsable == idUniteResponsable);
        }

        /// <summary>
        /// 
        /// </summary>
        /// Récupérer des dossiers par Date
        /// <returns></returns>
        /// 
        public async Task<IEnumerable<DossierDto>> GetDossiersByDate(DateTime date)
        {
            DateOnly dateOnlyValue = DateOnly.FromDateTime(date); // Conversion explicite de DateTime en DateOnly
            return await srvDossier.GetMuliple(d => d.Date == dateOnlyValue);
        }



        /// <summary>
        /// 
        /// </summary>
        /// Récupérer des dossiers par IdLocal
        /// <returns></returns>
        /// 
        public async Task<IEnumerable<DossierDto>> GetDossiersByIdLocal(string idLocal)
        {
            return await srvDossier.GetMuliple(d => d.IdLocal == idLocal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// SearchDossiers par IdDossier, Date, IdLocal et IdUniteResponsable
        /// <returns></returns>
        /// 

        public async Task<IEnumerable<DossierDto>> SearchDossiers(string codeDossier = null, DateTime? date = null, string idLocal = null, string idUniteResponsable = null)
        {
            var query = srvDossier.GetAll();

            if (!string.IsNullOrEmpty(codeDossier))
            {
                query = query.Where(d => d.IdDossier == codeDossier);
            }

            if (date.HasValue)
            {
                DateOnly dateOnlyValue = DateOnly.FromDateTime(date.Value); // Conversion explicite de DateTime en DateOnly
                query = query.Where(d => d.Date == dateOnlyValue);
            }

            if (!string.IsNullOrEmpty(idLocal))
            {
                query = query.Where(d => d.IdLocal == idLocal);
            }

            if (!string.IsNullOrEmpty(idUniteResponsable))
            {
                query = query.Where(d => d.IdUniteResponsable == idUniteResponsable);
            }

            return query.ToList(); // Retour synchrone
        }

        /// <summary>
        /// 
        /// </summary>
        /// Insertion
        /// <returns></returns>
        /// 
        public async Task<bool> AddDossier(DossierDto dossierDto)
        {
            //////var dossierEntity = mapper.Map<Dossier>(dossierDto);
            await srvDossier.Add(dossierDto);
            return true;
        }

    }
}