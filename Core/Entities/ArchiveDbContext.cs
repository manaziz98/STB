using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities;

public partial class ArchiveDbContext : DbContext
{
    public ArchiveDbContext()
    {
    }

    public ArchiveDbContext(DbContextOptions<ArchiveDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agence> Agences { get; set; }

    public virtual DbSet<CalendrierConservation> CalendrierConservations { get; set; }

    public virtual DbSet<Dossier> Dossiers { get; set; }

    public virtual DbSet<Local> Locals { get; set; }

    public virtual DbSet<Mouvement> Mouvements { get; set; }

    public virtual DbSet<Operation> Operations { get; set; }

    public virtual DbSet<SousDossier> SousDossiers { get; set; }

    public virtual DbSet<UniteResponsable> UniteResponsables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=STB;Username=postgres;Password=123456");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agence>(entity =>
        {
            entity.HasKey(e => e.CodeAgence).HasName("agence_pkey");

            entity.ToTable("agence");

            entity.Property(e => e.CodeAgence)
                .HasColumnType("character varying")
                .HasColumnName("code_agence");
            entity.Property(e => e.Adresse)
                .HasColumnType("character varying")
                .HasColumnName("adresse");
            entity.Property(e => e.Nom)
                .HasColumnType("character varying")
                .HasColumnName("nom");
            entity.Property(e => e.NumTelephone)
                .HasColumnType("character varying")
                .HasColumnName("num_telephone");
        });

        modelBuilder.Entity<CalendrierConservation>(entity =>
        {
            entity.HasKey(e => e.NRegle).HasName("calendrier_conservation_pkey");

            entity.ToTable("calendrier_conservation");

            entity.Property(e => e.NRegle)
                .HasColumnType("character varying")
                .HasColumnName("n_regle");
            entity.Property(e => e.CodeSousDossier)
                .HasColumnType("character varying")
                .HasColumnName("code_sous_dossier");
            entity.Property(e => e.IdUnite)
                .HasColumnType("character varying")
                .HasColumnName("id_unite");

            entity.HasOne(d => d.CodeSousDossierNavigation).WithMany(p => p.CalendrierConservations)
                .HasForeignKey(d => d.CodeSousDossier)
                .HasConstraintName("calendrier_conservation_code_sous_dossier_fkey");

            entity.HasOne(d => d.IdUniteNavigation).WithMany(p => p.CalendrierConservations)
                .HasForeignKey(d => d.IdUnite)
                .HasConstraintName("calendrier_conservation_id_unite_fkey");
        });

        modelBuilder.Entity<Dossier>(entity =>
        {
            entity.HasKey(e => e.IdDossier).HasName("dossier_pkey");

            entity.ToTable("dossier");

            entity.Property(e => e.IdDossier)
                .HasColumnType("character varying")
                .HasColumnName("id_dossier");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DelaisConserv).HasColumnName("delais_conserv");
            entity.Property(e => e.IdLocal)
                .HasColumnType("character varying")
                .HasColumnName("id_local");
            entity.Property(e => e.IdUniteResponsable)
                .HasColumnType("character varying")
                .HasColumnName("id_unite_responsable");
            entity.Property(e => e.Intitule)
                .HasColumnType("character varying")
                .HasColumnName("intitule");
            entity.Property(e => e.ScanDossier).HasColumnName("scan_dossier");

           entity.HasOne(d => d.IdLocalNavigation).WithMany(p => p.Dossiers)
                .HasForeignKey(d => d.IdLocal)
                .HasConstraintName("dossier_id_local_fkey");

            entity.HasOne(d => d.IdUniteResponsableNavigation).WithMany(p => p.Dossiers)
                .HasForeignKey(d => d.IdUniteResponsable)
                .HasConstraintName("dossier_id_unite_responsable_fkey");
        });

        modelBuilder.Entity<Local>(entity =>
        {
            entity.HasKey(e => e.IdLocal).HasName("local_pkey");

            entity.ToTable("local");

            entity.Property(e => e.IdLocal)
                .HasColumnType("character varying")
                .HasColumnName("id_local");
            entity.Property(e => e.Adresse)
                .HasColumnType("character varying")
                .HasColumnName("adresse");
            entity.Property(e => e.Coordonnees).HasColumnName("coordonnees");
            entity.Property(e => e.Localisation)
                .HasColumnType("character varying")
                .HasColumnName("localisation");
        });

        modelBuilder.Entity<Mouvement>(entity =>
        {
            entity.HasKey(e => e.IdMouvement).HasName("mouvement_pkey");

            entity.ToTable("mouvement");

            entity.Property(e => e.IdMouvement)
                .HasColumnType("character varying")
                .HasColumnName("id_mouvement");
            entity.Property(e => e.DateDecharge).HasColumnName("date_decharge");
            entity.Property(e => e.DateEnvoie).HasColumnName("date_envoie");
            entity.Property(e => e.DateRetour).HasColumnName("date_retour");
            entity.Property(e => e.Etat)
                .HasColumnType("character varying")
                .HasColumnName("etat");
            entity.Property(e => e.IdDossier)
                .HasColumnType("character varying")
                .HasColumnName("id_dossier");
            entity.Property(e => e.NatureDoc)
                .HasColumnType("character varying")
                .HasColumnName("nature_doc");
            entity.Property(e => e.NomUtilisateur)
                .HasColumnType("character varying")
                .HasColumnName("nom_utilisateur");
            entity.Property(e => e.ServeurDemandeur)
                .HasColumnType("character varying")
                .HasColumnName("serveur_demandeur");

            entity.HasOne(d => d.IdDossierNavigation).WithMany(p => p.Mouvements)
                .HasForeignKey(d => d.IdDossier)
                .HasConstraintName("mouvement_id_dossier_fkey");
        });

        modelBuilder.Entity<Operation>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("operation_pkey");

            entity.ToTable("operation");

            entity.Property(e => e.Code)
                .HasColumnType("character varying")
                .HasColumnName("code");
            entity.Property(e => e.Libelle)
                .HasColumnType("character varying")
                .HasColumnName("libelle");
        });

        modelBuilder.Entity<SousDossier>(entity =>
        {
            entity.HasKey(e => e.IdSousDossier).HasName("sous_dossier_pkey");

            entity.ToTable("sous_dossier");

            entity.Property(e => e.IdSousDossier)
                .HasColumnType("character varying")
                .HasColumnName("id_sous_dossier");
            entity.Property(e => e.CodeOperation)
                .HasColumnType("character varying")
                .HasColumnName("code_operation");
            entity.Property(e => e.IdDossier)
                .HasColumnType("character varying")
                .HasColumnName("id_dossier");

            entity.HasOne(d => d.CodeOperationNavigation).WithMany(p => p.SousDossiers)
                .HasForeignKey(d => d.CodeOperation)
                .HasConstraintName("sous_dossier_code_operation_fkey");

            entity.HasOne(d => d.IdDossierNavigation).WithMany(p => p.SousDossiers)
                .HasForeignKey(d => d.IdDossier)
                .HasConstraintName("sous_dossier_id_dossier_fkey");
        });

        modelBuilder.Entity<UniteResponsable>(entity =>
        {
            entity.HasKey(e => e.IdUnite).HasName("unite_responsable_pkey");

            entity.ToTable("unite_responsable");

            entity.Property(e => e.IdUnite)
                .HasColumnType("character varying")
                .HasColumnName("id_unite");
            entity.Property(e => e.Adresse)
                .HasColumnType("character varying")
                .HasColumnName("adresse");
            entity.Property(e => e.CodeAgence)
                .HasColumnType("character varying")
                .HasColumnName("code_agence");
            entity.Property(e => e.NomUnite)
                .HasColumnType("character varying")
                .HasColumnName("nom_unite");
            entity.Property(e => e.Numero)
                .HasColumnType("character varying")
                .HasColumnName("numero");

            entity.HasOne(d => d.CodeAgenceNavigation).WithMany(p => p.UniteResponsables)
                .HasForeignKey(d => d.CodeAgence)
                .HasConstraintName("unite_responsable_code_agence_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
