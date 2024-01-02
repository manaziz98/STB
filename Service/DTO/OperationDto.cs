using AutoMapper;
using Core.Entities;
using Service.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class OperationDto : IMapFrom<Operation>
    {
        public string Code { get; set; }

        public string Libelle { get; set; }

        public virtual ICollection<SousDossierDto> SousDossiers { get; set; } = new List<SousDossierDto>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Operation, OperationDto>().ReverseMap();

        }

    }

}
