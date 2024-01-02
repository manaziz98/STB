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
    public class AgenceDto : IMapFrom<Agence>
    {

        public string CodeAgence { get; set; }

        public string Nom { get; set; }

        public string Adresse { get; set; }

        public string Telephone { get; set; }

        public virtual ICollection<UniteResponsableDto> UniteResponsables { get; set; } = new List<UniteResponsableDto>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Agence, AgenceDto>().ReverseMap();

        }

    }
}
