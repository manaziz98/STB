using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Agence
{
    public string CodeAgence { get; set; }

    public string Nom { get; set; }

    public string Adresse { get; set; }

    public string NumTelephone { get; set; }

    public virtual ICollection<UniteResponsable> UniteResponsables { get; set; } = new List<UniteResponsable>();
}
