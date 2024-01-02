using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Dossier
{
    public string IdDossier { get; set; }

    public string Intitule { get; set; }

    public int? DelaisConserv { get; set; }

    public DateOnly? Date { get; set; }

    public string IdLocal { get; set; }

    public string IdUniteResponsable { get; set; }

    public byte[] ScanDossier { get; set; }

    public virtual Local IdLocalNavigation { get; set; }

    public virtual UniteResponsable IdUniteResponsableNavigation { get; set; }

    public virtual ICollection<Mouvement> Mouvements { get; set; } = new List<Mouvement>();

    public virtual ICollection<SousDossier> SousDossiers { get; set; } = new List<SousDossier>();
}
