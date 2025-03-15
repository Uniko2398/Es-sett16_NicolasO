using Microsoft.EntityFrameworkCore;
using PoliziaMunicipale.Models;
using PoliziaMunicipaleApp.Models;

namespace PoliziaMunicipaleApp.Data
{
    public class PoliziaContext : DbContext
    {
        public DbSet<Anagrafica> Anagrafiche { get; set; }
        public DbSet<Tipo_Violazione> Violazioni { get; set; }
        public DbSet<Verbale> Verbali { get; set; }

        public PoliziaContext(DbContextOptions<PoliziaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Verbale>()
                .HasOne(v => v.Anagrafica)
                .WithMany()
                .HasForeignKey(v => v.anagrafica_id);

            modelBuilder.Entity<Verbale>()
                .HasOne(v => v.Violazione)
                .WithMany()
                .HasForeignKey(v => v.violazione_id);

            modelBuilder.Entity<Anagrafica>().HasData(
                new Anagrafica { anagrafica_id = 1, Cognome = "Rossi", Nome = "Mario", Indirizzo = "Via Roma 1", Citta = "Milano", CAP = "20100", Cod_Fisc = "RSSMRA80A01H501U" },
                new Anagrafica { anagrafica_id = 2, Cognome = "Bianchi", Nome = "Luigi", Indirizzo = "Via Torino 2", Citta = "Roma", CAP = "00100", Cod_Fisc = "BNCLGU81B02H501V" }
            );

            modelBuilder.Entity<Tipo_Violazione>().HasData(
                new Tipo_Violazione { Id = 1, Descrizione = "Eccesso di velocità" },
                new Tipo_Violazione { Id = 2, Descrizione = "Guida senza patente" }
            );

            modelBuilder.Entity<Verbale>().HasData(
                new Verbale { Id = 1, DataViolazione = DateTime.Now, IndirizzoViolazione = "Via Roma 1", Nominativo_Agente = "Agente Smith", DataTrascrizioneVerbale = DateTime.Now, Importo = 150.00m, DecurtamentoPunti = 5, anagrafica_id = 1, violazione_id = 1 },
                new Verbale { Id = 2, DataViolazione = DateTime.Now, IndirizzoViolazione = "Via Torino 2", Nominativo_Agente = "Agente Brown", DataTrascrizioneVerbale = DateTime.Now, Importo = 500.00m, DecurtamentoPunti = 10, anagrafica_id = 2, violazione_id = 2 }
            );
        }
    }
}