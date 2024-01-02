using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Mouvement
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
}
