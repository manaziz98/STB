using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agence",
                columns: table => new
                {
                    code_agence = table.Column<string>(type: "character varying", nullable: false),
                    nom = table.Column<string>(type: "character varying", nullable: false),
                    adresse = table.Column<string>(type: "character varying", nullable: false),
                    num_telephone = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("agence_pkey", x => x.code_agence);
                });

            migrationBuilder.CreateTable(
                name: "local",
                columns: table => new
                {
                    id_local = table.Column<string>(type: "character varying", nullable: false),
                    adresse = table.Column<string>(type: "character varying", nullable: true),
                    localisation = table.Column<string>(type: "character varying", nullable: true),
                    coordonnees = table.Column<NpgsqlPoint>(type: "point", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("local_pkey", x => x.id_local);
                });

            migrationBuilder.CreateTable(
                name: "operation",
                columns: table => new
                {
                    code = table.Column<string>(type: "character varying", nullable: false),
                    libelle = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("operation_pkey", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "unite_responsable",
                columns: table => new
                {
                    id_unite = table.Column<string>(type: "character varying", nullable: false),
                    nom_unite = table.Column<string>(type: "character varying", nullable: true),
                    adresse = table.Column<string>(type: "character varying", nullable: true),
                    numero = table.Column<string>(type: "character varying", nullable: true),
                    code_agence = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("unite_responsable_pkey", x => x.id_unite);
                    table.ForeignKey(
                        name: "unite_responsable_code_agence_fkey",
                        column: x => x.code_agence,
                        principalTable: "agence",
                        principalColumn: "code_agence");
                });

            migrationBuilder.CreateTable(
                name: "dossier",
                columns: table => new
                {
                    id_dossier = table.Column<string>(type: "character varying", nullable: false),
                    intitule = table.Column<string>(type: "character varying", nullable: false),
                    delais_conserv = table.Column<int>(type: "integer", nullable: true),
                    date = table.Column<DateOnly>(type: "date", nullable: true),
                    id_local = table.Column<string>(type: "character varying", nullable: false),
                    id_unite_responsable = table.Column<string>(type: "character varying", nullable: false),
                    scan_dossier = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("dossier_pkey", x => x.id_dossier);
                    table.ForeignKey(
                        name: "dossier_id_local_fkey",
                        column: x => x.id_local,
                        principalTable: "local",
                        principalColumn: "id_local",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "dossier_id_unite_responsable_fkey",
                        column: x => x.id_unite_responsable,
                        principalTable: "unite_responsable",
                        principalColumn: "id_unite",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mouvement",
                columns: table => new
                {
                    id_mouvement = table.Column<string>(type: "character varying", nullable: false),
                    serveur_demandeur = table.Column<string>(type: "character varying", nullable: false),
                    nom_utilisateur = table.Column<string>(type: "character varying", nullable: false),
                    date_envoie = table.Column<DateOnly>(type: "date", nullable: true),
                    date_decharge = table.Column<DateOnly>(type: "date", nullable: true),
                    date_retour = table.Column<DateOnly>(type: "date", nullable: true),
                    nature_doc = table.Column<string>(type: "character varying", nullable: false),
                    etat = table.Column<string>(type: "character varying", nullable: false),
                    id_dossier = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("mouvement_pkey", x => x.id_mouvement);
                    table.ForeignKey(
                        name: "mouvement_id_dossier_fkey",
                        column: x => x.id_dossier,
                        principalTable: "dossier",
                        principalColumn: "id_dossier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sous_dossier",
                columns: table => new
                {
                    id_sous_dossier = table.Column<string>(type: "character varying", nullable: false),
                    code_operation = table.Column<string>(type: "character varying", nullable: false),
                    id_dossier = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sous_dossier_pkey", x => x.id_sous_dossier);
                    table.ForeignKey(
                        name: "sous_dossier_code_operation_fkey",
                        column: x => x.code_operation,
                        principalTable: "operation",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "sous_dossier_id_dossier_fkey",
                        column: x => x.id_dossier,
                        principalTable: "dossier",
                        principalColumn: "id_dossier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "calendrier_conservation",
                columns: table => new
                {
                    n_regle = table.Column<string>(type: "character varying", nullable: false),
                    code_sous_dossier = table.Column<string>(type: "character varying", nullable: false),
                    id_unite = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("calendrier_conservation_pkey", x => x.n_regle);
                    table.ForeignKey(
                        name: "calendrier_conservation_code_sous_dossier_fkey",
                        column: x => x.code_sous_dossier,
                        principalTable: "sous_dossier",
                        principalColumn: "id_sous_dossier",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "calendrier_conservation_id_unite_fkey",
                        column: x => x.id_unite,
                        principalTable: "unite_responsable",
                        principalColumn: "id_unite",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_calendrier_conservation_code_sous_dossier",
                table: "calendrier_conservation",
                column: "code_sous_dossier");

            migrationBuilder.CreateIndex(
                name: "IX_calendrier_conservation_id_unite",
                table: "calendrier_conservation",
                column: "id_unite");

            migrationBuilder.CreateIndex(
                name: "IX_dossier_id_local",
                table: "dossier",
                column: "id_local");

            migrationBuilder.CreateIndex(
                name: "IX_dossier_id_unite_responsable",
                table: "dossier",
                column: "id_unite_responsable");

            migrationBuilder.CreateIndex(
                name: "IX_mouvement_id_dossier",
                table: "mouvement",
                column: "id_dossier");

            migrationBuilder.CreateIndex(
                name: "IX_sous_dossier_code_operation",
                table: "sous_dossier",
                column: "code_operation");

            migrationBuilder.CreateIndex(
                name: "IX_sous_dossier_id_dossier",
                table: "sous_dossier",
                column: "id_dossier");

            migrationBuilder.CreateIndex(
                name: "IX_unite_responsable_code_agence",
                table: "unite_responsable",
                column: "code_agence");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "calendrier_conservation");

            migrationBuilder.DropTable(
                name: "mouvement");

            migrationBuilder.DropTable(
                name: "sous_dossier");

            migrationBuilder.DropTable(
                name: "operation");

            migrationBuilder.DropTable(
                name: "dossier");

            migrationBuilder.DropTable(
                name: "local");

            migrationBuilder.DropTable(
                name: "unite_responsable");

            migrationBuilder.DropTable(
                name: "agence");
        }
    }
}
