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
    public class UniteResponsableDto : IMapFrom<UniteResponsable>
    {
        public string IdUnite { get; set; }

        public string NomUnite { get; set; }

        public string Adresse { get; set; }

        public string Numero { get; set; }

        public string CodeAgence { get; set; }

        public virtual ICollection<CalendrierConservationDto> CalendrierConservations { get; set; } = new List<CalendrierConservationDto>();

        public virtual Agence CodeAgenceNavigation { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UniteResponsable, UniteResponsableDto>().ReverseMap();

        }
    }
}
