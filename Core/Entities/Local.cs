using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace Core.Entities;

public partial class Local
{
    public string IdLocal { get; set; }

    public string Adresse { get; set; }

    public string Localisation { get; set; }

    public NpgsqlPoint? Coordonnees { get; set; }

    public virtual ICollection<Dossier> Dossiers { get; set; } = new List<Dossier>();
}
