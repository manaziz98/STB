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
    public class OperationService : ServiceAsync<Operation, OperationDto>, IOperationService
    {
        
        private readonly IRepositoryAsync<Operation> OperationRepository;
        private readonly IServiceAsync<Operation,OperationDto> srvOperation;
        private readonly IMapper mapper;
        

        

            

        public OperationService(IRepositoryAsync<Operation> OperationRepository,
             IServiceAsync<Operation, OperationDto> srvOperation,
             IMapper mapper)
            : base(OperationRepository, mapper)
        {

            this.OperationRepository = OperationRepository;
            this.srvOperation = srvOperation;
            this.mapper = mapper;
            
            

        }

        
       

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<OperationDto> GetOperations()
        {
            return this.srvOperation.GetAll();
             
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodeOperation"></param>
        /// <returns></returns>
        public async Task<OperationDto> GetOperation(string CodeOperation)
        {
            return await this.srvOperation.GetById(CodeOperation);
        }

             

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Operation"></param>
        /// <returns></returns>
        public async Task<bool> AddOperation(OperationDto Operation)
        {
            await srvOperation.Add(Operation);
            return true;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Operation"></param>
        /// <returns></returns>
        public async Task<bool> UpdOperation(OperationDto Operation)
        {

            await srvOperation.Update(Operation);
            return true;
            
            
        }

           

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodeOperation"></param>
        /// <returns></returns>
        public async Task<bool> DelOperation(string CodeOperation)
        {

            await srvOperation.Delete(CodeOperation);
            return true;
                
        }

        
    }
}