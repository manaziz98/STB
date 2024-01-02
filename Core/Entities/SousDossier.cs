using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class SousDossier
{
    public string IdSousDossier { get; set; }

    public string CodeOperation { get; set; }

    public string IdDossier { get; set; }

    public virtual ICollection<CalendrierConservation> CalendrierConservations { get; set; } = new List<CalendrierConservation>();

    public virtual Operation CodeOperationNavigation { get; set; }

    public virtual Dossier IdDossierNavigation { get; set; }
}
