using AutoMapper;
using Core.Entities;
using Service.Common.Mappings;
using Microsoft.AspNetCore.Http; // Include this namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class DossierDto : IMapFrom<Dossier>
    {
        public string IdDossier { get; set; }

        public string Intitule { get; set; }

        public int? DelaisConserv { get; set; }

        public DateOnly? Date { get; set; }

        public string IdLocal { get; set; }

        public string IdUniteResponsable { get; set; }

        public IFormFile File { get; set; } // Add this property for file upload
        public byte[]? ScanDossier { get; set; }

        public LocalDto? IdLocalNavigation { get; set; }

        public UniteResponsableDto? IdUniteResponsableNavigation { get; set; }

        public ICollection<MouvementDto> Mouvements { get; set; } = new List<MouvementDto>();

        public ICollection<SousDossierDto> SousDossiers { get; set; } = new List<SousDossierDto>();

     

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Dossier, DossierDto>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date)) // Mapping direct
                .ReverseMap();
        }
    }
}
