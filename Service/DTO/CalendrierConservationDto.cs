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
    public class CalendrierConservationDto : IMapFrom<CalendrierConservation>
    {
        public string NRegle { get; set; }

        public string CodeSousDossier { get; set; }

        public string IdUnite { get; set; }

        public virtual SousDossier CodeSousDossierNavigation { get; set; }

        public virtual UniteResponsable IdUniteNavigation { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CalendrierConservation, CalendrierConservationDto>().ReverseMap();

        }
    }
}

