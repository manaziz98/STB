using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Operation
{
    public string Code { get; set; }

    public string Libelle { get; set; }

    public virtual ICollection<SousDossier> SousDossiers { get; set; } = new List<SousDossier>();
}
