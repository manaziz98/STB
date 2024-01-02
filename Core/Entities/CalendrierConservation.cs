using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class CalendrierConservation
{
    public string NRegle { get; set; }

    public string CodeSousDossier { get; set; }

    public string IdUnite { get; set; }

    public virtual SousDossier CodeSousDossierNavigation { get; set; }

    public virtual UniteResponsable IdUniteNavigation { get; set; }
}
