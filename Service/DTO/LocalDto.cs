using AutoMapper;
using Core.Entities;
using NpgsqlTypes;
using Service.Common.Mappings;
using System.Collections.Generic;

namespace Service.DTO
{
    public class LocalDto : IMapFrom<Local>
    {
         public string IdLocal { get; set; } = Guid.NewGuid().ToString();

        public string? Adresse { get; set; }

        public string? Localisation { get; set; }

        public NpgsqlPoint? Coordonnees { get; set; }

        public ICollection<DossierDto> Dossiers { get; set; } = new List<DossierDto>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Local, LocalDto>().ReverseMap();
        }
    }
}
