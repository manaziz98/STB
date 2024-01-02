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
    public class SousDossierDto : IMapFrom<SousDossier>
    {
        public string IdSousDossier { get; set; }

        public string CodeOperation { get; set; }

        public string IdDossier { get; set; }

        public virtual ICollection<CalendrierConservation> CalendrierConservations { get; set; } = new List<CalendrierConservation>();

        public virtual Operation CodeOperationNavigation { get; set; }

        public virtual Dossier IdDossierNavigation { get; set; }

        public void Mapping(Profile profile)
       {
        profile.CreateMap<SousDossier, SousDossierDto>().ReverseMap();

       }
    }
}
