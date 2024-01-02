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
    public  interface IOperationService : IServiceAsync<Operation, OperationDto>
    {
        IQueryable<OperationDto> GetOperations();
        Task<OperationDto> GetOperation(string CodeOperation);


        /// Operation de MAJ        
        Task<bool> AddOperation(OperationDto Operation);
        Task<bool> UpdOperation(OperationDto Operation);
        Task<bool> DelOperation(string CodeOperation);

        




    }
}
