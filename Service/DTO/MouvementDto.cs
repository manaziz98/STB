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
    public class MouvementDto : IMapFrom<Mouvement>
    {
        public string IdMouvement { get; set; }

        public string ServeurDemandeur { get; set; }

        public string NomUtilisateur { get; set; }

        public DateOnly? DateEnvoie { get; set; }

        public DateOnly? DateDecharge { get; set; }

        public DateOnly? DateRetour { get; set; }

        public string NatureDoc { get; set; }

        public string Etat { get; set; }

        public string IdDossier { get; set; }

        public virtual Dossier IdDossierNavigation { get; set; }

        public void Mapping(Profile profile)
    {
        profile.CreateMap<Mouvement, MouvementDto>().ReverseMap();

    }
    }
}
