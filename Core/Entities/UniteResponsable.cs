using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class UniteResponsable
{
    public string IdUnite { get; set; } = Guid.NewGuid().ToString();

    public string? NomUnite { get; set; }

    public string? Adresse { get; set; }

    public string? Numero { get; set; }

    public string? CodeAgence { get; set; }

    public virtual ICollection<CalendrierConservation> CalendrierConservations { get; set; } = new List<CalendrierConservation>();

    public virtual Agence CodeAgenceNavigation { get; set; }

    public virtual ICollection<Dossier> Dossiers { get; set; } = new List<Dossier>();
}
